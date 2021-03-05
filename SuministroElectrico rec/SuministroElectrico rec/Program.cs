using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuministroElectrico_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMatrix(UbicaCentrales(new int[] { 2, 1, 2, 1, 3, 1, 1, 1 }, 8, 8));
        }
        public static int[,] UbicaCentrales(int[] centrales, int filas, int columnas)
        {
            int[,] myMatriz = new int[filas, columnas];
            for(int primerIndice = 0; primerIndice < myMatriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice< myMatriz.GetLength(1); segundoIndice++)
                {
                    myMatriz[primerIndice, segundoIndice] = -1;
                }
            }
    
            int[,] matrizVacia = new int[myMatriz.GetLength(0), myMatriz.GetLength(1)];
            Resuelve(myMatriz, 0, 0, 0, matrizVacia, centrales);
            return matrizVacia;
        }
        public static bool Resuelve(int[,] matrix, int fila, int columna, int indiceCentral, int[,] resultado, int[] centrales)
        {
            if(EstaResuelto(matrix))
            {
                resultado = matrix;
                PrintMatrix(matrix);
                return true;
            }
            for(int indice = indiceCentral; indice < centrales.Length; indice++)
            {
                for(int primerIndice = fila; primerIndice<matrix.GetLength(0); primerIndice++)
                {
                    for(int segundoIndice=columna; segundoIndice<matrix.GetLength(1); segundoIndice++)
                    {
                        int[,] matrizPintada = PonCentral(matrix, primerIndice, segundoIndice, indice, centrales[indice]);

                        if(matrizPintada != null)
                        {
                            if (Resuelve(matrizPintada, primerIndice, segundoIndice + 1, indice + 1, resultado, centrales))
                                return true;
                        }
                    }
                }
                columna = 0;
            }
            return false;
        }
        public static bool EstaResuelto(int[,] matriz)
        {
            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    if (matriz[primerIndice, segundoIndice] == -1)
                        return false;
                }
            }
            return true;
        }
        public static int[,] PonCentral(int[,] matriz, int fila, int columna, int central, int radio)
        {
            int[,] copia = CopiaMatrix(matriz);
            for(int primerIndice = fila - radio; primerIndice <= fila + radio; primerIndice++)
            {
                for(int segundoIndice = columna - radio; segundoIndice <= columna + radio; segundoIndice++)
                {
                    if(EsValido(primerIndice, segundoIndice, matriz))
                    {
                        if (matriz[primerIndice, segundoIndice] != -1)
                            return null;
                        copia[primerIndice, segundoIndice] = central;
                    }
                }
            }
            return copia;
        }
        public static bool EsValido(int fila, int columna, int[,] matrix)
        {
            return fila >= 0 && fila < matrix.GetLength(0) && columna >= 0 && columna < matrix.GetLength(1);
        } 
        public static int[,] CopiaMatrix(int[,] matrix)
        {
            int[,] copia = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for(int primerIndice = 0; primerIndice<matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    copia[primerIndice, segundoIndice] = matrix[primerIndice, segundoIndice];
                }
            }
            return copia;
        }
        public static void PrintMatrix(int[,] matriz)
        {
            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    Console.Write(matriz[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }
    }
}
