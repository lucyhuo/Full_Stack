using System;
using System.Collections.Generic;
using System.Text;
using Antra.Hotel.Data.Repository;
using Antra.Hotel.Data.Models;
using Antra.Hotel.ConsoleApp.UI;

namespace Antra.Hotel.ConsoleApp
{
    class ManagementRooms : Management
    {
        IRepository<Rooms> roomsRepository;
        public ManagementRooms()
        {
            roomsRepository = new RoomsRepository();
        }

        void Print()
        {
            var collection = roomsRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RTCODE} \t {item.Status}");
            }
        }

        void Add()
        {
            Rooms r = new Rooms();
            Console.WriteLine("Enter RT Code = ");
            r.RTCODE = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Status = ");
            r.Status = Console.ReadLine();
            roomsRepository.Insert(r);
            Console.WriteLine("Room has been added successfully");

        }

        void Update()
        {
            Rooms r = new Rooms();
            Console.WriteLine("Enter Id = ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter RT Code = ");
            r.RTCODE = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Status = ");

            roomsRepository.Update(r);
            Console.WriteLine("Room has been updated successfully");

        }

        void Delete()
        {
            Console.WriteLine("Enter Id = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            roomsRepository.Delete(Id);
            Console.WriteLine("Room has been deleted successfully");
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
