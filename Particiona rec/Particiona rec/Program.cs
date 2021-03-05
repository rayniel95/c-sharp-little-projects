using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particiona_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //int[] conjunto = { 1, 7, 2, 4, 3, 6, 1 };

            //PrintParticion(ParticionBalanceada(conjunto, 3));


            #endregion

        }

        public static List<List<int>> ParticionBalanceada(int[] myConjunto, int cardinalidad)
        {
            List<List<int>> myParticion = new List<List<int>>();

            if (myConjunto.Sum() % cardinalidad != 0) return new List<List<int>>();

            Resuelve(myConjunto.ToList(), new List<int>(), 0, myParticion, myConjunto.Sum() / cardinalidad);

            return myParticion;
        }
        public static bool Resuelve(List<int> conjunto, List<int> subconjuntoActual, int indiceAnterior, List<List<int>> particion, int suma)
        {
            if (conjunto.Count == 0)
                return true;

            for(int indice = indiceAnterior; indice < conjunto.Count; indice++)
            {
                if (subconjuntoActual.Sum() + conjunto[indice] < suma)
                {
                    subconjuntoActual.Add(conjunto[indice]);

                    List<int> copia = new List<int>(conjunto);
                    copia.RemoveAt(indice);

                    if (Resuelve(copia, subconjuntoActual, indice, particion, suma))
                        return true;

                    subconjuntoActual.RemoveAt(subconjuntoActual.Count - 1);
                }
                else if (subconjuntoActual.Sum() + conjunto[indice] == suma)
                {
                    subconjuntoActual.Add(conjunto[indice]);

                    List<int> copia = new List<int>(conjunto);
                    copia.RemoveAt(indice);

                    particion.Add(subconjuntoActual);

                    if (Resuelve(copia, new List<int>(), 0, particion, suma))
                        return true;

                    particion.RemoveAt(particion.Count - 1);
                    subconjuntoActual.RemoveAt(subconjuntoActual.Count - 1);
                }
                else if (subconjuntoActual.Sum() + conjunto[indice] > suma) continue;
            }
            return false;
        }
        public static void PrintParticion(List<List<int>> particion)
        {
            for(int indice = 0; indice < particion.Count; indice++)
            {
                foreach(var el in particion[indice])
                    Console.Write(el);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
