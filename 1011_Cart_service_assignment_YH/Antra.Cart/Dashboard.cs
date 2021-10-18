using System;
using System.Collections.Generic;
using System.Text;


namespace Antra.Cart
{
    class Dashboard
    {
        public void ShowDashboard()
        {
            Console.Title = "Antra Inc.";

            NewCheckout newCheckout = new NewCheckout();

            Menu m = new Menu();
            int choice = m.PrintMenu(typeof(DiscountType));
            if (choice == 1)
                newCheckout.discount = true;
            
            
            newCheckout.Run();

        }
    }
}
