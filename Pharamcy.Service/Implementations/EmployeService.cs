using Pharamcy.Core.Constants;
using Pharamcy.Core.Helpers;
using Pharamcy.Core.Models;
using Pharamcy.DataAccess.Repositories.Implementations;
using Pharamcy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Service.Implementations
{
    public class EmployeService:IEmployeService
    {
            EmployeRepository employeRepository = new EmployeRepository();
            RoleRepository roleRepository = new RoleRepository();

        string name;
        string Surname;
        int salary;
        string username;
        string password;
        Gender gender;
        int InputRole;
        int roleId;
        bool isvalidGender;
        bool isvalidUsername=true;
        int i;


        private string Input(string promt, Func<string, bool> func)
        {
            string inputfromConsole;
            do
            {
                MyConsole.Write($"{promt}");
                inputfromConsole = Console.ReadLine();
            } while (func(inputfromConsole));

            return inputfromConsole;
        }
        public void Create()
        {
            Console.Clear();
            List<RoleType> roles = roleRepository.GetAll();
            List<string> names=new List<string>();

            do
            {
                MyConsole.Write("Ad Daxil edin: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name) || name.Length < 3);

            name = Input("Ad daxil edin: ", s => string.IsNullOrEmpty(s) || name.Length < 3);
            do
            {
                MyConsole.Write("Surname Daxil edin: ");
                Surname = Console.ReadLine();
            } while (string.IsNullOrEmpty(Surname) || Surname.Length < 5);
            do
            {
                MyConsole.Write("Maashi daxil edin : ");
                int.TryParse(Console.ReadLine(), out salary);
            } while (salary < 100 || salary > 3000);
            do
            {
                MyConsole.Write("Username daxil edin : ");
                username = Console.ReadLine();
                if (!names.Contains(username) && isvalidUsername)
                {
                    names.Add(username);
                }
                else
                {
                    isvalidUsername = false;
                }
            } while (string.IsNullOrEmpty(username));
            do
            {
                MyConsole.Write("Passwor daxil edin : ");
                password = Console.ReadLine();
            } while (password.Length < 6);
            do
            {
                MyConsole.Write("Cinsi daxil edin : ");
                MyConsole.WriteLine("1-Kişi\n 2-Qadın");
                string genderChoose = Console.ReadLine();
                if (genderChoose == "1")
                {
                    gender = Gender.Kişi;
                    isvalidGender = false;
                }
                else if (genderChoose == "2")
                {
                    gender = Gender.Qadın;
                    isvalidGender = false;
                }
                else
                {
                    MyConsole.WriteLine("Duzgun daxil edin", ConsoleColor.Red);
                    isvalidGender = true;
                }

            } while (isvalidGender);
            do
            {

                MyConsole.WriteLine("Role daxil edin");
                for (i = 0; i < roles.Count; i++)
                {
                    MyConsole.WriteLine($"{i + 1}-{roles[i].RoleName}");
                }

                int.TryParse(Console.ReadLine(), out InputRole);

                roleId = roles[InputRole - 1].Id;
            } while (InputRole > roles.Count);                          

            Employe employe = new Employe()
            {
                CreateAt = DateTime.Now,
                Gender = gender,
                Name = name,
                Password = password,
                Salary = salary,
                Surname = Surname,
                Username = username,
                RoleTypeId = roleId
            };

            employeRepository.Create(employe);
        }
        public void Delete()
        {
            bool isExist;
            int id;
            List<Employe> employes = employeRepository.GetAll();
            Console.WriteLine("Hansi Idli Employeni silmek isteyirsen?");
            foreach (var employe in employes)
            {
                Console.WriteLine($"employe Id:{employe.Id},EmployeName: {employe.Name}");
            }

            do
            {
                Console.WriteLine("Yeniden daxil edin");
                int.TryParse(Console.ReadLine(), out id);
                isExist = employeRepository.Any(e => e.Id == id);
            } while (!isExist);

            employeRepository.Delete(employeRepository.GetbyId(id));
            MyConsole.WriteLine("Ugurla silindi", ConsoleColor.Green);

        }

        private static void UpdateStringProperty(string propertyName, Employe employe)
        {
            MyConsole.WriteLine($"Yeni {propertyName} daxil et: ");
            string newValue = Console.ReadLine();

            // Use reflection to set the property value dynamically
            employe.GetType().GetProperty(propertyName)?.SetValue(employe, newValue);
        }


        public void Update()
        {
            Employe employe;

            do
            {
                MyConsole.WriteLine("Update etmek istediyiniz shexsin idsini daxil edin : ");
                int.TryParse(Console.ReadLine(), out int id);
                employe = employeRepository.GetbyId(id);
            } while (employe == null);

            MyConsole.WriteLine("Sen Employenin hansi propertysini deyismek isteyirsen? ", ConsoleColor.Gray);

            MyConsole.WriteLine("1.Name\n 2.Surname\n 3.Salary\n 4.Username\n 5.Password\n 6.Gender\n 7.Role\n ");
            string choose = Console.ReadLine();
            switch (choose)
            {

                case "1":
                    UpdateStringProperty("Name", employe);
                    break;
                case "2":
                    UpdateStringProperty("Surname", employe);
                    break;
                case "3":
                    MyConsole.WriteLine("Yeni Salary daxil et: ");
                    int.TryParse(Console.ReadLine(), out int newSalary);
                    employe.Salary = newSalary;
                    break;
                case "4":
                    UpdateStringProperty("Username", employe);
                    break;
                case "5":
                    UpdateStringProperty("Password", employe);
                    break;

                    case "6":
                    do { 
                    MyConsole.WriteLine("Yeni Gender daxil et Peyyy...");
                    MyConsole.WriteLine("1-Kişi\n 2-Qadın");
                    string genderChoose = Console.ReadLine();
                    if (genderChoose == "1")
                    {
                        employe.Gender = Gender.Kişi;
                        isvalidGender = false;
                    }
                    else if (genderChoose == "2")
                    {
                        employe.Gender = Gender.Qadın;
                        isvalidGender = false;
                    }
                    else
                    {
                        MyConsole.WriteLine("Duzgun daxil edin", ConsoleColor.Red);
                        isvalidGender = true;
                    }
                    
            } while (isvalidGender) ;
            break;

                case "7":
                    List<RoleType> roles = roleRepository.GetAll();
                    do
                    {

                        MyConsole.WriteLine("Yeni Role daxil edin");
                        for (i = 0; i < roles.Count; i++)
                        {
                            MyConsole.WriteLine($"{i + 1}-{roles[i].RoleName}");
                        }

                        int.TryParse(Console.ReadLine(), out InputRole);

                        employe.RoleTypeId = roles[InputRole - 1].Id;
                    } while (InputRole > roles.Count);
                    break;

                default:
                    break;

            }
            employeRepository.Update(employe);
        }
    }
}
