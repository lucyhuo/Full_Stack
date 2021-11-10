using System;
using System.Collections.Generic;
using System.Text;
using SEP22_CS_HW2.Model;
using SEP22_CS_HW2.UI;

namespace SEP22_CS_HW2.DAL
{
    class ManageEmployees : Management
    {
        List<Employees> lstEmployees;
        public ManageEmployees()
        {
            lstEmployees = new List<Employees>();
        }

        void Add()
        {
            Employees e = new Employees();
            Console.WriteLine("Enter Id = ");
            e.EmployeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Full Name = ");
            e.FullName = Console.ReadLine();
            Console.WriteLine("Enter Department = ");
            e.Department = Console.ReadLine();
            lstEmployees.Add(e);
            Console.WriteLine("Employee has been added successfully");
        }
        
        void Delete()
        {
            Console.WriteLine("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employees e = null;
            foreach (Employees item in lstEmployees)
            {
                if(item.EmployeeID == id)
                {
                    e = item;
                    break;
                }
            }
            if(e != null)
            {
                lstEmployees.Remove(e);
                Console.WriteLine("Employee has been removed successfully");
            }
        }

        void Print()
        {
            int l = lstEmployees.Count;
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(lstEmployees[i].EmployeeID + "\t" + lstEmployees[i].FullName + "\t" + lstEmployees[i].Department);
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
