using System;
using System.Collections.Generic;
using System.Text;
using Antra.Hotel.Data.Repository;
using Antra.Hotel.Data.Models;
using Antra.Hotel.ConsoleApp.UI;

namespace Antra.Hotel.ConsoleApp
{
    class ManageRT: Management
    {
        IRepository<Roomtypes> rTRespository;
        public ManageRT()
        {
            rTRespository = new RTRepository();
        }

        void Print()
        {
            var collection = rTRespository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RTDESC} \t {item.Rent}");
            }
        }

        void Add()
        {
            Roomtypes rt = new Roomtypes();
            Console.WriteLine("Enter RT DESC = ");
            rt.RTDESC = Console.ReadLine();
            Console.WriteLine("Enter Rent = ");
            rt.Rent = Convert.ToDouble(Console.ReadLine());
            rTRespository.Insert(rt);
            Console.WriteLine("Roomtype has been added successfully");

        }

        void Update()
        {
            Roomtypes rt = new Roomtypes();
            Console.WriteLine("Enter Id = ");
            rt.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter RT DESC = ");
            rt.RTDESC = Console.ReadLine();
            Console.WriteLine("Enter Rent = ");
            rt.Rent = Convert.ToDouble(Console.ReadLine());
            rTRespository.Update(rt);
            Console.WriteLine("Roomtype has been updated successfully");

        }

        void Delete()
        {
            Console.WriteLine("Enter Id = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            rTRespository.Delete(Id);
            Console.WriteLine("Roomtype has been deleted successfully");
        }

        public override void Run()
        {
            //Print();

            int choice = 0;

            do
            {
                Console.Clear();
                Menu m = new Menu();
                choice = m.PrintMenu(typeof(Operations));

                switch (choice)
                {
                    case (int)Operations.Add:
                        Add();
                        break;
                    case (int)Operations.Update:
                        Update();
                        break;
                    case (int)Operations.Delete:
                        Delete();
                        break;
                    case (int)Operations.Print:
                        Print();
                        break;
                    case (int)Operations.Exit:
                        Console.WriteLine("Thanks for visit!!");
                        break;
                    default:
                        Console.WriteLine("Invalid ption!!");
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            } while (choice != (int)Operations.Exit);
        }
    }
}
