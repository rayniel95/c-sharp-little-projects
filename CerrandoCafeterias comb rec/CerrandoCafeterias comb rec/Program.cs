using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerrandoCafeterias_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //int[,] capacidad =
            //{
            //    {10, 0, 0, 5, 20 },
            //    {10, 10, 0, 5, 20 },
            //    {20, 10, 0, 5, 20 },
            //    {20, 10, 30, 10, 20 },
            //    {20, 10, 30, 10, 30 },
            //    {20, 10, 30, 5, 20 },
            //    {10, 10, 0, 5, 20 },
            //    {10, 0, 0, 5, 20 }
            //};

            //int[,] real =
            //{
            //    {5, 0, 0, 1, 0 },
            //    {5, 5, 0, 5, 5 },
            //    {5, 5, 0, 4, 8 },
            //    {10, 5, 7, 8, 10 },
            //    {10, 5, 8, 10, 10 },
            //    {5, 5, 8, 3, 10 },
            //    {5, 5, 0, 3, 5 },
            //    {5, 0, 0, 1, 2 }
            //};

            //Console.WriteLine(MayorACerrar(capacidad, real));

            #endregion
            #region Prueba2
            //int[,] matrixCapacidad =
            //{
            //    {10, 0, 20 },
            //    {10, 10, 20 },
            //    {20, 15, 20 },
            //    {20, 15, 20 },
            //    {20, 15, 30 },
            //    {20, 10, 20 },
            //    {10, 10, 20 },
            //    {10, 0, 20 }
            //};

            //int[,] matrixReal =
            //{
            //    {5, 0, 0 },
            //    {5, 5, 5 },
            //    {5, 5, 8 },
            //    {10, 15, 18 },
            //    {10, 5, 10 },
            //    {5, 5, 10 },
            //    {5, 5, 5 },
            //    {5, 0, 5 }
            //};

            //Console.WriteLine(MayorACerrar(matrixCapacidad, matrixReal));

            #endregion
            #region Prueba3
            //int[,] capacidad =
            //{
            //    {10, 0 },
            //    {10, 10 },
            //    {20, 15 },
            //    {20, 15 },
            //    {20, 15 },
            //    {20, 10 },
            //    {10, 10 },
            //    {10, 0 }
            //};

            //int[,] real =
            //{
            //    {5, 0 },
            //    {5, 5 },
            //    {5, 12 },
            //    {10, 10 },
            //    {10, 5 },
            //    {5, 5 },
            //    {5, 5 },
            //    {5, 0 }
            //};

            //Console.WriteLine(MayorACerrar(capacidad, real));

            #endregion
            #region Prueba4
            //int[,] capacidad =
            //{
            //    {10, 0, 20 },
            //    {10, 10, 20 },
            //    {20, 15, 20 },
            //    {20, 15, 20 },
            //    {20, 15, 30 },
            //    {20, 10, 20 },
            //    {10, 10, 20 },
            //    {10, 0, 20 }
            //};

            //int[,] real =
            //{
            //    {0, 0, 0 },
            //    {0, 0, 0 },
            //    {0, 0, 0 },
            //    {0, 0, 0 },
            //    {0, 0, 0 },
            //    {0, 0, 0 },
            //    {0, 0, 0 },
            //    {0, 0, 0 }
            //};

            //Console.WriteLine(MayorACerrar(capacidad, real));

            #endregion
            #region Prueba5
            //int[,] capacidad =
            //{
            //    {10, 8 },
            //    {10, 10 },
            //    {20, 15 },
            //    {20, 15 },
            //    {20, 15 },
            //    {20, 10 },
            //    {10, 10 },
            //    {10, 8 }
            //};
            //int[,] real =
            //{
            //    {5, 2 },
            //    {5, 5 },
            //    {5, 7 },
            //    {7, 8 },
            //    {9, 5 },
            //    {5, 5 },
            //    {5, 5 },
            //    {5, 3 }
            //};

            //Console.WriteLine(MayorACerrar(capacidad, real));

            #endregion


        }
        public static int MayorACerrar(int[,] cafeteriasCapacidad, int[,] cafeteriasCapacidadReal)
        {
            List<int> myIndices = new List<int>();

            for (int indice = 0; indice < cafeteriasCapacidad.GetLength(1); indice++)
                myIndices.Add(indice);

            for(int veces = myIndices.Count; veces > 0; veces--)
            {
                int cantidad = Combina(myIndices.ToArray(), new int[veces], 0, 0, cafeteriasCapacidadReal, cafeteriasCapacidad);
                if (cantidad != -1) return cantidad;
            }
            return -1;
        }

        public static int Combina(int[] indices, int[] indicesCerrar, int posIndices, int posCerrar, int[,] capacidad, int[,] real)
        {
            if (posCerrar == indicesCerrar.Length)
            {
                if (EsPosibleCerrar(capacidad, real, indicesCerrar))
                    return indicesCerrar.Length;
            }
            else if (posIndices == indices.Length) return -1;
            else
            {
                indicesCerrar[posCerrar] = indices[posIndices];

                int primero = Combina(indices, indicesCerrar, posIndices + 1, posCerrar + 1, capacidad, real);

                if (primero != -1) return primero;

                int segundo = Combina(indices, indicesCerrar, posIndices + 1, posCerrar, capacidad, real);

                if (segundo != -1) return segundo;
            }
            return -1;
        }
        public static bool EsPosibleCerrar(int[,] matrixCapacidad, int[,] matrixReal, int[] indicesCerrar)
        {
            for(int primerIndice = 0; primerIndice < matrixReal.GetLength(0); primerIndice++)
            {
                int suma = 0;
                int sumaReal = 0;
                for(int segundoIndice = 0; segundoIndice < matrixReal.GetLength(1); segundoIndice++)
                {
                    suma += matrixCapacidad[primerIndice, segundoIndice];
                    if (!indicesCerrar.Contains(segundoIndice)) sumaReal += matrixReal[primerIndice, segundoIndice];

                }
                if (suma > sumaReal) return false;
            }
            return true;
        }

    }
}
