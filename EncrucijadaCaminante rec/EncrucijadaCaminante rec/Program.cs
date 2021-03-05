using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrucijadaCaminante_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CantidadCombinaciones(new int[] { 1, 3, 5 }, 1));
        }

        public static int CantidadCombinaciones(int[] alturas, int maximaAltura)
        {
            if (alturas.Length < 2)
                return 0;
            int myContador = 0;

            int[] temp = new int[alturas.Length];
            for (int indice = 0; indice < temp.Length; indice++)
                temp[indice] = indice;

            for(int veces = 2; veces <= alturas.Length; veces++)
            {
                Combinaciones(temp, new int[veces], 0, 0, alturas, maximaAltura, ref myContador);
            }
            return myContador;
        }
        public static void Combinaciones(int[] indicesLongitudes, int[] combIndicesLong, int posArray, int posCombinacion, int[] longitudes, int alturaMax, ref int contador)
        {
            if (posCombinacion == combIndicesLong.Length)
            {
                for(int indice = 1; indice < combIndicesLong.Length; indice++)
                {
                    if (Math.Abs(longitudes[combIndicesLong[indice]] - longitudes[combIndicesLong[indice - 1]]) > alturaMax)
                        return;
                }
                contador++;
            }
            else if (posArray == indicesLongitudes.Length)
                return;
            else
            {
                combIndicesLong[posCombinacion] = indicesLongitudes[posArray];
                Combinaciones(indicesLongitudes, combIndicesLong, posArray + 1, posCombinacion + 1, longitudes, alturaMax, ref contador);
                Combinaciones(indicesLongitudes, combIndicesLong, posArray + 1, posCombinacion, longitudes, alturaMax, ref contador);
            }
        }
    }
}
