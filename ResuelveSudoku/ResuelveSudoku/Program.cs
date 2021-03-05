using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResuelveSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudo = {
                              {5, 4, 0, 3, 6, 2, 0, 9, 0},
                              {3, 0, 0, 0, 0, 7, 6, 8, 0},
                              {0, 6, 7, 1, 9, 0, 0, 5, 0},
                              {8, 2, 4, 0, 0, 0, 0, 0, 6},
                              {0, 5, 0, 6, 2, 0, 8, 1, 0},
                              {1, 9, 0, 8, 3, 0, 0, 0, 4},
                              {9, 0, 0, 2, 0, 6, 0, 7, 0},
                              {4, 0, 5, 0, 8, 0, 0, 0, 0},
                              {0, 7, 0, 5, 0, 3, 0, 0, 8}
                          };
            PrintSudoku(SudokuResuelto(sudo));

        }
        static int[,] SudokuResuelto(int[,] sudoku)
        {
            int[] array = new int[10];

            bool[,] tablaBool = new bool[sudoku.GetLength(0), sudoku.GetLength(1)];
            int contador = 0;
            for (int primerIndice = 0; primerIndice < sudoku.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < sudoku.GetLength(1); segundoIndice++)
                {
                    if (sudoku[primerIndice, segundoIndice] != 0)
                    {
                        tablaBool[primerIndice, segundoIndice] = true;
                        contador++;
                    }
                }
            }

            Sudoku(sudoku, tablaBool, contador, 0);

            return sudoku;
        }
        static bool Sudoku(int[,] mySudoku, bool[,] tabBool, int numerosBases, int contador)
        {
            if (81 - numerosBases == contador)
                return true;

            for (int primerIndice = 0; primerIndice < mySudoku.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < mySudoku.GetLength(1); segundoIndice++)
                {
                    if (!tabBool[primerIndice, segundoIndice] && mySudoku[primerIndice, segundoIndice] == 0)
                    {
                        for (int numero = 1; numero < 10; numero++)
                        {
                            if (CumpleReglas(mySudoku, primerIndice, segundoIndice, numero))
                            {
                                mySudoku[primerIndice, segundoIndice] = numero;

                                if (Sudoku(mySudoku, tabBool, numerosBases, contador + 1))
                                    return true;
                                mySudoku[primerIndice, segundoIndice] = 0;
                            }
                        }
                        //return false;
                    }
                }
            }
            return false;
        }
        static bool CumpleReglas(int[,] tablero, int fila, int columna, int numeroAPoner)
        {
            for (int nuevaColumna = 0; nuevaColumna < tablero.GetLength(1); nuevaColumna++)
            {
                if (tablero[fila, nuevaColumna] == numeroAPoner)
                    return false;
            }
            for (int nuevaFila = 0; nuevaFila < tablero.GetLength(0); nuevaFila++)
            {
                if (tablero[nuevaFila, columna] == numeroAPoner)
                    return false;
            }
            int Fila = 0;
            int Columna = 0;

            int topeFila = 3;
            int topeColumna = 3;

            if (3 <= fila && fila < 6)
            {
                Fila = 3;
                topeFila = 6;
            }
            else if (6 <= fila)
            {
                Fila = 6;
                topeFila = 9;
            }
            if (3 <= columna && columna < 6)
            {
                Columna = 3;
                topeColumna = 6;
            }
            else if (6 <= columna)
            {
                Columna = 6;
                topeColumna = 9;
            }
            for (int primerIndice = Fila; primerIndice < topeFila; primerIndice++)
            {
                for (int segundoIndice = Columna; segundoIndice < topeColumna; segundoIndice++)
                {
                    if (tablero[primerIndice, segundoIndice] == numeroAPoner)
                        return false;
                }
            }
            return true;

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