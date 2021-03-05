using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaraOEscudo_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //int cantidad = int.MaxValue;
            //bool[,] matrix =
            //{
            //    {true, false, false, false, false },
            //    {false, false, false, false, false },
            //    {true, false, false, false, false },
            //    {false, false, false, false, false }
            //};

            //Resuelve(matrix, ref cantidad, 0, 0, 0);
            //Console.WriteLine(cantidad);


            #endregion
            #region Prueba2

            //int cantidad = int.MaxValue;

            //bool[,] matrix =
            //{
            //    {false, false, false, false, false },
            //    {false, false, false, false, false },
            //    {false, false, false, true, true },
            //    {false, false, false, true, true }
            //};

            //Resuelve(matrix, ref cantidad, 0, 0, 0);
            //Console.WriteLine(cantidad);


            #endregion
            #region Prueba3

            //int cantidad = int.MaxValue;

            //bool[,] matrix =
            //{
            //    {true, true, false, false, false },
            //    {true, true, false, false, false },
            //    {false, false, false, true, true },
            //    {false, true, false, true, true }
            //};

            //Resuelve(matrix, ref cantidad, 0, 0, 0);
            //Console.WriteLine(cantidad);

            #endregion



        }

        public static void Resuelve(bool[,] matriz, ref int mejor, int fila, int columna, int llamado)
        {
            if (EstaResuelto(matriz))
            {
                if (llamado < mejor)
                    mejor = llamado;
                return;
            }
           
            for(int primerIndice = fila; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = columna; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    Resuelve(Golpea(matriz, primerIndice, segundoIndice), ref mejor, primerIndice, segundoIndice + 1, llamado + 1);
                }
                columna = 0;
            }
        }
        public static bool[,] Golpea(bool[,] matrix, int fila, int columna)
        {
            bool[,] copia = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    copia[primerIndice, segundoIndice] = matrix[primerIndice, segundoIndice];
                }
            }
            if (EsValido(copia, fila - 1, columna))
                copia[fila - 1, columna] = !copia[fila - 1, columna];
            if (EsValido(copia, fila, columna + 1))
                copia[fila, columna + 1] = !copia[fila, columna + 1];
            if (EsValido(copia, fila + 1, columna))
                copia[fila + 1, columna] = !copia[fila + 1, columna];
            if (EsValido(copia, fila, columna - 1))
                copia[fila, columna - 1] = !copia[fila, columna - 1];

            if (EsValido(matrix, fila - 1, columna - 1))
                copia[fila - 1, columna - 1] = !copia[fila - 1, columna - 1];
            if(EsValido(matrix, fila - 1, columna + 1))
                copia[fila - 1, columna + 1] = !copia[fila - 1, columna + 1];
            if (EsValido(matrix, fila + 1, columna + 1))
                copia[fila + 1, columna + 1] = !copia[fila + 1, columna + 1];
            if (EsValido(matrix, fila + 1, columna - 1))
                copia[fila + 1, columna - 1] = !copia[fila + 1, columna - 1];

            copia[fila, columna] = !copia[fila, columna];
            return copia;

        }
        public static bool EstaResuelto(bool[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    if (matrix[primerIndice, segundoIndice] != matrix[0, 0])
                        return false;
                }
            }
            return true;
        }
        public static bool EsValido(bool[,] matrix, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < matrix.GetLength(0) && columna < matrix.GetLength(1); }

    }
}
