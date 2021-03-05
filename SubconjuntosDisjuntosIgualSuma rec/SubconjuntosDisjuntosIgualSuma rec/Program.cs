using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubconjuntosDisjuntosIgualSuma_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1
            //int[][] subconj = new int[2][];
            //int[] conjunto = { 24, 38, 18, 1, 34 };

            //if(HallaPrimero(conjunto, new List<int>(), 0, subconj))
            //    PrintArray(subconj);



            #endregion
            #region Prueba2

            //int[][] subconj = new int[2][];
            //int[] conjunto = { 2, 5, 21, 45, 50 };

            //if (HallaPrimero(conjunto, new List<int>(), 0, subconj))
            //    PrintArray(subconj);




            #endregion
            #region Prueba3

            //int[][] subconj = new int[2][];
            //int[] conjunto = { 34, 90, 38, 43, 60, 100, 83, 22, 26, 98 };

            //if (HallaPrimero(conjunto, new List<int>(), 0, subconj))
            //    PrintArray(subconj);


            #endregion
            #region Prueba4

            //int[][] subconj = new int[2][];
            //int[] conjunto = { 24, 38, 18, 1, 34 };

            //if (HallaPrimero(conjunto, new List<int>(), 0, subconj))
            //    PrintArray(subconj);

            #endregion
            #region Prueba5

            //int[][] subconj = new int[2][];
            //int[] conjunto = { 4, 1, 16, 2, 32, 64 };

            //if (HallaPrimero(conjunto, new List<int>(), 0, subconj))
            //    PrintArray(subconj);

            #endregion



        }


        public static bool HallaPrimero(int[] array, List<int> subconjunto, int myIndice, int[][] subconjuntos)
        {
            for(int indice = myIndice; indice < array.Length; indice++)
            {
                subconjunto.Add(array[indice]);
                if (HallaSegundo(subconjunto, new List<int>(), 0, array, subconjuntos))
                    return true;
                if (HallaPrimero(array, subconjunto, indice + 1, subconjuntos))
                    return true;
                subconjunto.RemoveAt(subconjunto.Count - 1);
            }
            return false;
        }

        public static bool HallaSegundo(List<int> subconjunto1, List<int> subconjunto2, int myIndice, int[] array, int[][] subconjuntos)
        {
            if(SumaIgual(subconjunto1, subconjunto2))
            {
                subconjuntos[0] = subconjunto1.ToArray();
                subconjuntos[1] = subconjunto2.ToArray();
                return true;
            }
            for(int indice = myIndice; indice < array.Length; indice++)
            {
                subconjunto2.Add(array[indice]);
                if(subconjunto2.Intersect(subconjunto1).Count() != 0)
                {
                    subconjunto2.RemoveAt(subconjunto2.Count - 1);
                    continue;
                }

                if (HallaSegundo(subconjunto1, subconjunto2, indice + 1, array, subconjuntos))
                    return true;

                subconjunto2.RemoveAt(subconjunto2.Count - 1);
            }
            return false;
        }
        public static void PrintArray(int[][] array)
        {
            for(int indice = 0; indice < array.Length; indice++)
            {
                foreach(var el in array[indice])
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine();
            }
        }
        public static bool SumaIgual(List<int> primero, List<int> segundo)
        {
            return primero.Sum() == segundo.Sum();
        }
    }
}
