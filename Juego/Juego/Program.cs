using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();   
        }
        static void IO()
        {
            int dato = int.Parse(Console.ReadLine());

            Console.WriteLine(NumeroDeFormas(dato));
        }
        static int NumeroDeFormas(int numero)
        {
            if (numero == 0 || numero == 1)
                return 1;
            return NumeroDeFormas(numero - 1) + NumeroDeFormas(numero - 2);
        }
    }
}
