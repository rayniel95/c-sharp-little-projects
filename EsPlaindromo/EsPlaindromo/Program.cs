using System;

namespace EsPlaindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EsPalindromo("anita lava la tia"));
        }
        static bool EsPalindromo(string oneString)
        {
            string myString = oneString.Replace(" ", "").ToLower();

            for(int index = 0; myString.Length > index; index++)
            {
                if(myString[index] != myString[myString.Length - (index + 1)])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
