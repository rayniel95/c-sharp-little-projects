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
            int[] miArray = new int[4];

            for (int indice = 0; indice < miArray.Length; indice++)
                miArray[indice] = indice;

            int numeroACombinar = 4;

            Combinaciones(miArray, new int[numeroACombinar], 0, 0); 
        }
        static void PrintSet(int[] ElArray)
        {
            for (int indice = 0; indice < ElArray.Length; indice++)
                Console.Write(ElArray[indice]);
            Console.WriteLine();
        }
        static void Combinaciones(int[] array, int[] combinacion, int posicionArray, int posicionCombinacion)
        {
            if (posicionCombinacion == combinacion.Length)
            {
                PrintSet(combinacion);
            }
            else if (posicionArray == array.Length)
                return;
            else
            {
                combinacion[posicionCombinacion] = array[posicionArray]; 

                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion + 1);
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion);
            }
        }
    }
}
