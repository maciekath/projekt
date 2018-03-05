using System;
using Soneta.Business;
using Soneta.Business.UI;
using projekt.git;
using Soneta.Zadania;
using System.Windows.Forms;

[assembly: Worker(typeof(ConnectWorker), typeof(Projekty))]
namespace projekt.git
{
    public class ConnectWorker
    {

   


        // TODO -> Należy podmienić podany opis akcji na bardziej czytelny dla uzytkownika
        [Action("Darek / Brunche", Mode = ActionMode.Progress, Target = ActionTarget.ToolbarWithText,Icon =ActionIcon.Asterix)]
        public void  ToDo()
        {


MessageBox.Show("To ja");

        }
    }


   

}
