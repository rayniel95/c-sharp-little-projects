using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinaciones_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Combinaciones(new bool[3], 0);
        }

        public static void Combinaciones(bool[] array, int indiceAnterior)
        {
            if(indiceAnterior >= array.Length)
            {
                PrintArray(array);
                return;
            }
            for(int indice = indiceAnterior; indice < array.Length; indice++)
            {
                array[indice] = true;
                Combinaciones(array, indice + 1);
                array[indice] = false;
                //Combinaciones(array, indice + 1);
            }
        }
        public static void PrintArray(bool[] array)
        {
            for(int indice = 0; indice < array.Length; indice++)
            {
                if(array[indice])
                    Console.Write(indice);
            }
            Console.WriteLine();
        }

    }
}
