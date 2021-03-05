using System;

namespace CounterPositiveNumberApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int isNegative = 0;
            int isPositive = 0;
     
            while(Console.ReadLine() != "")
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0)
                    isPositive++;
                else
                    isNegative++;
            }

            Console.WriteLine(isNegative);
            Console.WriteLine(isPositive);
        }
    }
}
