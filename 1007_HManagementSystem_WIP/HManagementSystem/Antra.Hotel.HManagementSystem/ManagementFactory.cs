using System;
using System.Collections.Generic;
using System.Text;
using Antra.Hotel.Data.Repository;


namespace Antra.Hotel.ConsoleApp
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
                case (int)Options.Roomtypes:
                    return new ManageRT();
                case (int)Options.Rooms:
                    return new ManagementRooms();
                    //case (int)Options.Customers:
                    //    return new ManageCustomers();
                    //case (int)Options.Services:
                    //    return new ManageServices();

            }
            Console.WriteLine("Invalid Option");
            return null;
        }
    }
}
