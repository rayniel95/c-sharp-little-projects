using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximizaSiembra_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //bool[,] terreno =
            //{
            //    {false, true, false, true },
            //    {false, false, true, false },
            //    {true, false, true, false }
            //};

            //Console.WriteLine(MaximaSiembra(terreno));

            #endregion


        }

        public static int MaximaSiembra(bool[,] plantas)
        {
            int cantidad = 0;
            int[,] tablero = new int[plantas.GetLength(0), plantas.GetLength(1)];

            for (int primerIndice = 0; primerIndice < plantas.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < plantas.GetLength(1); segundoIndice++)
                {
                    if (plantas[primerIndice, segundoIndice])
                        tablero[primerIndice, segundoIndice] = 1;
                        
                }
            }

            Resuelve(tablero, 0, 0, 0, ref cantidad);

            return cantidad;

        }
        public static void Resuelve(int[,] terreno, int fila, int columna, int llamado, ref int mejor)
        {
            if(CicloAcabado(terreno))
            {
                if (CantidadSemillas(terreno) > mejor)
                    mejor = CantidadSemillas(terreno);
                return;
            }

            for(int primerIndice = fila; primerIndice < terreno.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = columna; segundoIndice < terreno.GetLength(1); segundoIndice++)
                {
                    if(terreno[primerIndice, segundoIndice] == 1)
                    {
                        Resuelve(ReproduceHorizontal(terreno, primerIndice, segundoIndice), primerIndice, segundoIndice + 1, llamado + 1, ref mejor);

                        Resuelve(ReproduceVertical(terreno, primerIndice, segundoIndice), primerIndice, segundoIndice + 1, llamado + 1, ref mejor);
                    }

                }
                columna = 0;
            }

        }

        public static int CantidadSemillas(int[,] matriz)
        {
            int cantidad = 0;
            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    if (matriz[primerIndice, segundoIndice] == 2)
                        cantidad++;
                }
            }
            return cantidad;
        }
        public static int[,] ReproduceHorizontal(int[,] matriz, int fila, int columna)
        {
            int[,] copia = CopiaMatrix(matriz);

            if (EsValido(matriz, fila, columna - 1) && matriz[fila, columna - 1] != 1)
                copia[fila, columna - 1] += 2;
            if (EsValido(matriz, fila, columna + 1) && matriz[fila, columna + 1] != 1)
                copia[fila, columna + 1] += 2;

            copia[fila, columna] += 3;

            return copia;
        }
        public static int[,] ReproduceVertical(int[,] matriz, int fila, int columna)
        {
            int[,] copia = CopiaMatrix(matriz);

            if (EsValido(matriz, fila - 1, columna) && matriz[fila - 1, columna] != 1)
                copia[fila - 1, columna] += 2;
            if (EsValido(matriz, fila + 1, columna) && matriz[fila + 1, columna] != 1)
                copia[fila + 1, columna] += 2;

            copia[fila, columna] += 3;

            return copia;
        }
        public static int[,] CopiaMatrix(int[,] matriz)
        {
            int[,] copia = new int[matriz.GetLength(0), matriz.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    copia[primerIndice, segundoIndice] = matriz[primerIndice, segundoIndice];
                }
            }
            return copia;
        }
        public static bool CicloAcabado(int[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    if (matrix[primerIndice, segundoIndice] == 1) return false;
                }
            }
            return true;
        }
        public static bool EsValido(int[,] tablero, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < tablero.GetLength(0) && columna < tablero.GetLength(1); }
    }
}
