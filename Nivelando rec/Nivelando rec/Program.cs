using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivelando_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //Console.WriteLine(Resuelve(new int[] { 2, 4, 2, 4, 1, 1, 3, 3 }, 4, 0, 7, 1));

            #endregion
            #region Prueba2

            //Console.WriteLine(Resuelve(new int[] { 1, 1, 2, 3, 2, 2 }, 3, 0, 5, 3));


            #endregion
            #region Prueba3

            //Console.WriteLine(Resuelve(new int[] { 2, 2, 4, 3, 4, 1, 1 }, 4, 0, 6, 2));

            #endregion
            #region Prueba4

            //Console.WriteLine(Resuelve(new int[] { 3, 3, 3, 3 }, 3, 0, 3, 0));


            #endregion
            #region Prueba5

            //Console.WriteLine(Resuelve(new int[] { 1, 1, 1, 2, 2, 1, 1, 2 }, 2, 0, 7, 3));

            #endregion



        }


        public static int Resuelve(int[] array, int maximoAnterior, int inferior, int superior, int posMax)
        {
            if (inferior == superior)
                return maximoAnterior - array[posMax];

            int posMaxIzq = -1;
            if (posMax - 1 >= 0 && posMax != inferior)
                posMaxIzq = BuscaMaximo(array, inferior, posMax - 1, posMax);

            int posMaxDer = -1;
            if (posMax + 1 < array.Length && posMax != superior)
                posMaxDer = BuscaMaximo(array, posMax + 1, superior, posMax);

            int cantidadIzq = 0;
            if (posMaxIzq != -1)
                cantidadIzq = Resuelve(array, array[posMax], inferior, posMax - 1, posMaxIzq);

            int cantidadDer = 0;
            if (posMaxDer != -1)
                cantidadDer = Resuelve(array, array[posMax], posMax + 1, superior, posMaxDer);

            return cantidadIzq + cantidadDer + (maximoAnterior - array[posMax]);
        }
        public static int BuscaMaximo(int[] myArray, int inf, int sup, int posMax)
        {
            int indiceMaximo = posMax;
            int maximoAnterior = 0;

            for(int indice = inf; indice <= sup; indice++)
            {
                if (myArray[indice] == myArray[posMax])
                    return indice;
                else if(myArray[indice] > maximoAnterior && myArray[indice] < myArray[posMax])
                {
                    indiceMaximo = indice;
                    maximoAnterior = myArray[indice];
                }
            }
            return indiceMaximo;
        }

    }
}
