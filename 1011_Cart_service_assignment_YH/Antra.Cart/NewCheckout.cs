using System;
using System.Collections.Generic;
using System.Text;
using Antra.Cart.Services;
using Antra.Cart.Data.Models;

namespace Antra.Cart
{
    class NewCheckout : Management
    {
        public bool discount { get; set; }

        public override void Run()
        {
            int choice = 0;
            CartService cs = new CartService();

            do
            {
                Console.Clear();

                Console.Write("Enter Number of Apples = ");
                int appleNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number of Oranges = ");
                int orangeNo = Convert.ToInt32(Console.ReadLine());
                string orderDate = DateTime.Now.ToString();
                decimal total = cs.CalculateTotal(appleNo, orangeNo, discount);

                Console.WriteLine($"Your Total = {total}");

                Order o = new Order();
                o.AppleNo = appleNo;
                o.OrangeNo = orangeNo;
                o.OrderDate = orderDate;
                o.TotalPrice = total;

                Menu m = new Menu();
                choice = m.PrintMenu(typeof(Options));
                if(choice == (int)Options.Exit)
                {
                    Console.WriteLine( "Your order is canceled");
                    break;
                }
                if (choice == (int)Options.Restart)
                    continue;

                if (cs.SendData(o) > 0)
                {
                    Console.WriteLine("**************************");
                    Console.WriteLine("Your order has been placed");
                    Console.WriteLine("**************************");

                }
                else
                {
                    Console.WriteLine("**************************");
                    Console.WriteLine("Some error has occurred");
                    Console.WriteLine("**************************");
                }

            } while (choice != 3);
        }
    }
}
