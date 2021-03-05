using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubconjuntosDisjuntos_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //PrintParticion(HallaSubconjuntos(new int[] { 9, 3, 30, 15, 2, 7 }));

            #endregion
            #region Prueba2

            //PrintParticion(HallaSubconjuntos(new int[] { 2, 5, 21, 45, 50 }));

            #endregion
            #region Prueba3

            //PrintParticion(HallaSubconjuntos(new int[] { 34, 90, 38, 43, 60, 100, 83, 22, 26, 98 }));

            #endregion
            #region Prueba4

            //PrintParticion(HallaSubconjuntos(new int[] { 24, 38, 18, 1, 34 }));

            #endregion
            #region Prueba5

            //PrintParticion(HallaSubconjuntos(new int[] { 4, 1, 16, 2, 32, 64 }));

            #endregion


        }

        public static List<List<int>> HallaSubconjuntos(int[] conjunto)
        {
            List<List<int>> myParticion = new List<List<int>>();

            if (HallaPrimero(conjunto.ToList(), new List<int>(), 0, myParticion))
                return myParticion;
            return null;
        }
        public static bool HallaPrimero(List<int> conjunto, List<int> subconjunto, int indiceAnterior, List<List<int>> particion)
        {
            for(int indice = indiceAnterior; indice < conjunto.Count; indice++)
            {
                subconjunto.Add(conjunto[indice]);

                List<int> copia = new List<int>(conjunto);
                copia.RemoveAt(indice);

                if (HallaSegundo(copia, new List<int>(), particion, subconjunto.Sum(), 0))
                {
                    particion.Add(subconjunto);
                    return true;
                }
                else if (HallaPrimero(copia, subconjunto, indice, particion))
                {
                    return true;
                }

                subconjunto.RemoveAt(subconjunto.Count - 1);
            }
            return false;
        }

        public static bool HallaSegundo(List<int> myConjunto, List<int> mySubconjunto, List<List<int>> particion, int suma, int indiceAnterior)
        {
            for(int indice = indiceAnterior; indice < myConjunto.Count; indice++)
            {
                if (mySubconjunto.Sum() + myConjunto[indice] < suma)
                {
                    mySubconjunto.Add(myConjunto[indice]);

                    List<int> copia = new List<int>(myConjunto);
                    copia.RemoveAt(indice);

                    if (HallaSegundo(copia, mySubconjunto, particion, suma, indice))
                        return true;

                    mySubconjunto.RemoveAt(mySubconjunto.Count - 1);
                }
                else if (mySubconjunto.Sum() + myConjunto[indice] == suma)
                {
                    mySubconjunto.Add(myConjunto[indice]);
                    particion.Add(mySubconjunto);
                    return true;
                }
                else continue;
            }
            return false;
        }
        public static void PrintParticion(List<List<int>> particion)
        {
            for(int indice = 0; indice < particion.Count; indice++)
            {
                foreach(var el in particion[indice])
                    Console.Write(el + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
