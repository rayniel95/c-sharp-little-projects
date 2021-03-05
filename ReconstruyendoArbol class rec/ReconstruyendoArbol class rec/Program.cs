using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Colleciones;

namespace ReconstruyendoArbol_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //int[] valores = { 3, 11, 7, 20, 5 };
            //int[] posPadre = { 2, 3, 3, -1, 3 };

            //PrintArbol(Construye(valores, posPadre), 0);

            #endregion
            #region Prueba2
            //int[] valores = { 9, 29, 2, 19, 31, 7, 23, 45, 3, 37, 11, 51, 3, 9 };
            //int[] posPadre = { 3, 3, 10, -1, 3, 7, 7, 0, 4, 1, 9, 10, 7, 4 };

            //PrintArbol(Construye(valores, posPadre), 0);


            #endregion
            #region Prueba3

            //int[] valores = { 12, 7, 8, 9, 9, 11, 7, 1, 2, 3, 2, 1 };
            //int[] posPadre = { 7, 9, 3, 9, 3, 9, 0, 9, 0, 11, 0, -1 };

            //PrintArbol(Construye(valores, posPadre), 0);

            #endregion

        }
        public static Arbol<T4> Construye<T4>(T4[] valores, int[] posPadres)
        {
            Arbol<T4> myArbol = null;
            for(int indice = 0; indice < posPadres.Length; indice++)
            {
                if(posPadres[indice] == -1)
                {
                    myArbol = new Arbol<T4>(valores[indice]);
                    Resuelve(myArbol, posPadres, valores, indice);
                    break;
                }
            }
            return myArbol;
        }
        public static void Resuelve<T1>(Arbol<T1> arbolActual, int[] posicionPadre, T1[] valores, int posPadre)
        {
            List<int> posHijos = new List<int>();

            for(int indice = 0; indice < posicionPadre.Length; indice++)
            {
                if(posicionPadre[indice] == posPadre)
                {
                    posHijos.Add(indice);
                    arbolActual.Children.Add(new Arbol<T1>(valores[indice]));
                }
            }
            for(int indice = 0; indice < posHijos.Count; indice++)
            {
                Resuelve(arbolActual.Children[indice], posicionPadre, valores, posHijos[indice]);
            }

        }

        public static void PrintArbol<T3>(Arbol<T3> arbolActual, int llamado)
        {
            for (int veces = 0; veces < llamado; veces++)
            {
                Console.Write("-");
            }
            Console.Write(arbolActual.Valor);

            Console.WriteLine();
            foreach (var hijo in arbolActual.Children)
                PrintArbol(hijo, llamado + 1);

        }

    }
}
