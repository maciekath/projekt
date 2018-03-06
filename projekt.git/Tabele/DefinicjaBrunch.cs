using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soneta.Zadania;
using projekt.git;
using Soneta.Business;
using Soneta.Types;
using projekt.git.Tabele;
using Soneta.CRM;
using Soneta.Kalend;
using Soneta.Kadry;
using System.Collections;

[assembly: NewRow(typeof(DefinicjaBrunch))]
namespace projekt.git.Tabele
{
    public class DefinicjaBrunch : gitModule.DefinicjaBrunchRow
    {
        public DefinicjaBrunch(Projekt Projekt) : base(Projekt) { }
        public DefinicjaBrunch(RowCreator creator) : base(creator) { }

        public Pracownik Pracownik
        {
            get
            {

                Soneta.Business.View widok = KadryModule.GetInstance(Session).Pracownicy.CreateView();


                return (Pracownik)widok[0];
            }


        }
    }
}

