using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysReducidos_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //int[] myMejor = new int[50];
            //int[] myArray = { 2, 2, 2, 3, 4, 4, 4, 3, 3, 2, 2, 1 };

            //Resuelve(myArray, ref myMejor);

            //PrintArray(myMejor);


            #endregion
            #region Prueba2

            //int[] myMejor = new int[50];
            //int[] myArray = { 2, 3, 3, 3, 8, 5, 0, 0, 0, 0};

            //Resuelve(myArray, ref myMejor);

            //PrintArray(myMejor);


            #endregion
            #region Prueba3

            //int[] myMejor = new int[50];
            //int[] myArray = { 2, 2, 4, 4, 4, 2 };

            //Resuelve(myArray, ref myMejor);

            //PrintArray(myMejor);


            #endregion
            #region Prueba4

            //int[] myMejor = new int[50];
            //int[] myArray = { 3, 3, 3, 4, 4, 4, 5, 5, 5, 4, 4, 3, 1 };

            //Resuelve(myArray, ref myMejor);

            //PrintArray(myMejor);

            #endregion




        }

        public static void Resuelve(int[] array, ref int[] mejor)
        {
            if(EstaReducido(array))
            {
                if (array.Length < mejor.Length)
                    mejor = array;
                return;
            }
            for(int indice = 0; indice < array.Length; indice++)
            {
                int[] temp = Reduce(array, indice);
                if (temp != null)
                    Resuelve(temp, ref mejor);
            }
        }

        public static void PrintArray(int[] array)
        {
            foreach(var el in array)
                Console.Write(el);
            Console.WriteLine();
        }
        public static int[] Reduce(int[] myArray, int indiceParametro)
        {
            List<int> copia = CopiaArray(myArray).ToList();

            int contador = 0;

            int temp = copia[indiceParametro];

            for (int indice = indiceParametro; indice < copia.Count; indice++)
            {
                if (copia[indice] == temp)
                {
                    contador++;
                    copia[indice] = int.MinValue;
                }
                else break;
            }

            for (int indice = indiceParametro - 1; indice >= 0; indice--)
            {
                if (copia[indice] == temp)
                {
                    contador++;
                    copia[indice] = int.MinValue;
                }
                else break;
            }

            if (contador < 3)
                return null;

            while (copia.Contains(int.MinValue))
                copia.Remove(int.MinValue);

                
            return copia.ToArray();
        }
        public static int[] CopiaArray(int[] myArray)
        {
            int[] nuevo = new int[myArray.Length];

            for(int indice = 0; indice < myArray.Length; indice++)
            {
                nuevo[indice] = myArray[indice];
            }
            return nuevo;
        }
        public static bool EstaReducido(int[] myArray)
        {
            for(int primerIndice = 0; primerIndice < myArray.Length; primerIndice++)
            {
                int contador = 0;
                for(int segundoIndice = primerIndice; segundoIndice < myArray.Length; segundoIndice++)
                {
                    if (myArray[segundoIndice] == myArray[primerIndice])
                    {
                        contador++;
                        if (contador >= 3)
                            return false;
                    }
                    else
                        break;
                }
            }
            return true;
        }
    }
}
