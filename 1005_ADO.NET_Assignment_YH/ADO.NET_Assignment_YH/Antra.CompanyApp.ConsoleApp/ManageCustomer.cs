using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repository;
using Antra.CompanyApp.Data.Model;

namespace Antra.CompanyApp.ConsoleApp
{

    class ManageCustomer
    {
        IRepository<Customer> customerRepository;
        public ManageCustomer()
        {
            customerRepository = new CustomerRepository();
        }

        void AddCustomer()
        {
            Customer d = new Customer();
            Console.WriteLine("Enter Name = ");
            d.FullName = Console.ReadLine();
            Console.WriteLine("Enter Mobile = ");
            d.Mobile = Console.ReadLine();
            Console.WriteLine("Enter Email = ");
            d.Email = Console.ReadLine();
            Console.WriteLine("Enter City = ");
            d.City = Console.ReadLine();
            Console.WriteLine("Enter Country = ");
            d.Country = Console.ReadLine();
            if (customerRepository.Insert(d) > 0)
                Console.WriteLine("Customer Added Successfully");
            else
                Console.WriteLine("Some error has occured");
        }

        void DeleteCustomer()
        {
            Console.WriteLine("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (customerRepository.Delete(id) > 0)
                Console.WriteLine("Customer Deleted Successfully");
            else
                Console.WriteLine("Some error has occured");
        }


        void UpdateCustomer()
        {
            Customer d = new Customer();
            Console.WriteLine("Enter Id = ");
            d.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter FullName = ");
            d.FullName = Console.ReadLine();
            Console.WriteLine("Enter Mobile = ");
            d.Mobile = Console.ReadLine();
            Console.WriteLine("Enter Email = ");
            d.Email = Console.ReadLine();
            Console.WriteLine("Enter City = ");
            d.City = Console.ReadLine();
            Console.WriteLine("Enter Country = ");
            d.Country = Console.ReadLine();

            if (customerRepository.Update(d) > 0)
                Console.WriteLine("Customer Updated Successfully");
            else
                Console.WriteLine("Some error has occured");
        }


        void PrintDepartments()
        {
            var collection = customerRepository.GetAll();
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.FullName} \t {item.Mobile}");
                }
            }

        }

        void PrintDepartmentById()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Customer item = customerRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.FullName} \t {item.Mobile}");
            }
            else
            {
                Console.WriteLine("No record found");
            }
        }

        public void Run()
        {
            UpdateCustomer();
        }

    }
}
