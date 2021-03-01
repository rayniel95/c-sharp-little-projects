using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Examen
{
    public class Constructora
    {
        public static int MinNivelarParcela(int[] parcela)
        {
            int myMaximo = parcela.Max();
            int myContador = 0;

            Nivela(parcela, myMaximo, parcela.ToList().IndexOf(parcela.Min()), ref myContador);

            return myContador;

        }
        static void Nivela(int[] array, int maximo, int posicion, ref int contador)
        {
            if (posicion == array.Length || array.Min() == array.Max())
                return;

            else if (array[posicion] < maximo)
            {
                int longitud = Longitud(array, maximo, posicion);
                int temp = array[posicion];
                bool seNivelo = false;
                int myContador = 0;

                for (int indice = posicion; longitud != myContador; indice++)
                {
                    if (temp == array[indice] && array[indice] < maximo)
                    {
                        seNivelo = true;
                        array[indice] += 1;
                    }
                    myContador++;
                }
                if (seNivelo)
                    contador++;

                Nivela(array, maximo, array.ToList().IndexOf(array.Min()), ref contador);
            }
            else if (array[posicion] == maximo)
            {
                Nivela(array, maximo, posicion + 1, ref contador);
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
        static bool EstaNivelado(int[] myArray)
        {
            int maximo = myArray.Max();

            for (int indice = 0; indice < myArray.Length; indice++)
            {
                if (myArray[indice] != maximo)
                    return false;
            }
            return true;
        }
    }
}
