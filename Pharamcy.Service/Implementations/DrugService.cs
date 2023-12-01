using Pharamcy.Core.Constants;
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
    public class DrugService:IDrugService
    {
        DrugRepository drugRepository = new DrugRepository();
        public void Create()
        {
            Console.Clear();
            string name;
            DrugType type;
            int drugCount, purchasePrice, salePrice;
            bool countexist, PurchasePriceexist, SalePriceexist;

            do
            {
                MyConsole.WriteLine("Dermanin adini daxil edin: ");
                name = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(name));
            do
            {
            drugtype:
                MyConsole.WriteLine("Dermanin tipini daxil edin: \n 1.Powder\n 2.Syrop\n 3.Tablet");
                //object  type = Enum.GetNames(typeof(DrugType)).GetValue(int.Parse(Console.ReadLine()));
                switch (Console.ReadLine())
                {
                    case "1":
                        type = DrugType.POWDER;
                        break;
                    case "2":
                        type = DrugType.SYROB;
                        break;
                    case "3":
                        type = DrugType.TABLET;
                        break;
                    default:
                        MyConsole.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                        goto drugtype;
                }

            } while (string.IsNullOrWhiteSpace(name));
            do
            {
                MyConsole.WriteLine("Dermanin sayni daxil edin: ");
                countexist = int.TryParse(Console.ReadLine(), out drugCount);
            } while (!countexist);
            do
            {
                MyConsole.WriteLine("Dermanin alish qiymetini daxil edin: ");
                PurchasePriceexist = int.TryParse(Console.ReadLine(), out purchasePrice);

            } while (!PurchasePriceexist);
            do                            
            {

                MyConsole.WriteLine("Satish qiymetini daxil edin: ");
                checkPrice:
                SalePriceexist = int.TryParse(Console.ReadLine(), out salePrice);
                if (salePrice<purchasePrice)
                {
                    Console.WriteLine("satis qiymeti alis qiymetinden kicik ola bilmez");
                    MyConsole.WriteLine("Yeniden daxil edin");
                    goto checkPrice;
                }

            } while (!SalePriceexist);
            Drug drug = new Drug
            {
                CreateAt = DateTime.Now,
                Count = drugCount,
                DrugType = type,
                Name = name,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
            };

            drugRepository.Create(drug);
            MyConsole.WriteFormat("Derman ugurla elave edildi", ConsoleColor.Green);
        }

        public void Delete()
        {
            Console.Clear();
            Drug drug;
            int drugId;
            List<Drug> drugs = drugRepository.GetAll();
            do
            {
                foreach (var Dbdrug in drugs)
                {
                    MyConsole.WriteLine($"Drug ID:{Dbdrug.Id},Drug Name: {Dbdrug.Name}");
                }
                MyConsole.WriteLine("Silmek istediyiniz dermanin Idsini Daxil edin: ");

                int.TryParse(Console.ReadLine(), out drugId);

                drug = drugRepository.GetbyId(drugId);
            } while (drug == null);

            drugRepository.Delete(drug);
            MyConsole.WriteFormat("Derman ugurla silindi", ConsoleColor.Green);
        }

        public void Update()
        {
            Console.Clear();
            Drug drug;
            int drugId;
            string name;
            bool isexist;
            List<Drug> drugs = drugRepository.GetAll();
            do
            {
                foreach (var Dbdrug in drugs)
                {
                    MyConsole.WriteLine($"Drug ID:{Dbdrug.Id},Drug Name: {Dbdrug.Name}");
                }
                MyConsole.WriteLine("Update etmek istediyiniz dermanin Idsini Daxil edin: ");

                int.TryParse(Console.ReadLine(), out drugId);

                drug = drugRepository.GetbyId(drugId);
            } while (drug == null);

        drugChoose:
            MyConsole.WriteLine("Hansi deyeri deyishmek isteyirsiniz? \n 1.Name \n 2.DrugType \n 3.Count \n 4.PurchasePrice\n 5.SalePrice");

            switch (Console.ReadLine())
            {
                case "1":
                    do
                    {
                        MyConsole.WriteLine("Yeni ad daxil edin: ");
                        name = Console.ReadLine();
                    } while (string.IsNullOrEmpty(name));
                        drug.Name = name;
                    break;
                case "2":
                    UpdateDrugType(drug);
                    Console.WriteLine(drug.DrugType);
                    break;
                case "3":

                    drug.Count = UpdateWithDelegate($"Evvelki count {drug.Count}", "Yeni count daxil edin:");
                    break;
                case "4":
                    drug.PurchasePrice = UpdateWithDelegate($"Evvelki Alish qiymeti {drug.PurchasePrice}", "Yeni alish qiymetini daxil edin", d => d.PurchasePrice > d.SalePrice, drug);
                    break;
                case "5":
                    drug.SalePrice = UpdateWithDelegate($"Evvelki Satish qiymeti {drug.SalePrice}", "Yeni Satish qiymetini daxil edin", d => d.PurchasePrice > d.SalePrice, drug);
                    
                    break;

                default:
                    MyConsole.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                    goto drugChoose;
            }

            drugRepository.Update(drug);

        }

        private int UpdateWithDelegate(string promt, string inputPromt, Func<Drug, bool> func = default, Drug drug = default)
        {
            bool isexist;
            int drugCount;
            do
            {
                MyConsole.WriteLine(promt);
                MyConsole.WriteLine(inputPromt);

                isexist = int.TryParse(Console.ReadLine(), out drugCount);
                drug.SalePrice = drugCount;

            } while ((!isexist) || func(drug));
            return drugCount;
        }

        private void UpdateDrugType(Drug drug)
        {
            string choosen;
        drugtype:
            MyConsole.WriteLine("Dermanin yeni tipini daxil edin: \n 1.Powder\n 2.Syrop\n 3.Tablet");
            //object  type = Enum.GetNames(typeof(DrugType)).GetValue(int.Parse(Console.ReadLine()));
            choosen = Console.ReadLine();
            switch (choosen)
            {
                case "1":
                    drug.DrugType = DrugType.POWDER;
                    break;
                case "2":
                    drug.DrugType = DrugType.SYROB;
                    break;
                case "3":
                    drug.DrugType = DrugType.TABLET;
                    break;
                default:
                    MyConsole.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                    goto drugtype;
            }

        }
    }
}
