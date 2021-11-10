using System;
using SEP22_CS_HW2.UI;

/**
 * A consultant company management system 
 */ 

namespace SEP22_CS_HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Show Dashboard - in Dashboard: print menu(based on selected object), return option;
            // based on option, run create derived class,
            // and run management methods in derived class 

            Console.WriteLine("Hello Welcome!");
            Dashboard db = new Dashboard();
            db.ShowDashboard();

        }
    }
}
