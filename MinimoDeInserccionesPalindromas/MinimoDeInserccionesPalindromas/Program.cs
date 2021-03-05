using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimoDeInserccionesPalindromas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinimoInsercciones("abcb"));
        }
        static int MinimoInsercciones(string cadena)
        {
            int contador = 0;

            int mitad = cadena.Length / 2;

            MinimoInsercciones(cadena, 0, mitad, cadena.Length - 1, ref contador);

            return contador;
        }
        static void MinimoInsercciones(string myString, int inferior, int medio, int superior, ref int inserciones)
        {
            if (myString[inferior] != myString[superior] && (medio != inferior || medio != superior))
                inserciones++;

            if (inferior == medio || medio == superior)
                return;

            MinimoInsercciones(myString, inferior + 1, medio, superior - 1, ref inserciones);
        }
    }
}
