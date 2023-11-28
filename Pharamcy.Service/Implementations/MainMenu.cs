using Pharamcy.Core.Helpers;
using Pharamcy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Service.Implementations
{
    public class MainMenu:IMainMenu
    {
        AdminPanelMenu AdminPanel = new AdminPanelMenu();

        public void AdminChoose()
        {
            Console.Clear();
            MyConsole.WriteLine("1.Admin Panel");
            MyConsole.WriteLine("2.Satish et");
            MyConsole.WriteLine("3.Melumatlarimi yenile");
            MyConsole.WriteLine("4.Adminleri gor");
            MyConsole.WriteLine("5.Stafflari gor");
            MyConsole.WriteLine("6.Dermanlari gor");
            MyConsole.WriteLine("7.Budceni gor");
            MyConsole.WriteLine("8.Exit");

            string choosen = Console.ReadLine();

            switch (choosen)
            {
                case "1":
                    AdminPanel.AdminDashboard();
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "8":

                    break;

                default:
                    break;
            }
        }
    }
}
