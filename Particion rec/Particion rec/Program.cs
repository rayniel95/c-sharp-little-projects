using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particion_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            int[] myRegalos = { 2, 5, 1, 6, 7, 2, 8, 9, 2 };

            Console.WriteLine(DiferenciaMinima(myRegalos));






            #endregion



        }
        public static int DiferenciaMinima(int[] regalos)
        {
            int cantidad = int.MaxValue;

            List<int>[] subconjuntos = new List<int>[2];

            subconjuntos[0] = new List<int>();
            subconjuntos[1] = new List<int>();

            Subsets(new bool[regalos.Length], 0, regalos, ref cantidad, ref subconjuntos);

            return cantidad;
        }

        public static void Subsets(bool[] items, int from, int[] precios, ref int mejor, ref List<int>[] mySubconjuntos)
        {
            if (from >= items.Length)
            {
                List<int>[] subconjuntos = HallaSubconjuntos(HallaIndices(items), precios);

                if (Math.Abs(subconjuntos[0].Sum() - subconjuntos[1].Sum()) < mejor)
                {
                    mejor = Math.Abs(subconjuntos[0].Sum() - subconjuntos[1].Sum());
                    mySubconjuntos = subconjuntos;
                }


            }
            else
            {
                items[from] = true;
                Subsets(items, from + 1, precios, ref mejor, ref mySubconjuntos);
                items[from] = false;
                Subsets(items, from + 1, precios, ref mejor, ref mySubconjuntos);
            }
        }

        public static List<int>[] HallaSubconjuntos(List<int>[] indices, int[] array)
        {
            List<int>[] subconjuntos = new List<int>[2];
            subconjuntos[0] = new List<int>();
            subconjuntos[1] = new List<int>();

            foreach (var el in indices[0])
                subconjuntos[0].Add(array[el]);

            foreach (var el in indices[1])
                subconjuntos[1].Add(array[el]);

            return subconjuntos; 
        }
        public static List<int>[] HallaIndices(bool[] array)
        {
            List<int>[] indices = new List<int>[2];
            indices[0] = new List<int>();
            indices[1] = new List<int>();


            for(int indice = 0; indice < array.Length; indice++)
            {
                if (array[indice])
                    indices[0].Add(indice);
                else
                    indices[1].Add(indice);
            }
            return indices;
        }

    }
}
