using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadoMasCercano_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            Console.WriteLine(ResultadoMasCercano("529", 11));




            #endregion




        }

        public static int ResultadoMasCercano(string cadena, int numero)
        {
            int restaMenor = int.MaxValue;

            List<int> myResultado = new List<int>();

            int[] myArray = new int[cadena.Length - 1];

            for (int indice = 0; indice < myArray.Length; indice++)
            {
                myArray[indice] = indice + 1;
            }

            for (int indice = 1; indice <= myArray.Length; indice++)
                Combinaciones(myArray, new int[indice], 0, 0, cadena, ref restaMenor, numero, ref myResultado);

            return myResultado.Sum();
        }

        public static void Combinaciones(int[] array, int[] combinacion, int posArray, int posCombinacion, string cadena, ref int mejor, int numero, ref List<int> resultado)
        {
            if (posCombinacion == combinacion.Length)
            {
                List<int> indices = combinacion.ToList();
                indices.Insert(0, 0);
                indices.Add(cadena.Length);

                List<int> picados = new List<int>();

                for(int indice = 0; indice < indices.Count - 1; indice++)
                {
                    picados.Add(int.Parse(cadena.Substring(indices[indice], indices[indice + 1] - indices[indice])));
                }

                VariacionesConRepeticion(new int[] { 1, -1 }, new int[picados.Count], 0, numero, picados, ref mejor, ref resultado);
            
            }
            else if (posArray == array.Length)
                return;
            else
            {
                combinacion[posCombinacion] = array[posArray];

                Combinaciones(array, combinacion, posArray + 1, posCombinacion + 1, cadena, ref mejor, numero, ref resultado);
                Combinaciones(array, combinacion, posArray + 1, posCombinacion, cadena, ref mejor, numero, ref resultado);
            }
        }

        static void VariacionesConRepeticion(int[] array, int[] variacion, int pos, int numero, List<int> lista, ref int mejor, ref List<int> myResultado)
        {
            if (pos == variacion.Length)
            {
                int contador = 0;

                for (int indice = 0; indice < variacion.Length; indice++)
                {
                    contador += lista[indice] * (variacion[indice]);
                }
                if (Math.Abs(numero - contador) < mejor)
                {
                    mejor = Math.Abs(numero - contador);
                    myResultado = new List<int>();
                    for (int indice = 0; indice < variacion.Length; indice++)
                    {
                        myResultado.Add(lista[indice] * variacion[indice]);   
                    }

                }

            }
            else
                for (int i = 0; i < array.Length; i++)
                {
                    variacion[pos] = array[i];
                    VariacionesConRepeticion(array, variacion, pos + 1, numero, lista, ref mejor, ref myResultado);
                }
        }

    }
}
