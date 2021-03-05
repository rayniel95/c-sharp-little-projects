using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacionesConRepeticion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] miArray = new int[4];
            for (int indice = 0; indice < miArray.Length; indice++)
                miArray[indice] = indice;

            VariacionesConRepeticion(miArray, new int[7], 0);
        }
        static void PrintSet(int[] ElArray)
        {
            for (int indice = 0; indice < ElArray.Length; indice++)
                Console.Write(ElArray[indice]);
            Console.WriteLine();
        }
        static void VariacionesConRepeticion(int[] array, int[] variacion, int pos)
        {
            if (pos == variacion.Length)
            {
                PrintSet(variacion);
            }
            else
                for (int indice = 0; indice < array.Length; indice++)
                {
                    variacion[pos] = array[indice];
                    VariacionesConRepeticion(array, variacion, pos + 1);
                }
        }
    }
}
