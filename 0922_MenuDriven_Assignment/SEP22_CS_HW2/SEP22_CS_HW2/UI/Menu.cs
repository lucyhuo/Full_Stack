using System;
using System.Collections.Generic;
using System.Text;

namespace SEP22_CS_HW2.UI
{
    class Menu
    {
        /**
         * Print Menu to User, Get A Choice from User
         */
        public int PrintMenu(Type t)
        {
            string[] names = Enum.GetNames(t);
            int[] choices = (int[])Enum.GetValues(t);
            int l = names.Length;
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine($"Print {choices[i]} for {names[i]}");
            }
            Console.Write("Enter your choice = ");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}
