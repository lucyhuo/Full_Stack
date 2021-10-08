using System;

/*
 * 	1. Find the factorial of a number: 6x5x4x3x2x1
	2. If a number is prime or not 
	3. If a year is leap or not  
	4. Least common factor of two numbers 
*/

namespace SEP21_CS_HW1
{
    class FactorialNumber
    {
        public int Factorial(int num)
        {
            int result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }
    }
    
    class PrimeNumber
    {
        public void IsPrime(int num)
        {
            bool r = true;
            for (int i = 2; i <= num/2; i++)
            {
                if(num % i == 0)
                {
                    r = false;
                    Console.WriteLine($"{num} is not prime number");
                    break;
                }
            }
            if(r == true)
            {
                Console.WriteLine($"{num} is prime number");
            }
            
        }
    }

    class LeapYear
    {
        public void IsLeapYear(int yyyy)
        {
            if (yyyy % 400 == 0 || (yyyy % 4 == 0 && yyyy % 100 != 0))
            {
                Console.WriteLine($"{yyyy} is a leap year");
            }else
            {
                Console.WriteLine($"{yyyy} is not a leap year");
            }
        }
    }

    class LeastCommonMultiplier
    {
        int GCF(int a, int b)
        {
            int temp;
            while(b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public int LCM(int a, int b)
        {
            return (a * b)/ GCF(a, b);
        }
    }

    class SEP21_CS_HW1
    {
        static void Main(string[] args)
        {
            FactorialNumber fn = new FactorialNumber();
            Console.WriteLine("input a number to calculate its factorial number");
            int i = Convert.ToInt32(Console.ReadLine());
            int r = fn.Factorial(i);
            Console.WriteLine($"Factorial number of {i} is {r}");

            PrimeNumber pn = new PrimeNumber();
            pn.IsPrime(3);
            
            LeapYear ly = new LeapYear();
            ly.IsLeapYear(1900);

            LeastCommonMultiplier l = new LeastCommonMultiplier();
            int k = l.LCM(4, 6);
            Console.WriteLine(k);
        }
    }
}
