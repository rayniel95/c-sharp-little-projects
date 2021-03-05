using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoMasCorto
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[4, 4];

            Moverse(matrix, 2, 1, 1);
            PrintMatrix(matrix);
        }
        static void Moverse(int[,] tablero, int fila, int columna, int numero)
        {
            tablero[fila, columna] = numero;

            if(columna + 1 < tablero.GetLength(1))
            {
                if (tablero[fila, columna + 1] == 0 || tablero[fila, columna + 1] > numero + 1)
                    Moverse(tablero, fila, columna + 1, numero + 1);
            }
            if(columna - 1 >= 0)
            {
                if (tablero[fila, columna - 1] == 0 || tablero[fila, columna - 1] > numero + 1)
                    Moverse(tablero, fila, columna - 1, numero + 1);
            }
            if(fila + 1 < tablero.GetLength(0))
            {
                if (tablero[fila + 1, columna] == 0 || tablero[fila + 1, columna] > numero + 1)
                    Moverse(tablero, fila + 1, columna, numero + 1);
            }
            if(fila - 1 >= 0)
            {
                if (tablero[fila - 1, columna] == 0 || tablero[fila - 1, columna] > numero + 1)
                    Moverse(tablero, fila - 1, columna, numero + 1);
            }
        }
        static void PrintMatrix(int[,] matrix)
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
