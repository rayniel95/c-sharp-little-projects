using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReducirAPalindromo_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //Console.WriteLine(HallaMayorPalindromo("la zorra en el arrozal"));

            #endregion
            #region Prueba2

            //Console.WriteLine(HallaMayorPalindromo("+##+"));

            #endregion
            #region Prueba3

            //Console.WriteLine(HallaMayorPalindromo("k?salsa"));

            #endregion


        }

        public static string HallaMayorPalindromo(string cadena)
        {
            List<int> indicesCadena = new List<int>();

            for(int indice = 0; indice < cadena.Length; indice++)
            {
                indicesCadena.Add(indice);
            }

            for(int veces = 0; veces <= cadena.Length; veces++)
            {
                string palindromo = Reduce(indicesCadena.ToArray(), new int[veces], 0, 0, cadena);
                if (palindromo != "") return palindromo;
            }
            return "";
        }
        public static string Reduce(int[] indices, int[] indicesEliminar, int posIndices, int posIndicesEliminar, string cadena)
        {
            if (posIndicesEliminar == indicesEliminar.Length)
            {
                string nueva = cadena;
                int contador = 0;

                foreach (var indice in indicesEliminar)
                {
                    nueva = nueva.Remove(indice - contador, 1);
                    contador++;
                }
                if (EsPalindromo(nueva)) return nueva;
            }
            else if (posIndices == indices.Length) return "";
            else
            {
                indicesEliminar[posIndicesEliminar] = indices[posIndices];

                string primero = Reduce(indices, indicesEliminar, posIndices + 1, posIndicesEliminar + 1, cadena);

                if (primero != "") return primero;

                string segundo = Reduce(indices, indicesEliminar, posIndices + 1, posIndicesEliminar, cadena);

                if (segundo != "") return segundo;
            }
            return "";

        }
        public static bool EsPalindromo(string cadena)
        {
            for(int indice = 0; indice < cadena.Length / 2; indice++)
            {
                if (cadena[indice] != cadena[cadena.Length - 1 - indice]) return false;
            }
            return true;
        }


    }
}
