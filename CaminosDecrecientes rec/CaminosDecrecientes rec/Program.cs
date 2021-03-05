using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminosDecrecientes_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz = {
                    {7,   6,  6},
                    {9,  10,  5},
                    {12,  4,  4},
                    {9,   2,  3}
                };

            Console.WriteLine(NumeroCaminos(matriz, 1, 1, 3, 1));
        }
        public static int NumeroCaminos(int[,] matriz, int filaInicial, int columnaInicial, int filaFinal, int columnaFinal)
        {
            int numeroCaminos = 0;
            int[] filaMov = { -1, 0, 1, 0 };
            int[] columnaMov = { 0, 1, 0, -1 };
            Moverse(filaInicial, columnaInicial, filaFinal, columnaFinal, matriz, ref numeroCaminos, filaMov, columnaMov, new bool[matriz.GetLength(0), matriz.GetLength(1)]);
            return numeroCaminos;
        }
        public static bool EsValido(int fila, int columna, int[,] matriz)
        {
            return fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1);
        }
        public static void Moverse(int fila, int columna, int filaDestino, int columnaDestino, int[,] matrix, ref int numero, int[] movFila, int[] movColumna, bool[,] marcado)
        {
            if(fila == filaDestino && columna == columnaDestino)
            {
                numero++;
                return;
            }
            for(int indice =0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if (EsValido(nuevaFila, nuevaColumna, matrix) && matrix[nuevaFila, nuevaColumna] <= matrix[fila, columna] && !marcado[nuevaFila, nuevaColumna])
                {
                    marcado[nuevaFila, nuevaColumna] = true;
                    Moverse(nuevaFila, nuevaColumna, filaDestino, columnaDestino, matrix, ref numero, movFila, movColumna, marcado);
                    marcado[nuevaFila, nuevaColumna] = false;
                }
            }
        }
    }
}
