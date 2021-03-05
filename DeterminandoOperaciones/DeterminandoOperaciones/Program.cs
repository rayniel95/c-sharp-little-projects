using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminandoOperaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            //tienes que tener presente de que tienen que estar en el mismo orden que esra en la cadena las particiones
            Console.WriteLine(Subsets("529", 11));


        }
        static void VariacionesConRepeticion(int[] array, int[] variacion, int posicion, int[] subconjunto, ref int mejorDistancia, int seBusca, ref int masCercano)
        {
            if (posicion == variacion.Length)
            {
                int total = 0;

                for(int indice = 0; indice < subconjunto.Length; indice++)
                {
                    total += variacion[indice] * subconjunto[indice];
                }

                if (Math.Abs(total - seBusca) < mejorDistancia)
                {
                    masCercano = total;
                    mejorDistancia = Math.Abs(total - seBusca);
                }
            }
            else
                for (int indice = 0; indice < array.Length; indice++)
                {
                    variacion[posicion] = array[indice];
                    VariacionesConRepeticion(array, variacion, posicion + 1, subconjunto, ref mejorDistancia, seBusca, ref masCercano);
                }
        }
        static int[] DeterminaIndices(bool[] indices)
        {
            int longitud = 0;

            foreach(bool elemento in indices)
            {
                if (elemento)
                    longitud++;
            }

            int[] indicesDeterminados = new int[longitud];
            int cuenta = 0;

            for(int indice = 0; indice < indices.Length; indice++)
            {
                if(indices[indice])
                {
                    indicesDeterminados[cuenta] = indice;
                    cuenta++;
                }
            }
            return indicesDeterminados;
        }
        static int[] DeterminaSubconjunto(int[] indices, int[] conjunto)
        {
            int[] subconjunto = new int[indices.Length];

            for(int indice = 0; indice < indices.Length; indice++)
            {
                subconjunto[indice] = conjunto[indices[indice]];
            }

            return subconjunto;
        }
        static int Subsets(string digitos, int aBuscar)
        {
            int elMejor = int.MaxValue;
            int elCercano = int.MinValue;
            int[] numeros = new int[digitos.Length];

            for (int indice = 0; indice < digitos.Length;  indice++)
            {
                numeros[indice] = int.Parse(digitos[indice].ToString());
            }

            Subsets(new bool[digitos.Length], 0, numeros, ref elMejor, aBuscar, ref elCercano);

            return elCercano;
        }
        static void Subsets(bool[] items, int from, int[] myConjunto, ref int bueno, int buscado, ref int cerca)
        {
            if (from >= items.Length)
            {
                int[] indices = DeterminaIndices(items);
                int[] subConjunto = DeterminaSubconjunto(indices, myConjunto);

                int[] myArray = new int[2];
                myArray[0] = 1;
                myArray[1] = -1;

                if (subConjunto.Length > 0)
                {
                    int[] particion = DeterminaParticion(subConjunto, myConjunto);

                    VariacionesConRepeticion(myArray, new int[particion.Length], 0, particion, ref bueno, buscado, ref cerca);
                }
            }
            else
            {
                items[from] = true;
                Subsets(items, from + 1, myConjunto, ref bueno, buscado, ref cerca);
                items[from] = false;
                Subsets(items, from + 1, myConjunto, ref bueno, buscado, ref cerca);
            }
        }
        static void PrintArray(int[] array)
        {
            int cuenta = 0;
            foreach (int element in array)
            {
                Console.Write(element);
            }
            Console.WriteLine(cuenta);
        }
        static int[] DeterminaParticion(int[] subconjunto, int[] conjunto)
        {
            bool[] cualesFaltan = new bool[conjunto.Length];
            bool[] estan = new bool[subconjunto.Length];
            int cardinalidad = 0;
            string union = "";

            for (int indice = 0; indice < conjunto.Length; indice++)
            {
                for(int segundoIndice = 0; segundoIndice < subconjunto.Length; segundoIndice++)
                {
                    if(conjunto[indice] == subconjunto[segundoIndice] && !estan[segundoIndice])
                    {
                        cualesFaltan[indice] = true;
                        estan[segundoIndice] = true;
                        cardinalidad++;
                    }
                }
            }

            foreach(int elemento in subconjunto)
                union += elemento.ToString();

            int[] particion = new int[1 + conjunto.Length - cardinalidad];

            particion[0] = int.Parse(union);
            int cuenta = 1;

            for (int indice = 0; indice < conjunto.Length; indice++)
            {
                if(!cualesFaltan[indice])
                {
                    particion[cuenta] = conjunto[indice];
                    cuenta++;
                }
            }
            return particion;
        }
    }
}
