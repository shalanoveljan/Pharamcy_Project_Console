using Pharamcy.Core.Helpers;
using Pharamcy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Service.Implementations
{
    public class AdminPanelMenu:IAdminPanelMenu
    {
        public void AdminDashboard()
        {
            Console.Clear();
            EmployeService employeService = new EmployeService();

            MyConsole.WriteLine("1.ishchi elave et", ConsoleColor.DarkYellow);
            MyConsole.WriteLine("2.ishchi sil", ConsoleColor.DarkYellow);
            MyConsole.WriteLine("3.Ishcini yenile", ConsoleColor.DarkYellow);
            MyConsole.WriteLine("4.Derman elave et", ConsoleColor.DarkYellow);
            MyConsole.WriteLine("5.Derman sil", ConsoleColor.DarkYellow);
            MyConsole.WriteLine("6.Dermani editle", ConsoleColor.DarkYellow);
            MyConsole.WriteLine("7.Exit", ConsoleColor.DarkYellow);

            string adminPanelChoose = Console.ReadLine();

            switch (adminPanelChoose)
            {
                case "1":
                    employeService.Create();
                    break;
                case "2":
                    employeService.Delete();
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

                default:
                    break;
            }
        }
    }
}
