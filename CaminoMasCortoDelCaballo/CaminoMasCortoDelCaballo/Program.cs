using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoMasCortoDelCaballo
{
    class Program
    {
        static void Main(string[] args)
        {
            Moverse(5, 5, 0, 0, 3, 3);
        }
        static void Moverse(int dimensionFilas, int dimensionColumnas, int filaInicio, int columnaInicio, int destinoFila, int destinoColumna)
        {
            int[] movFila = { -1, 1, 2, 2, 1, -1, -2, -2 };
            int[] movColumna = { 2, 2, 1, -1, -2, -2, 1, -1 };

            int[,] myTablero = new int[dimensionFilas, dimensionColumnas];
            int maximo = int.MaxValue;

            Console.WriteLine(Moverse(myTablero, filaInicio, columnaInicio, destinoFila, destinoColumna, 1, movFila, movColumna, ref maximo, 1));

            PrintSudoku(myTablero);
        }
        static bool Moverse(int[,] tablero, int fila, int columna, int filaDestino, int columnaDestino, int numero, int[] arrayFila, int[] arrayColumna, ref int mejor, int llamado)
        {
            tablero[fila,columna] = numero;

            if (fila == filaDestino && columna == columnaDestino)
            {
                mejor = numero;
                return true;
            }

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValida(tablero, nuevaFila, nuevaColumna) && (tablero[nuevaFila, nuevaColumna] == 0 || tablero[nuevaFila, nuevaColumna] > numero + 1))
                {
                    if (Moverse(tablero, nuevaFila, nuevaColumna, filaDestino, columnaDestino, numero + 1, arrayFila, arrayColumna, ref mejor, llamado + 1))
                    {
                        if (llamado == 1)
                            continue;
   
                        return true;
                    }
                    tablero[nuevaFila, nuevaColumna] = 0;
                }

            }
            if (llamado == 1)
                return true;
       
            return false;
        }
        static bool EsValida(int[,] tabla, int fila, int columna)
        {
            return fila >= 0 && fila < tabla.GetLength(0) && columna >= 0 && columna < tabla.GetLength(1);
        }
        static void PrintSudoku(int[,] matrix)
        {
            for (int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    Console.Write(matrix[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }

    }
}
