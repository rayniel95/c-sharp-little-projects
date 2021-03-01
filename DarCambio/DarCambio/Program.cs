using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarCambio
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
            string[] denominaciones = Console.ReadLine().Split();

            int formas = 0;

            if (dato == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int[] myArray = new int[denominaciones.Length];

            for (int indice = 0; indice < myArray.Length; indice++)
            {
                myArray[indice] = int.Parse(denominaciones[indice]);
            }
            Cambiar(myArray, 0, ref formas, dato, myArray.Length - 1);

            Console.WriteLine(formas);

        }
        // hay que ver los casos en los  que sea cero, y si no hay monedas de a 1, etc
        static void Cambiar(int[] array, int cantidad, ref int numeroDeFormas, int numeroACambiar, int indiceAnterior)
        {
            if (cantidad == numeroACambiar)
            {
                numeroDeFormas++;
                return;
            }
            else
            {
                for (int indice = indiceAnterior; indice >= 0; indice--)
                {
                    if (array[indice] <= numeroACambiar && cantidad + array[indice] <= numeroACambiar)
                        Cambiar(array, cantidad + array[indice], ref numeroDeFormas, numeroACambiar, indice);
                }
            }
        }
    }
}
