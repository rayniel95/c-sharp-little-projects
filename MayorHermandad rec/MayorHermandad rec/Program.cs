using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayorHermandad_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] matriz =
            {
                {false, true , true },
                {false, false, true },
                {false, false, false},
            };
            foreach(var el in MayorHermandad(matriz))
                Console.WriteLine(el);
                


        }
        public static int[] MayorHermandad(bool[,] myMatriz)
        {
            int[] myArray = new int[myMatriz.GetLength(0)];
            for(int indice = 0; indice < myArray.Length; indice++)
            {
                myArray[indice] = indice;
            }
            int[] hermandad = new int[0];

            for(int indice = myArray.Length; indice > 1; indice--)
            {
                Combinaciones(myArray, new int[indice], 0, 0, ref hermandad, myMatriz);
            }
            return hermandad;
        }

        public static void Combinaciones(int[] array, int[] combinacion, int posArray, int posCombinacion, ref int[] mayorHermandad, bool[,] matriz)
        {
            if (posCombinacion == combinacion.Length)
            {
                foreach(int indice in combinacion)
                {
                    for(int columna = 0; columna < matriz.GetLength(1); columna++)
                    {
                        if (columna != indice && !matriz[indice, columna] && combinacion.ToList().Contains(columna))
                            return;
                 
                    }
                }
                if(mayorHermandad.Length == 0)
                {
                    mayorHermandad = new int[combinacion.Length];
                    combinacion.CopyTo(mayorHermandad, 0);
                }

            }
            else if (posArray == array.Length)
                return;
            else
            {
                combinacion[posCombinacion] = array[posArray];
                Combinaciones(array, combinacion, posArray + 1, posCombinacion + 1, ref mayorHermandad, matriz);
                Combinaciones(array, combinacion, posArray + 1, posCombinacion, ref mayorHermandad, matriz);
            }
        }
    }
}
