using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParacaidistaExplorador_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //int[,] area =
            //{
            //    {3, 1, 9, 2, 1, 10 },
            //    {5, 0, 6, 7, 8, 11 },
            //    {7, 1, 1, 2, 15, 12 },
            //    {1, 5, 8, 11, 14, 7 }
            //};

            //Console.WriteLine(MayorArea(area, 3, 1, 2));

            #endregion



        }

        public static int MayorArea(int[,] tablero, int maximo, int fila, int columna)
        {
            int area = 0;

            int[] filaMov = { -1, 0, 1, 0 };
            int[] columnaMov = { 0, 1, 0, -1 };

            Resuelve(tablero, fila, columna, filaMov, columnaMov, ref area, maximo, new bool[tablero.GetLength(0), tablero.GetLength(1)]);

            return area;
        }
        public static void Resuelve(int[,] terrenos, int fila, int columna, int[] movFila, int[] movColumna, ref int cantidad, int tope, bool[,] marcado)
        {
            cantidad++;
            marcado[fila, columna] = true;

            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if(EsValido(terrenos, nuevaFila, nuevaColumna) && 
                    Math.Abs(terrenos[fila, columna] - terrenos[nuevaFila, nuevaColumna]) <= tope && !marcado[nuevaFila, nuevaColumna])
                {
                    Resuelve(terrenos, nuevaFila, nuevaColumna, movFila, movColumna, ref cantidad, tope, marcado);
                }
            }
        }
        
        public static bool EsValido(int[,] matrix, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < matrix.GetLength(0) && columna < matrix.GetLength(1); }
    }
}
