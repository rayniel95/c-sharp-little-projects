using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticionBalanceada
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 23, 45, -34, 12, 0, 98, -99, 4, 189, -1, 4 };
            int min = int.MaxValue;

            Variaciones(myArray, 0, myArray.Length, ref min);
            Console.WriteLine(min);
        }
        static void Variaciones(int[] array, int posicion, int numeroACombinar, ref int minimo)
        {
            if (posicion == numeroACombinar)
            {
                for (int indice = 0; indice < array.Length; indice++)
                {
                    int[] primero = new int[indice + 1];
                    int[] segundo = new int[array.Length - indice - 1];

                    Array.Copy(array, primero, primero.Length);
                    Array.Copy(array, indice + 1, segundo, 0, segundo.Length);

                    int factor = Math.Abs(primero.Sum() - segundo.Sum());

                    if (factor < minimo)
                    {
                        minimo = factor;
                    }
                        
                }
            }
            else
            {
                for (int indice = posicion; indice < array.Length; indice++)
                {
                    int temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                    Variaciones(array, posicion + 1, numeroACombinar, ref minimo);
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
        }
    }
}
