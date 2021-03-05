using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JugandoConCodigos_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //int[,] myMatrix =
            //{
            //    {1, 3, 4, 9, 8 },
            //    {2, 4, 5, 0, 9 },
            //    {3, 5, 6, 1, 0 }
            //};

            //Console.WriteLine(Resuelve(myMatrix, 0));



            #endregion
            #region Prueba2

            //int[,] matrix =
            //{
            //    {8, 4, 0, 1 },
            //    {6, 3, 1, 1 },
            //    {10, 6, 5, 0 },
            //    {3, 3, 1, 0 }
            //};

            //Console.WriteLine(Resuelve(matrix, 0));


            #endregion





        }

        public static bool Resuelve(int[,] matriz, int indiceAnterior)
        {
            if(SumaIgual(matriz))
            {
                PrintMatrix(matriz);
                return true;
            }
            for(int indice = indiceAnterior; indice < matriz.GetLength(1); indice++)
            {
                if (VariacionesSinRepeticion(ExtraeColumna(matriz, indice), 0, matriz.GetLength(0), matriz, indice))
                    return true;

            }

            return false;

        }
        public static int[] ExtraeColumna(int[,] matrix, int indice)
        {
            int[] columna = new int[matrix.GetLength(0)];

            for(int fila = 0; fila < matrix.GetLength(0); fila++)
            {
                columna[fila] = matrix[fila, indice];
            }
            return columna;
        }

        public static bool SumaIgual(int[,] matriz)
        {
            int suma = 0;
            int sumaAnterior = -1;
            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    suma += matriz[primerIndice, segundoIndice];
                }
                if (sumaAnterior == -1) { sumaAnterior = suma; suma = 0; continue; }
                else if(suma != sumaAnterior)
                {
                    return false;
                }
                suma = 0;
            }
            return true;
        }

        public static void InsertaColumna(int[,] matrix, int indice, int[] columna)
        {
            for(int fila = 0; fila < matrix.GetLength(0); fila++)
            {
                matrix[fila, indice] = columna[fila];
            }
        }
        

        public static bool VariacionesSinRepeticion(int[] array, int posicion, int numeroACombinar, int[,] matrix, int myIndice)
        {
            if (posicion == numeroACombinar)
            {
                InsertaColumna(matrix, myIndice, array);
                if (Resuelve(matrix, myIndice + 1))
                    return true;
       
            }
            else
            {
                for (int indice = posicion; indice < array.Length; indice++)
                {
                    int temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                    if (VariacionesSinRepeticion(array, posicion + 1, numeroACombinar, matrix, myIndice))
                        return true;
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
            return false;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    Console.Write(matrix[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }
    }
}
