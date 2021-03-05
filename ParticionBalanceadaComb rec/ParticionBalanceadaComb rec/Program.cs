using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticionBalanceada_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //PrintSubConjuntos(Particion(new int[] { 1, 7, 2, 4, 3, 6, 1 }, 3));

            #endregion
            #region Prueba2

            //PrintSubConjuntos(Particion(new int[] { 1, 7, 2, 4, 3, 6, 1 }, 2));

            #endregion
            #region Prueba3

            //PrintSubConjuntos(Particion(new int[] { 1, 7, 2, 4, 3, 6, 1 }, 5));

            #endregion



        }

        public static List<List<int>> Particion(int[] conjunto, int cantidad)
        {
            if (conjunto.Sum() % cantidad != 0) return new List<List<int>>();

            List<List<int>> subConjuntos = new List<List<int>>();

            if (HallaSubconjuntos(conjunto, conjunto.Sum() / cantidad, subConjuntos))
                return subConjuntos;
            return subConjuntos;
        }
        public static bool HallaSubconjuntos(int[] conjunto, int suma, List<List<int>> subconjuntos)
        {
            if (conjunto.Length == 0)
                return true;
            List<int> indicesConjunto = new List<int>();

            for(int indice = 0; indice < conjunto.Length; indice++)
            {
                indicesConjunto.Add(indice);
            }

            for(int veces = 1; veces <= conjunto.Length; veces++)
            {
                if (Combina(indicesConjunto.ToArray(), new int[veces], 0, 0, conjunto, suma, subconjuntos))
                    return true;
            }
            if(subconjuntos.Count != 0)
                subconjuntos.RemoveAt(subconjuntos.Count - 1);
            return false;
        }
        public static bool Combina(int[] indices, int[] indicesSubConjunto, int posIndices, int posSubConjunto, int[] conjunto, int suma, List<List<int>> subconjuntos)
        {
            if (posSubConjunto == indicesSubConjunto.Length)
            {
                int sumaActual = 0;

                foreach (var el in indicesSubConjunto)
                    sumaActual += conjunto[el];

                if (sumaActual == suma)
                {
                    List<int> nuevoSubconjunto = new List<int>();
                    List<int> nuevoConjunto = new List<int>();

                    foreach(var el in indicesSubConjunto)
                    {
                        nuevoSubconjunto.Add(conjunto[el]);
                    }
                    subconjuntos.Add(nuevoSubconjunto);

                    foreach(var el in indices)
                    {
                        if(!indicesSubConjunto.Contains(el))
                        {
                            nuevoConjunto.Add(conjunto[el]);
                        }
                    }

                    if (HallaSubconjuntos(nuevoConjunto.ToArray(), suma, subconjuntos))
                        return true;
                }

            }
            else if (posIndices == indices.Length) return false;
            else
            {
                indicesSubConjunto[posSubConjunto] = indices[posIndices];

                if (Combina(indices, indicesSubConjunto, posIndices + 1, posSubConjunto + 1, conjunto, suma, subconjuntos))
                    return true;
                if (Combina(indices, indicesSubConjunto, posIndices + 1, posSubConjunto, conjunto, suma, subconjuntos))
                    return true;
            }
            return false;
        }
        public static void PrintSubConjuntos(List<List<int>> lista)
        {
            for(int indice = 0; indice < lista.Count; indice++)
            {
                foreach(var el in lista[indice])
                    Console.Write(el + " ");
                Console.WriteLine();
            }

        }
    }
}
