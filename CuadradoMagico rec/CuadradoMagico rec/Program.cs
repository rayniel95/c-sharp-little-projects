using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuadradoMagico_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CuadradoMagico(new int[3, 3], new int[] { 7, 5, 4, 1, 3, 2, 21, 6, 8 }));
        }
        public static bool CuadradoMagico(int[,] matriz, int[] numeros)
        {
            int[,] myMatrix = new int[matriz.GetLength(0), matriz.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    myMatrix[primerIndice, segundoIndice] = -1;
                }
            }
            if (Resuelve(myMatrix, 0, numeros))
                return true;
            return false;
        }
        public static bool Resuelve(int[,] matriz, int indice, int[] numeros)
        {
            if (SumaIgual(matriz))
            {
                PrintMatrix(matriz);
                return true;
            }
            else if (indice == numeros.Length)
                return false;

            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    if(matriz[primerIndice, segundoIndice] == -1)
                    {
                        int[,] copiaMatrix = CopiaMatrix(matriz);
                        copiaMatrix[primerIndice, segundoIndice] = numeros[indice];
                        if (Resuelve(copiaMatrix, indice + 1, numeros))
                            return true;
                    }
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
        public static int[,] CopiaMatrix(int[,] matrix)
        {
            int[,] myMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    myMatrix[primerIndice, segundoIndice] = matrix[primerIndice, segundoIndice];
                }

            }
            return myMatrix;
        }

        private static bool SumaIgual(int[,] matriz)
        {
            int suma = 0;
            int sumaAnterior = int.MinValue;
            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    if (matriz[primerIndice, segundoIndice] == -1)
                        return false;
                    suma += matriz[primerIndice, segundoIndice];
                }
                if (sumaAnterior == int.MinValue)
                    sumaAnterior = suma;
                else if (suma != sumaAnterior)
                    return false;
                suma = 0;
            }
            sumaAnterior = int.MinValue;
            for (int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    suma += matriz[segundoIndice, primerIndice];
                }
                if (sumaAnterior == int.MinValue)
                    sumaAnterior = suma;
                else if (suma != sumaAnterior)
                    return false;
                suma = 0;
            }
            return true;

        }
    }
}
