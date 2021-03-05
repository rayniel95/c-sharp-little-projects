using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyLamp_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            ////bool[,] myMatriz =
            ////{
            ////    {false, true, false, true, false, false },
            ////    {true, false, true, false, true, false },
            ////    {false, true, true, false, false, true },
            ////    {false, false, false, false, false, true }
            ////};
            ////PrintArray(Resuelve(myMatriz));


            #endregion
            #region Prueba2

            //bool[,] myMatriz =
            //{
            //    {false, true, false, true, false, false },
            //    {true, true, true, false, true, false },
            //    {false, true, true, false, false, true },
            //    {false, false, true, false, false, true }
            //};
            //PrintArray(Resuelve(myMatriz));


            #endregion
            #region Prueba3

            //bool[,] myMatriz =
            //{
            //    {true, true, false, true, false, false },
            //    {true, false, true, true, true, false },
            //    {false, true, true, true, false, true },
            //    {true, false, true, true, true, true },
            //    {true, false, false, false, false, false },
            //    {false, true, false, true, false, false },
            //    {false, true, false, true, true, true},
            //    {false, true, true, true, false, false }
            //};
            //PrintArray(Resuelve(myMatriz));


            #endregion
            #region Prueba4

            bool[,] myMatriz =
            {
                {false, true, false, true, true, true },
                {true, false, true, true, true, false },
                {false, true, true, true, false, true },
                {true, false, true, true, true, true },
                {true, false, false, false, false, false },
                {false, true, false, true, false, false },
                {false, true, false, true, true, true},
                {false, true, true, true, false, false }
            };
            PrintArray(Resuelve(myMatriz));


            #endregion
        }

        public static int[] Resuelve(bool[,] matrix)
        {
            int[] myMejor = new int[0];

            int[] interruptores = new int[matrix.GetLength(0)];

            for(int interruptor = 0; interruptor < interruptores.Length; interruptor++)
            {
                interruptores[interruptor] = interruptor;
            }

            for(int cantidad = 1; cantidad <= matrix.GetLength(0); cantidad++)
            {
                if (Combinaciones(interruptores, new int[cantidad], 0, 0, ref myMejor, matrix))
                    break;
            }
            return myMejor;
        }
        public static bool Combinaciones(int[] array, int[] combinaciones, int posArray, int posCombinacion, ref int[] mejor, bool[,] matriz)
        {
            if (posCombinacion == combinaciones.Length)
            {
                bool[] lamparas = new bool[matriz.GetLength(1)];

                foreach(var interruptor in combinaciones)
                {
                    for(int lampara = 0; lampara < matriz.GetLength(1); lampara++)
                    {
                        if(matriz[interruptor, lampara])
                        {
                            lamparas[lampara] = !lamparas[lampara];
                        }
                    }
                }

                if (!lamparas.Contains(false))
                {
                    mejor = combinaciones;
                    return true;
                }

            }
            else if (posArray == array.Length) return false;
            else
            {
                combinaciones[posCombinacion] = array[posArray];
                if(Combinaciones(array, combinaciones, posArray + 1, posCombinacion + 1, ref mejor, matriz)) { return true; }
                if(Combinaciones(array, combinaciones, posArray + 1, posCombinacion, ref mejor, matriz)) { return true; }
            }
            return false;
        }
        public static void PrintArray(int[] array)
        {
            foreach(var el in array)
            {
                Console.Write(el);
                Console.WriteLine();
            }
        }
    }
}
