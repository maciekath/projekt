using Soneta.Business.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly: FolderView("Projekty/Brunche z gita",
    Priority = 12,
    Description = "Pozycje kontraktów rozchodowe i przychodowe",
    TableName = "ProjektBrunche",
    ViewType = typeof(projekt.git.kafelka)
)]
namespace projekt.git
{
  public  class kafelka
    {
    }
}
