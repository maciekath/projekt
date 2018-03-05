using Soneta.Business;
using Soneta.Business.App;
using Soneta.Zadania;
using projekt.git.UI;
using System;
using Soneta.CRM;
using projekt.git.Table;



// Sposób w jaki należy zarejestrować extender, który później zostanie użyty w interfejsie.
[assembly: Worker(typeof(BrunchExtender))]



namespace projekt.git.UI
{
    public class BrunchExtender
    {
       
            [Context]
            public Context Context
            {
                get;
                set;
            }


            System.DateTime d = DateTime.Now;

            [Context]
            public Projekt proj { get; set; }

            public bool IsVisible
            {
                get { return Soneta.CRM.Config.Ogólne.TypFormularzaDlaObiektu(proj) == TypFormularza.Podstawowy; }
            }

            public bool IsReadOnly
            {
                get { return proj == null || proj.AccessRight != AccessRights.Granted; }
            }

            public ViewInfo Wyswietlmarze
            {
                get
                {
                    gitModule mm = gitModule.GetInstance(proj);

                    var vi = new ViewInfo();
                    vi.ResourceName = "GridMarza4";
                    vi.CreateView += (sender, args) =>
                    {
                        args.View = mm.ProjektBrunche.Wgdata.CreateView();
                        args.View.Condition &= new FieldCondition.Equal("Projekt", proj);

                        args.View.AllowNew = !IsReadOnly;
                        args.View.NewRows = !IsReadOnly ? new[] { new NewRowAttribute(typeof(DefinicjaBrunch)) } : null;
                    };

                    return vi;
                }
            }
        }
    }

