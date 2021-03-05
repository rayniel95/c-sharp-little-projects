using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubconjuntosDisjuntos_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //PrintSubconjuntos(HallaSubconjuntos(new int[] { 9, 3, 30, 15, 2, 7 }));

            #endregion
            #region Prueba2

            //PrintSubconjuntos(HallaSubconjuntos(new int[] { 2, 5, 21, 45, 50 }));

            #endregion
            #region Prueba3

            //PrintSubconjuntos(HallaSubconjuntos(new int[] { 34, 90, 38, 43, 60, 100, 83, 22, 26, 98 }));

            #endregion
            #region Prueba4

            //PrintSubconjuntos(HallaSubconjuntos(new int[] { 24, 38, 18, 1, 34 }));

            #endregion
            #region Prueba5

            //PrintSubconjuntos(HallaSubconjuntos(new int[] { 4, 1, 16, 2, 32, 64 }));

            #endregion


        }

        public static List<List<int>> HallaSubconjuntos(int[] conjunto)
        {
            List<List<int>> subconjuntos = new List<List<int>>();

            for(int veces = 1; veces < conjunto.Length; veces++)
            {
                if (HallaPrimero(conjunto, new int[veces], 0, 0, ref subconjuntos))
                    return subconjuntos;
            }
            return subconjuntos;
        }
        public static bool HallaPrimero(int[] conjunto, int[] subConjunto, int posConjunto, int posSubConjunto, ref List<List<int>> subConjuntos)
        {
            if (posSubConjunto == subConjunto.Length)
            {
                List<int> nuevoConjunto = new List<int>();

                foreach (var el in conjunto)
                {
                    if (!subConjunto.Contains(el))
                        nuevoConjunto.Add(el);
                }

                List<int> segundo = new List<int>();

                for (int veces = 1; veces < nuevoConjunto.Count; veces++)
                {
                    if (HallaSegundo(nuevoConjunto.ToArray(), new int[veces], 0, 0, subConjunto.Sum(), ref segundo))
                    {
                        subConjuntos.Add(subConjunto.ToList());
                        subConjuntos.Add(segundo);
                        return true;
                    }
                }

            }
            else if (posConjunto == conjunto.Length) return false;
            else
            {
                subConjunto[posSubConjunto] = conjunto[posConjunto];

                if (HallaPrimero(conjunto, subConjunto, posConjunto + 1, posSubConjunto + 1, ref subConjuntos))
                    return true;
                if (HallaPrimero(conjunto, subConjunto, posConjunto + 1, posSubConjunto, ref subConjuntos))
                    return true;
            }
            return false;
        }
        public static bool HallaSegundo(int[] conjunto, int[] subconjunto, int posconjunto, int possubconjunto, int suma, ref List<int> sub)
        {
            if (possubconjunto == subconjunto.Length)
            {
                if(subconjunto.Sum() == suma)
                {
                    sub = subconjunto.ToList();
                    return true;
                }
            }
            else if (posconjunto == conjunto.Length) return false;
            else
            {
                subconjunto[possubconjunto] = conjunto[posconjunto];

                if(HallaSegundo(conjunto, subconjunto, posconjunto + 1, possubconjunto + 1, suma, ref sub))
                    return true;
                if (HallaSegundo(conjunto, subconjunto, posconjunto + 1, possubconjunto, suma, ref sub))
                    return true;
            }
            return false;
        }
        public static void PrintSubconjuntos(List<List<int>> subconjuntos)
        {
            for(int indice = 0; indice < subconjuntos.Count; indice++)
            {
                foreach(var el in subconjuntos[indice])
                    Console.WriteLine(el);
                Console.WriteLine();
            }
        }
    }
}
