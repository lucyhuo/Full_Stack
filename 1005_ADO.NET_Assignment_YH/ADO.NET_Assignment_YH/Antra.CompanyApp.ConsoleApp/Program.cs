using System;

namespace Antra.CompanyApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageDept manageDept = new ManageDept();
            manageDept.Run();

            ManageCustomer manageCustomer = new ManageCustomer();
            manageCustomer.Run();
        }
    }
}
