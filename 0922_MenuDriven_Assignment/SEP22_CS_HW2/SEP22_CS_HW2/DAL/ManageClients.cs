using System;
using System.Collections.Generic;
using System.Text;
using SEP22_CS_HW2.Model;
using SEP22_CS_HW2.UI;

namespace SEP22_CS_HW2.DAL
{
    class ManageClients : Management
    {
        List<Clients> lstClents;
        public ManageClients()
        {
            lstClents = new List<Clients>();
        }
        void Add()
        {
            Clients c = new Clients();
            Console.WriteLine("Enter Id = ");
            c.ClientId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Company Name = ");
            c.CompanyName = Console.ReadLine();
            Console.WriteLine("Enter Contact = ");
            c.Contact = Console.ReadLine();
            lstClents.Add(c);
            Console.WriteLine("Client has been added successfully");
        }

        void Delete()
        {
            Console.WriteLine("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Clients c = null;
            foreach (Clients item in lstClents)
            {
                if (item.ClientId == id)
                {
                    c = item;
                    break;
                }
            }
            if (c != null)
            {
                lstClents.Remove(c);
                Console.WriteLine("Client has been removed successfully");
            }
        }
        void Print()
        {
            int l = lstClents.Count;
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(lstClents[i].ClientId + "\t" + lstClents[i].CompanyName + "\t" + lstClents[i].Contact);
            }
        }

        public override void Run()
        {
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
