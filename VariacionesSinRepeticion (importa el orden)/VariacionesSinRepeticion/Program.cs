using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] miArray = new int[3];
            for (int indice = 0; indice < miArray.Length; indice++)
                miArray[indice] = indice;

            int[] myArray = {23, 45, -34, 12, 0, 98, -99, 4, 189, -1, 4};
            VariacionesSinRepeticion(myArray, myArray.Length);
        }
        static void VariacionesSinRepeticion(int[] myArray, int numero)
        {
            VariacionesSinRepeticion(myArray, 0, numero);
        }
        static void PrintSet(int[] ElArray)
        {
            for (int indice = 0; indice < ElArray.Length; indice++)
                Console.Write(ElArray[indice]);
            Console.WriteLine();
        }
        static void VariacionesSinRepeticion(int[] array, int posicion, int numeroACombinar)
        {
            if (posicion == numeroACombinar)
            {
                int[] myArray = new int[numeroACombinar];

                Array.Copy(array, myArray, numeroACombinar);

                PrintSet(array);
            }
            else
            {
                for (int indice = posicion; indice < array.Length; indice++)
                {
                    int temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                    VariacionesSinRepeticion(array, posicion + 1, numeroACombinar);
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
        }
    }
}
