using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repository;
using Antra.CompanyApp.Data.Model;


namespace Antra.CompanyApp.ConsoleApp
{
    
    class ManageDept
    {
        IRepository<Dept> deptRepository;
        public ManageDept()
        {
            deptRepository = new DeptRepository();
        }

        void AddDepartment()
        {
            Dept d = new Dept();
            Console.WriteLine("Enter Name = ");
            d.DName = Console.ReadLine();
            Console.WriteLine("Enter Location = ");
            d.Loc = Console.ReadLine();
            if(deptRepository.Insert(d)>0)
                Console.WriteLine("Department Added Successfully");
            else
                Console.WriteLine("Some error has occured");
        }

        void DeleteDepartment()
        {
            Console.WriteLine("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(deptRepository.Delete(id) > 0)
                Console.WriteLine("Department Deleted Successfully");
            else
                Console.WriteLine("Some error has occured");
        }


        void UpdateDepartment()
        {
            Dept d = new Dept();
            Console.WriteLine("Enter Id = ");
            d.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name = ");
            d.DName = Console.ReadLine();
            Console.WriteLine("Enter Location = ");
            d.Loc = Console.ReadLine();
            if (deptRepository.Update(d) > 0)
                Console.WriteLine("Department Updated Successfully");
            else
                Console.WriteLine("Some error has occured");
        }


        void PrintDepartments()
        {
            var collection = deptRepository.GetAll();
            if(collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.DName} \t {item.Loc}");
                }
            }
           
        }

        void PrintDepartmentById()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Dept item = deptRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.DName} \t {item.Loc}");
            }
            else
            {
                Console.WriteLine("No record found");
            }
        }

        public void Run()
        {
            //AddDepartment();
            //Console.ReadLine();
            //DeleteDepartment();
            //PrintDepartments();
            //Console.ReadLine();
            //UpdateDepartment();
            PrintDepartmentById();
        }

    }
}
