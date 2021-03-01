using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoIngles
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            int casos = int.Parse(Console.ReadLine());

            string[] palabras = new string[casos];

            for (int veces = 0; veces < casos; veces++)
            {
                palabras[veces] = Console.ReadLine();
            }

            int[] numeros = new int[casos];

            for (int veces = 0; veces < numeros.Length; veces++)
            {
                numeros[veces] = Numeros(palabras[veces]);
            }

            foreach (int element in numeros)
                Console.WriteLine(element);

        }
        static int Numeros(string cadena)
        {
            if (cadena.Length == 5)
                return 3;
            else
            {
                int cuantos = 0;
                for (int indice = 0; indice < cadena.Length; indice++)
                {
                    if (cadena[indice] != "one"[indice])
                        cuantos++;
                }
                if (cuantos == 1)
                    return 1;
                return 2;
            }
        }

    }
}
