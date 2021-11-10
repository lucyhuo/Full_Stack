using System;
using System.Collections.Generic;
using System.Text;

namespace SEP22_CS_HW2.DAL
{
    /**
     * get Management object, based on choice of management type 
     */
    class ManagementFactory
    {
        public Management getManagement(int option)
        {
            switch (option)
            {
                case (int)Options.Employees:
                    return new ManageEmployees();
                case (int)Options.Clients:
                    return new ManageClients();
            }
            Console.WriteLine("Invalid Option");
            return null;
        }
    }
}
