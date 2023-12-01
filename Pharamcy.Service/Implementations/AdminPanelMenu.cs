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
            EmployeService employeService = new EmployeService();
            DrugService drugService = new DrugService();
            Admin:
            Console.Clear();

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
                    goto Admin;
                    
                case "2":
                    employeService.Delete();
                    goto Admin;

                case "3":
                    employeService.Update();
                    goto Admin;
                case "4":
                    drugService.Create();
                    goto Admin;
                case "5":
                    drugService.Delete();
                    goto Admin;
                    
                case "6":
                    drugService.Update();
                   goto Admin;
                case "7":
                    break;


                default:
                    break;
            }
        }
    }
}
