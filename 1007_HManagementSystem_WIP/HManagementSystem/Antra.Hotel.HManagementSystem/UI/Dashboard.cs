using System;
using System.Collections.Generic;
using System.Text;



namespace Antra.Hotel.ConsoleApp.UI
{
    class Dashboard
    {
        // show dashboard 
        public void ShowDashboard()
        {
            Console.Title = "Antra Inc.";

            Menu m = new Menu();
            int op = m.PrintMenu(typeof(Options));

            ManagementFactory mf = new ManagementFactory();
            Management management = mf.getManagement(op);
            if(management != null)
            {
                management.Run();
            }
        }
    }
}
