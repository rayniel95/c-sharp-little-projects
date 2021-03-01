using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BultosPostales_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Resuelve(new bool[7], 0, new List<int>(), new List<List<int>>(), new int[] { 1, 7, 2, 4, 3, 6, 1 }, 8);
        }
        public static bool[] CopiaArray(bool[] myArray)
        {
            bool[] copia = new bool[myArray.Length];

            for(int indice = 0; indice < copia.Length; indice++)
            {
                copia[indice] = myArray[indice];
            }
            return copia;
        }
        public static List<int> CopiaSubconjunto(List<int> subconjunto)
        {
            List<int> copia = new List<int>();
            foreach (var el in subconjunto)
                copia.Add(el);
            return copia;
        }
        public static List<List<int>> CopiaSubConjuntos(List<List<int>> subconjuntos)
        {
            List<List<int>> copia = new List<List<int>>();

            for(int primerIndice = 0; primerIndice < subconjuntos.Count; primerIndice++)
            {
                List<int> temp = new List<int>();
                for (int segundoIndice = 0; segundoIndice < subconjuntos[primerIndice].Count; segundoIndice++)
                {     
                    temp.Add(subconjuntos[primerIndice][segundoIndice]);
                }
                copia.Add(temp);
            }
            return copia;
        }
        public static void PrintSubConjuntos(List<List<int>> subconjuntos)
        {
            for(int primerIndice = 0; primerIndice<subconjuntos.Count; primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < subconjuntos[primerIndice].Count; segundoIndice++)
                {
                    Console.Write(subconjuntos[primerIndice][segundoIndice]);
                }
                Console.WriteLine();
            }   
        }

        public static bool Resuelve(bool[] marcado, int indiceActual, List<int> subconjuntoActual, List<List<int>> subconjuntosActual, int[] array, int maximo)
        {
            if(!marcado.Contains(false))
            {
                PrintSubConjuntos(subconjuntosActual);
                return true;
            }
            for(int indice = indiceActual; indice < array.Length; indice++)
            {
                if(subconjuntoActual.Sum() + array[indice] <= maximo && !marcado[indice])
                {
                    List<int> nuevoSubConjunto = CopiaSubconjunto(subconjuntoActual);
                    bool[] nuevoMarcado = CopiaArray(marcado);
                    nuevoMarcado[indice] = true;
                    nuevoSubConjunto.Add(array[indice]);
                    if(subconjuntoActual.Sum() + array[indice] == maximo && !marcado[indice])
                    {
                        List<List<int>> nuevoSubConjuntos = CopiaSubConjuntos(subconjuntosActual);
                        nuevoSubConjuntos.Add(nuevoSubConjunto);
                        if (Resuelve(nuevoMarcado, 0, new List<int>(), nuevoSubConjuntos, array, maximo))
                            return true;
                    }
                    else if (Resuelve(nuevoMarcado, indice + 1, nuevoSubConjunto, subconjuntosActual, array, maximo))
                        return true;
                }
            }
            return false;
        }
    }
}
