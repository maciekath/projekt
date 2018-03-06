using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Types;
using Soneta.Zadania;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using projekt.git.Tabele;


[assembly: FolderView("Projekty/Brunche z gita",
    Priority = 12,
    Description = "Zwstawienie wszystkich brunchy",
    TableName = "ProjektBrunche",
    ViewType = typeof(projekt.git.kafelkaViewInfo)
)]
namespace projekt.git
{
    public class kafelkaViewInfo : ViewInfo
    {

      public  kafelkaViewInfo()

        {
            ResourceName = "kafelkaViewInfo";
            ToolbarContext = new string[] {
                "kafelkaViewInfo+Paramskafelka.Projekt",

                "kafelkaViewInfo+Paramskafelka.Okres",

            };
            InitContext += kafelkaViewInfo_InitContext;
            CreateView += kafelkaViewInfo_CreateView;
            Action += kafelkaViewInfo_Action;
        }
        private void kafelkaViewInfo_Action(object sender, ActionEventArgs e)
        {
            if (e.Action == ActionEventArgs.Actions.Edit && e.FocusedData != null)
                e.FocusedData = ((DefinicjaBrunch)e.OriginalFocusedData).Pracownik;
        }

        void kafelkaViewInfo_InitContext(object sender, ContextEventArgs args)
        {
            args.Context.TryAdd(() => new Paramskafelka(args.Context));
        }

        void kafelkaViewInfo_CreateView(object sender, CreateViewEventArgs args)
        {
            Paramskafelka parameters;
            if (!args.Context.Get(out parameters))
                return;
            args.View = ViewCreate(parameters);
            args.View.AllowNew = false;
        }
        protected View ViewCreate(Paramskafelka pars)
        {
            gitModule tabM = gitModule.GetInstance(pars);
            Soneta.Business.View view = null;

            if (pars.Projekt != null)
            {
                if (view == null) view = tabM.ProjektBrunche.WgProjekt[pars.Projekt].CreateView();
                else view.Condition &= new FieldCondition.Equal("Projekt", pars.Projekt);
            }
            if (pars.Okres != FromTo.Empty && pars.Okres != FromTo.All)
            {
                if (view == null) view = tabM.ProjektBrunche.Wgdata[new FieldCondition.GreaterEqual("data", pars.Okres.From) & new FieldCondition.LessEqual("data", pars.Okres.To)].CreateView();
                else view.Condition &= new FieldCondition.GreaterEqual("data", pars.Okres.From) & new FieldCondition.LessEqual("data", pars.Okres.To);
            }





            return view;
        }


        public class Paramskafelka : ContextBase
        {
            private const string Key = "projekt.git.kafelka";

            public Paramskafelka(Context context) : base(context)
            {
                Load();
            }

            public Projekt Projekt
            {
                get
                {
                    if (Context.Contains(typeof(Projekt)))
                        return (Projekt)Context[typeof(Projekt)];
                    return null;
                }
                set
                {
                    Context[typeof(Projekt)] = value;
                    Save("Projekt");
                }
            }



            public enum Kierunek
            {
                Razem = 0, Rozchód = -1, Przychód = 1
            }

            public Kierunek KierunekMagazyn
            {
                get
                {
                    if (Context.Contains(typeof(Kierunek)))
                        return (Kierunek)Context[typeof(Kierunek)];
                    return Kierunek.Razem;
                }
                set
                {
                    Context[typeof(Kierunek)] = value;
                    Save("KierunekMagazyn");
                }
            }






            public FromTo Okres
            {
                get
                {
                    if (Context.Contains(typeof(FromTo)))
                        return (FromTo)Context[typeof(FromTo)];
                    return FromTo.Empty;
                }
                set
                {
                    Context[typeof(FromTo)] = value;
                    Save("Okres");
                }
            }

            protected void Load()
            {
                SetContext(typeof(Projekt), Session.Login.Load(this, Key, "Projekt"));
                //SetContext(typeof(Kierunek), Session.Login.Load(this, Key, "KierunekMagazyn"));
                //SetContext(typeof(ElemStruktListy), Session.Login.Load(this, Key, "Element"));
                //SetContext(typeof(Magazyn), Session.Login.Load(this, Key, "Magazyn"));
                //SetContext(typeof(Towar), Session.Login.Load(this, Key, "Towar"));
                SetContext(typeof(FromTo), FromTo.Month(Date.Today));
            }

            protected void Save(string valueKey)
            {
                Session.Login.Save(this, Key, valueKey);
            }
        }
    }
}


