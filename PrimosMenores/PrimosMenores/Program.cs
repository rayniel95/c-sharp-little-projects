using System;

namespace PrimosMenores
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int index = 0; 19 > index; index++)
            {
                Console.Write(MinPrime(20)[index]);
            }
        }
        static int[] MinPrime(int aNumber)
        {
            int[] primeArray = new int[aNumber - 1];

            for (int index = 0; primeArray.Length > index; index++)
            {
                primeArray[index] = index;

                for (int factors = 2; primeArray[index] > factors; factors++)
                {
                    if ((primeArray[index] % factors) == 0)
                    {
                        primeArray[index] = 0;
                        break;
                    }
                }
            }
            return primeArray;
        }
    }
}
