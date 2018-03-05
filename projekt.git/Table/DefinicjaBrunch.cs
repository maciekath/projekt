using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soneta.Zadania;
using projekt.git;
using Soneta.Business;
using Soneta.Types;
using projekt.git.Table;
using Soneta.CRM;
using Soneta.Kalend;


[assembly: NewRow(typeof(DefinicjaBrunch))]
namespace projekt.git.Table
{
 public   class DefinicjaBrunch : gitModule.DefinicjaBrunchRow
    {
        public DefinicjaBrunch(Projekt Projekt) : base(Projekt) { }
        public DefinicjaBrunch(RowCreator creator) : base(creator) { }

  
    }
}

