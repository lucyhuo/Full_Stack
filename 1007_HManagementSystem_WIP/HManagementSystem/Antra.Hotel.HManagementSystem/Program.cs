using Antra.Hotel.ConsoleApp;
using System;
using Antra.Hotel.ConsoleApp.UI;

namespace Antra.Hotel.ComsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dashboard db = new Dashboard();
            db.ShowDashboard();


            //ManageRT manageRT = new ManageRT();
            //manageRT.Run();
        }
    }
}
