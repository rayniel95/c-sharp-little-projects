using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximo_I
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            int[] array = new int[4];

            for(int indice = 0; indice < 4; indice++)
            {
                string numero = Console.ReadLine();

                array[indice] = int.Parse(numero);
            }

            Console.WriteLine(array.Max());

        }
    }
}
