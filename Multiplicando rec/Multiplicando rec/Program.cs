using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplicando_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            string[,] tabla =
            {
                {"b", "b", "c" },
                {"a", "c", "b" },
                {"c", "a", "a" }
            };

            Console.WriteLine(Evalua("abc", tabla, "bbca", "c"));




            #endregion





        }


        public static bool Evalua(string myNumeros, string[,] myTabla, string expresion, string valor)
        {
            string nueva = "";
            foreach(var caracter in expresion)
            {
                nueva += caracter;
                nueva += " ";
            }
            nueva = nueva.Remove(nueva.Length - 1);
            return VariacionesSinRepeticion(nueva.Split(), 0, expresion.Length, valor, myTabla, myNumeros);
        }
        public static bool VariacionesSinRepeticion(string[] array, int posicion, int numeroACombinar, string pedido, string[,] tabla, string numeros)
        {
            if (posicion == numeroACombinar)
            {
                string primero = BuscaResultado(array[0], array[1], tabla, numeros);

                for(int indice = 2; indice < array.Length; indice++)
                {
                    primero = BuscaResultado(primero, array[indice], tabla, numeros);
                }
                if (primero == pedido)
                    return true;
            }
            else
            {
                for (int indice = posicion; indice < array.Length; indice++)
                {
                    string temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                    if (VariacionesSinRepeticion(array, posicion + 1, numeroACombinar, pedido, tabla, numeros))
                        return true;
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
            return false;
        }

        public static string BuscaResultado(string primero, string segundo, string[,] matrix, string losNumeros)
        {
            return matrix[losNumeros.IndexOf(primero), losNumeros.IndexOf(segundo)];
        }
    }
}
