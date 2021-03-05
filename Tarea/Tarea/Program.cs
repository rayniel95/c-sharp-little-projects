using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();

        }
        static void IO()
        {
            string cadena = Console.ReadLine();

            int[] myArray = new int[int.Parse(cadena) * 2];

            if(!Numeros(myArray, 0, 1))
            {
                Console.WriteLine("NO ES POSIBLE");
                return;
            }
            PrintArray(myArray);
        }
        static bool Numeros(int[] array, int contador, int numeroAPoner)
        {
            // No lo veas como dos mitades distintas
            if ((array.Length / 2) == contador)
                return true;
            for (int indice = 0; indice < array.Length; indice++)
            {
                if (EsValido(array, indice, numeroAPoner) && array[indice] == 0 && array[indice + numeroAPoner + 1] == 0)
                {

                    array[indice] = numeroAPoner;
                    array[indice + numeroAPoner + 1] = numeroAPoner;

                    if (Numeros(array, contador + 1, numeroAPoner + 1))
                        return true;
                    array[indice] = 0;
                    array[indice + numeroAPoner + 1] = 0;
                }
            }
            return false;
        }
        static bool EsValido(int[] myArray, int posicion, int numero)
        {
            return posicion + numero + 1 < myArray.Length;
        }
        static void PrintArray(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");
            Console.WriteLine();
        }
    }
}
