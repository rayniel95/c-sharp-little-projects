using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaguaDesperfectos_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //bool[,] matrixTalleres =
            //{
            //    {false, false, false, false, true, false, false, false, false, false },
            //    {false, false, false, false, false, false, true, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false},
            //    {false, false, false, false, false, false, true, false, false, true},
            //    {false, false, false, false, false, false, false, false, false, false},
            //    {false, false, false, false, false, false, false, false, false, false},
            //    {false, false, false, false, false, false, false, false, false, false},
            //    {false, false, false, false, false, false, false, false, false, true},
            //    {false, false, false, true, false, false, false, false, false, false},
            //    {false, false, false, false, false, false, false, false, false, false},
            //};

            //int[,] matrixPersonas =
            //{
            //    {0 ,0 ,1 ,0 ,0, 1, 0, 0, 0, 0 },
            //    {0 ,0 ,1 ,0 ,1, 2, 0, 0, 0, 1 },
            //    {0 ,0 ,2 ,0 ,0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,2 ,0 ,0, 2, 0, 0, 0, 2 },
            //    {0 ,0 ,2 ,0 ,0, 0, 0, 0, 0, 2 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 2 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0 },
            //};

            //Console.WriteLine(CantidadPersonas(matrixPersonas, matrixTalleres));

            #endregion
            #region Prueba2

            //bool[,] matrixTalleres =
            //{
            //    {false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false },
            //    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            //};

            //int[,] matrixPersonas =
            //{
            //    {0 ,0 ,1 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,1 ,0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,2 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,1 ,0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            //    {0 ,0 ,0 ,2 ,0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,2 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            //    {0 ,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //};

            //Console.WriteLine(CantidadPersonas(matrixPersonas, matrixTalleres));

            #endregion


        }

        public static int CantidadPersonas(int[,] tableroPersonas, bool[,] tableroTalleres)
        {
            int[] filaMov = { 0, 1 };
            int[] columnaMov = { 1, 0 };

            int myMejor = 0;

            Resuelve(tableroPersonas, tableroTalleres, 0, 0, 0, 10, ref myMejor, filaMov, columnaMov);

            return myMejor;
        }
        public static void Resuelve(int[,] tabPersonas, bool[,] tabTalleres, int fila, int columna, int cantidadPersonas, int cantidadCuadras, ref int mejor, 
            int[] movFila, int[] movColumna)
        {
            if (fila == tabPersonas.GetLength(0) - 1 && columna == tabPersonas.GetLength(1) - 1)
            {
                if (cantidadPersonas > mejor)
                    mejor = cantidadPersonas;
                return;
            }
            else if (tabTalleres[fila, columna]) cantidadCuadras = 10;

            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if(EsValido(tabPersonas, nuevaFila, nuevaColumna) && cantidadCuadras > 0)
                {
                    Resuelve(tabPersonas, tabTalleres, nuevaFila, nuevaColumna, cantidadPersonas + tabPersonas[nuevaFila, nuevaColumna], 
                        cantidadCuadras - 1, ref mejor, movFila, movColumna);
                }
            }            

        }

        public static bool EsValido(int[,] matrix, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < matrix.GetLength(0) && columna < matrix.GetLength(1); }

    }
}
