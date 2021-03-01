using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonYLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            string myCadena = Console.ReadLine();

            Console.WriteLine(LetrasDistintas(myCadena));
        }
        static int LetrasDistintas(string cadena)
        {
            int contador = 0;

            for (int indice = 0; indice < cadena.Length; indice++)
            {
                if (cadena[indice].ToString() != "{" && cadena[indice].ToString() != "}" && cadena[indice].ToString() != " " && cadena[indice].ToString() != ",")
                {
                    cadena = cadena.Replace(cadena[indice], ' ');
                    contador++;
                }
            }
            return contador;
        }
    }
}
