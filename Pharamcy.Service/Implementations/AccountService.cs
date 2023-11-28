using Pharamcy.Core.Helpers;
using Pharamcy.Core.Models;
using Pharamcy.DataAccess.Repositories.Implementations;
using Pharamcy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Service.Implementations
{
    public class AccountService: IAccountService
    {
        AccountRepository accountRepository = new AccountRepository();
        private bool incorrectlogin = true;

        public void Login()
        {
            string userName;
            string password;
            do
            {
                if (!incorrectlogin)
                {
                    MyConsole.Write("Parol Və ya username səhvdir", ConsoleColor.DarkRed);
                }
                incorrectlogin = false;

                MyConsole.Write("Usernami daxil edin: ");
                userName = Console.ReadLine();
                MyConsole.Write("PassWord daxil edin: ");
                password = Console.ReadLine();
            }
            while (!accountRepository.Any(emp => emp.Password == password && emp.Username == userName));

            MyConsole.WriteFormat("Xoş Gelmisiniz", ConsoleColor.Green);

            MainMenu mainMenu = new MainMenu();
            mainMenu.AdminChoose();
        }

        public void Register(Employe employe)
        {

        }
    }
}
