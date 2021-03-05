using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParacaidistaExplorador
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mapa = {{3, 1, 9, 2, 1, 10}, 
                            {5, 0, 6, 7, 8, 11}, 
                            {7, 1, 1, 2, 15, 12},
                            {1, 5, 8, 11, 14, 7}};

            Console.WriteLine(Moverse(mapa, 3, 5, 3));
            // funciona a las 20 mil maravillas 
        }
        static int Moverse(int[,] tabla, int fil, int column, int capacidad)
        {
            int contador = 1;

            bool[,] tbBool = new bool[tabla.GetLength(0), tabla.GetLength(1)];

            Moverse(tbBool, tabla, fil, column, ref contador, capacidad);

            PrintMatrix(tbBool);

            return contador;
        }
        static void PrintMatrix(bool[,] matrix)
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
        static void Moverse(bool [,] tabBool, int[,] tablero, int fila, int columna, ref int contador, int K)
        {
            tabBool[fila, columna] = true;

            if (columna + 1 < tablero.GetLength(1) && Math.Abs(tablero[fila, columna + 1] - tablero[fila, columna]) <= K)
            {
                if (tabBool[fila, columna + 1] != true)
                {
                    contador++;
                    Moverse(tabBool, tablero, fila, columna + 1, ref contador, K);
                }                             
            }
            if ((columna - 1 >= 0) && Math.Abs(tablero[fila, columna - 1] - tablero[fila, columna]) <= K )
            {
                if (tabBool[fila, columna - 1] != true)
                {
                    contador++;
                    Moverse(tabBool, tablero, fila, columna - 1, ref contador, K);
                }
            }
            if ((fila + 1 < tablero.GetLength(0)) && Math.Abs(tablero[fila + 1, columna] - tablero[fila, columna]) <= K)
            {
                if (tabBool[fila + 1, columna] != true)
                {
                    contador++;
                    Moverse(tabBool, tablero, fila + 1, columna, ref contador, K);
                }
            }
            if ((fila - 1 >= 0) && Math.Abs(tablero[fila - 1, columna] - tablero[fila, columna]) <= K)
            {
                if (tabBool[fila - 1, columna] != true)
                {
                    contador++;
                    Moverse(tabBool, tablero, fila - 1, columna, ref contador, K);
                }
            }
        }
    }
}
