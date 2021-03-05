using System;

namespace IsPrimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPrime(6));
        }
        static bool IsPrime(int number)
        {
            for(int index = 2; number > index; index++)
            {
                if((number % index) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
