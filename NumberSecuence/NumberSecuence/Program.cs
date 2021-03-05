using System;

namespace NumberSecuence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberSecuence());
        }
        static int NumberSecuence()
        {
            int result = 0;
            int sum = 0;
            int counter = -1;
            int number = 1;

            while(number != 0)
            {
                number = int.Parse(Console.ReadLine());

                sum += number;
                counter++;
            }
            result = sum / counter;

            return result;
        }
    }
}
