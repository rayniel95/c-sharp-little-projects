using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoSeguroRey_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //bool[,] tablero =
            //{
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, true, false, true, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, true, false, false, false, false, false },
            //    {true, false, false, false, false, true, false, true },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, true, false, false, false, false, false },
            //    {false, false, false, false, true, false, false, false }
            //};

            //Console.WriteLine(CaminoMasCorto(tablero));



            #endregion
            #region Prueba2

            //bool[,] tablero =
            //{
            //    {false, false, false, false, false, false, false, false },
            //    {true, true, true, true, true, true, true, true },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false }
            //};

            //Console.WriteLine(CaminoMasCorto(tablero));

            #endregion
            #region Prueba3

            //bool[,] tablero =
            //{
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false },
            //    {true, true, true, true, true, true, false, false },
            //    {false, false, false, false, false, false, false, true },
            //    {false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, true },
            //    {false, false, false, false, false, false, false, false }
            //};

            //Console.WriteLine(CaminoMasCorto(tablero));

            #endregion




        }



        public static int CaminoMasCorto(bool[,] matrix)
        {
            int[,] tab = new int[matrix.GetLength(0), matrix.GetLength(1)];

            int[] filaMov = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] columnaMov = { -1, 0, 1, 1, 1, 0, -1, -1 };

            for(int primerIndice = 0; primerIndice < tab.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < tab.GetLength(1); segundoIndice++)
                {
                    if (matrix[primerIndice, segundoIndice])
                        tab[primerIndice, segundoIndice] = -1;
                }
            }


            Resuelve(tab, filaMov, columnaMov, matrix.GetLength(0) - 1, 0, 1);

            PrintTablero(tab);
            if (tab[0, matrix.GetLength(1) - 1] == 0)
                return -1;

            return tab[0, matrix.GetLength(1) - 1];
        }
        public static void Resuelve(int[,] tablero, int[] movFila, int[] movColumna, int fila, int columna, int llamado)
        {
            tablero[fila, columna] = llamado;

            if(fila == 5 && columna == 7)
            {

            }
            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];


                if(EsValido(tablero, nuevaFila, nuevaColumna) && !Amenazado(tablero, nuevaFila, nuevaColumna) && 
                    (tablero[nuevaFila, nuevaColumna] == 0 || tablero[nuevaFila, nuevaColumna] > llamado || tablero[nuevaFila, nuevaColumna] == -1))
                {
                    bool hayPeon = false;
                    if (tablero[nuevaFila, nuevaColumna] == -1)
                        hayPeon = true;

                    Resuelve(tablero, movFila, movColumna, nuevaFila, nuevaColumna, llamado + 1);

                    if (hayPeon)
                        tablero[nuevaFila, nuevaColumna] = -1;

                }
            }
        }
        public static void PrintTablero(int[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    Console.Write(matrix[primerIndice, segundoIndice] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static bool Amenazado(int[,] matrix, int fila, int columna)
        {
            return (EsValido(matrix, fila - 1, columna - 1) && matrix[fila - 1, columna - 1] == -1) || (EsValido(matrix, fila - 1, columna + 1) &&
                matrix[fila - 1, columna + 1] == -1) || (EsValido(matrix, fila + 1, columna + 1) && matrix[fila + 1, columna + 1] == -1) || 
                (EsValido(matrix, fila + 1, columna - 1) && matrix[fila + 1, columna - 1] == -1);
        }
        public static bool EsValido(int[,] matrix, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < matrix.GetLength(0) && columna < matrix.GetLength(1); }
    } 
}
