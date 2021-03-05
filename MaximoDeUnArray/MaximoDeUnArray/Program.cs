using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoDeUnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 1, 1, 4, 1, 1, 3 };
            int[] prueba1 = { 1, 1, 2, 3, 2, 2 };
            int[] prueba2 = { 2, 2, 4, 3, 4, 1, 1 };
            int[] prueba3 = { 3, 3, 3, 3 };
            int[] prueba4 = { 1, 1, 1, 2, 2, 1, 1, 2 };
            Console.WriteLine(ANivelar(array));
            //Console.WriteLine(Nivelando(array));
            //Console.WriteLine(3/2);
        }
        static int Maximo(int[] array, int inferior, int superior)
        {
            if (superior == inferior)
                return array[inferior];

            int medio = (inferior + superior) / 2;

            return Math.Max(Maximo(array, inferior, medio), Maximo(array, medio + 1, superior));
        }
        static int ANivelar(int[] myArray)
        {
            return ANivelar(myArray, 0, myArray.ToList().IndexOf(myArray.Max())) + ANivelar(myArray, myArray.ToList().IndexOf(myArray.Max()), myArray.Length - 1);
        }
        static int ANivelar(int[] array, int inferior, int superior)
        {
            if (inferior >= superior) return 0;
            else if (superior - inferior == 1) return Math.Abs(array[superior] - array[inferior]);

            int medio = (superior + inferior) / 2;

            return ANivelar(array, inferior, medio) + ANivelar(array, medio, superior); 
        }
        static int Nivelando(int[] myArray)
        {
            int myMaximo = myArray.Max();
            int veces = 0;

            while (myArray.Min() < myArray.Max())
            {
                bool nivelo = false;
                Nivela(myArray, myMaximo, ref nivelo);
                veces++;
            }
            return veces;
        }
        static void Nivela(int[] array, int maximo, ref bool seNivelo)
        {
            int indiceMin = array.ToList().IndexOf(array.Min());
            int myContador = 0;
            int longitud = Longitud(array, maximo, indiceMin);
            int temp = array[indiceMin];

            for (int indice = indiceMin; myContador < longitud; indice++)
            {
                if (array[indice] == temp && array[indice] < maximo)
                {
                    array[indice] += 1;
                    seNivelo = true;
                }
                myContador++;
            }

        }
        static int Longitud(int[] myArray, int myMaximo, int posicion)
        {
            int contador = 0;

            for (int indice = posicion; indice < myArray.Length; indice++)
            {
                if (myArray[indice] < myMaximo && myArray[indice] == myArray[posicion])
                    contador++;
                else
                    break;
            }
            return contador;
        }

    }
}
