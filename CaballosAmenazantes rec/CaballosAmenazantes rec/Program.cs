using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaballosAmenazantes_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //Console.WriteLine(MinimaCantidad(4));

            #endregion
            #region Prueba2

            //Console.WriteLine(MinimaCantidad(3));

            #endregion
            #region Prueba3

            //Console.WriteLine(MinimaCantidad(5));

            #endregion


        }


        public static int MinimaCantidad(int dimension)
        {
            int cantidad = int.MaxValue;

            Resuelve(new bool[dimension, dimension], new bool[dimension, dimension], 0, 0, 0, ref cantidad);

            if (cantidad == int.MaxValue)
                return -1;
            return cantidad;
        }
        public static void Resuelve(bool[,] matrizCaballos, bool[,] matrizMarcada, int llamado, int fila, int columna, ref int cantidadCaballos)
        {
            if(EstaResuelto(matrizMarcada))
            {
                if (CantidadCaballos(matrizCaballos) < cantidadCaballos)
                {
                    cantidadCaballos = CantidadCaballos(matrizCaballos);
                    PrintTablero(matrizCaballos);
                    Console.WriteLine();
                }
                return;
            }

            for(int primerIndice = fila; primerIndice < matrizCaballos.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = columna; segundoIndice < matrizCaballos.GetLength(1); segundoIndice++)
                {
                    bool[,] copiaCaballos = CopiaMatrix(matrizCaballos);
                    copiaCaballos[primerIndice, segundoIndice] = true;

                    bool[,] copiaMarcada = MarcaAmenazadas(matrizMarcada, primerIndice, segundoIndice);

                    Resuelve(copiaCaballos, copiaMarcada, llamado + 1, primerIndice, segundoIndice + 1, ref cantidadCaballos);

                }
                columna = 0;
            }

        }

        public static bool[,] MarcaAmenazadas(bool[,] matrix, int fila, int columna)
        {
            bool[,] copia = CopiaMatrix(matrix);

            int[] movFila = { -2, -2, -1, 1, 2, 2, -1, 1 };
            int[] movColumna = { -1, 1, 2, 2, -1, 1, -2, -2 };

            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if(nuevaFila >= 0 && nuevaFila < matrix.GetLength(0) && nuevaColumna >= 0 && nuevaColumna < matrix.GetLength(1))
                {
                    copia[nuevaFila, nuevaColumna] = true;
                }
            }
            return copia;
        }
        public static void PrintTablero(bool[,] tablero)
        {
            for(int primerIndice = 0; primerIndice < tablero.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < tablero.GetLength(1); segundoIndice++)
                {
                    Console.Write(tablero[primerIndice, segundoIndice] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static bool[,] CopiaMatrix(bool[,] matrix)
        {
            bool[,] nuevo = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    nuevo[primerIndice, segundoIndice] = matrix[primerIndice, segundoIndice];
                }
            }
            return nuevo;

        }
        public static int CantidadCaballos(bool[,] matrix)
        {
            int cantidad = 0;
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    if (matrix[primerIndice, segundoIndice]) cantidad++;
                }
            }
            return cantidad;
        }
        public static bool EstaResuelto(bool[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    if (!matrix[primerIndice, segundoIndice]) return false;
                }
            }
            return true;
        }

    }
}
