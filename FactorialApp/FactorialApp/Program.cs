using System;

namespace FactorialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }
        static int Factorial(int number)
        {
            int factorial = 1;

            for(int index = 2; number >= index; index++)
            {
                factorial *= index; 
            }
            return factorial;
        }
    }
}
