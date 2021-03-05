using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximizarSiembra_rec
{
    class Program
    {
        public static void PrintMatrix(int[,] matriz)
        {
            for(int primerIndice = 0; primerIndice<matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice<matriz.GetLength(1); segundoIndice++)
                {
                    Console.Write(matriz[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }
        public static bool EsValido(int fila, int columna, int[,] matriz)
        {
            return fila >= 0 && columna >= 0 && fila < matriz.GetLength(0) && columna < matriz.GetLength(1);
        }
        public static int CantidadSemillas(int[,] matriz)
        {
            int cantidad = 0;
            for(int primerIndice = 0; primerIndice<matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice<matriz.GetLength(1); segundoIndice++)
                {
                    if (matriz[primerIndice, segundoIndice] == 1)
                        return 0;
                    else if (matriz[primerIndice, segundoIndice] == 2)
                        cantidad++;
                }
            }
            return cantidad;
        }
        public static int[,] CopiaMatrix(int[,] matriz)
        {
            int[,] matrix = new int[matriz.GetLength(0), matriz.GetLength(1)];
            for(int primerIndice = 0; primerIndice<matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice<matriz.GetLength(1); segundoIndice++)
                {
                    matrix[primerIndice, segundoIndice] = matriz[primerIndice, segundoIndice];
                }
            }
            return matrix;
        }
        public static int[,] ReproduceNorteSur(int[,] matriz, int fila, int columna)
        {
            int[,] matrix = CopiaMatrix(matriz);

            if(EsValido(fila - 1, columna, matrix) && matrix[fila - 1, columna] != 1)
            {
                matrix[fila - 1, columna] += 2;
            }
            if (EsValido(fila + 1, columna, matrix) && matrix[fila + 1, columna] != 1)
                matrix[fila + 1, columna] += 2;
            matrix[fila, columna] = 3;
            return matrix;
        }
        public static int[,] ReproduceEsteOeste(int[,] matriz, int fila, int columna)
        {
            int[,] matrix = CopiaMatrix(matriz);

            if (EsValido(fila, columna - 1, matrix) && matrix[fila, columna - 1] != 1)
            {
                matrix[fila, columna - 1] += 2;
            }
            if (EsValido(fila, columna + 1, matrix) && matrix[fila, columna + 1] != 1)
                matrix[fila, columna + 1] += 2;
            matrix[fila, columna] = 3;
            return matrix;
        }
        public static int MaximaSiembra(int[,] matriz)
        {
            int myNumero = 0;
            Resuelve(matriz, ref myNumero, 0, 0);
            return myNumero;
        }
        public static int Resuelve(int[,] matrix, ref int mejor, int indiceFila, int indiceColumna)
        {
            int cantidadSemillas = CantidadSemillas(matrix);
            if (cantidadSemillas != 0)
            {
                Console.WriteLine();
                PrintMatrix(matrix);
                mejor = cantidadSemillas;
                return cantidadSemillas;
            }
            for(int primerIndice = indiceFila; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = indiceColumna; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    if (matrix[primerIndice, segundoIndice] == 1)
                    {
                        return Math.Max(Resuelve(ReproduceNorteSur(matrix, primerIndice, segundoIndice), ref mejor, primerIndice, segundoIndice + 1), 
                            Resuelve(ReproduceEsteOeste(matrix, primerIndice, segundoIndice), ref mejor, primerIndice, segundoIndice + 1));
          
                    }
                }
                indiceColumna = 0;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            int[,] myMatriz = { 
                                { 0, 1, 0, 1},
                                {0, 0, 1, 0 },
                                {1, 0, 1, 0 }
                               };
            int myNumber = 0;
            Console.WriteLine(Resuelve(myMatriz, ref myNumber, 0, 0));
            //Console.WriteLine(MaximaSiembra(myMatriz));
        }

    }
}
