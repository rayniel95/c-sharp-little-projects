using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicandoPiezas_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //bool[][,] piezas = new bool[][,]
            //{
            //    new bool[,]
            //    {
            //        {false, true, true },
            //        {true , true, false}
            //    },

            //    new bool[,]
            //    {
            //        {true, false, false},
            //        {true, true, true },
            //        {true, false, false}
            //    },

            //    new bool[,]
            //    {
            //        {true, true},
            //        {true, true}
            //    }
            //};

            //Console.WriteLine(SePuedeUbicar(piezas, 3, 4));
            #endregion
            #region Prueba2
            // bool[][,] piezas = new bool[][,]
            //{
            //       new bool[,]
            //       {
            //           {false, true, true },
            //           {true , true, false}
            //       },

            //       new bool[,]
            //       {
            //           {true, false, false},
            //           {true, true, true },
            //           {true, false, false}
            //       },

            //       new bool[,]
            //       {
            //           {true, true},
            //           {true, true}
            //       }
            //};

            // Console.WriteLine(SePuedeUbicar(piezas, 4, 5));

            #endregion
            #region Prueba3
            //bool[][,] piezas = new bool[][,]
            //{
            //     new bool[,]
            //     {
            //         {false, true, true },
            //         {true , true, false}
            //     },

            //     new bool[,]
            //     {
            //         {true, false, false},
            //         {true, true, true },
            //         {true, false, false}
            //     },

            //     new bool[,]
            //     {
            //         {true, true},
            //         {true, true}
            //     }
            //};

            //Console.WriteLine(SePuedeUbicar(piezas, 5, 3));

            #endregion
         
        }
        public static bool SePuedeUbicar(bool[][,] piezas, int ancho, int largo)
        {
            if (Ubica(piezas, new bool[ancho, largo], 0)) return true;
            return false;
        }
        public static bool Ubica(bool[][,] piezas, bool[,] matriz, int indice)
        {
            if (indice >= piezas.Length)
                return true;

            for(int pieza = indice; pieza < piezas.Length; pieza++)
            {
                for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
                {
                    for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                    {
                        if (matriz[primerIndice, segundoIndice]) continue;
                        bool[,] nuevaMatrix = UbicaPieza(matriz, primerIndice, segundoIndice, piezas[pieza]);

                        if (nuevaMatrix == null) continue;
                       
                        if (Ubica(piezas, nuevaMatrix, pieza + 1))
                            return true;
                    }
                }
                break;
            }
            return false;
        }
        public static bool[,] UbicaPieza(bool[,] matrix, int fila, int columna, bool[,] pieza)
        {
            if (fila + pieza.GetLength(0) - 1 >= matrix.GetLength(0) || columna + pieza.GetLength(1) - 1 >= matrix.GetLength(1)) return null;

            bool[,] copia = CopiaMatrix(matrix);

            for (int primerIndice = 0; primerIndice < pieza.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < pieza.GetLength(1); segundoIndice++)
                {
                    if (matrix[primerIndice + fila, segundoIndice + columna] && pieza[primerIndice, segundoIndice]) return null;
                    copia[primerIndice + fila, segundoIndice + columna] = pieza[primerIndice, segundoIndice];
                }
            }
            return copia;
        }
        public static bool[,] CopiaMatrix(bool[,] matrix)
        {
            bool[,] nueva = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    nueva[primerIndice, segundoIndice] = matrix[primerIndice, segundoIndice];
                }
            }
            return nueva;
        }
    }
}
