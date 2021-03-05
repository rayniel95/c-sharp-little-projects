using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Utils;

namespace NodoMasDescendientes_class
{
    class Program
    {
        static void Main(string[] args)
        {

            Arbol<int> myArbol = new Arbol<int>(29,
                                        new Arbol<int>(3, new Arbol<int>[0]),
                                        new Arbol<int>(5,
                                                new Arbol<int>(6,
                                                        new Arbol<int>(7, new Arbol<int>[0]),
                                                        new Arbol<int>(3, new Arbol<int>[0]),
                                                        new Arbol<int>(19, new Arbol<int>[0]),
                                                        new Arbol<int>(17, new Arbol<int>[0]))),
                                        new Arbol<int>(2,
                                                new Arbol<int>(9,
                                                        new Arbol<int>(16, new Arbol<int>[0]),
                                                        new Arbol<int>(3, new Arbol<int>[0]),
                                                        new Arbol<int>(8, new Arbol<int>[0])),
                                                new Arbol<int>(3, 
                                                        new Arbol<int>(4, new Arbol<int>[0]))),
                                        new Arbol<int>(5, new Arbol<int>[0]),
                                        new Arbol<int>(12, 
                                                    new Arbol<int>(8,
                                                            new Arbol<int>(4, new Arbol<int>[0]))));


            Arbol<int> mayor = IteraArbol<int>(myArbol, 1, Primo);
            Console.WriteLine(mayor.Valor);
                                                
        }
        public static bool Pares(int numero)
        { return numero % 2 == 0; }
        public static bool Impares(int numero)
        { return numero % 2 != 0; }
        public static bool Primo(int numero)
        {
            for(int divisor = 2; divisor < numero; divisor++)
            {
                if (numero % divisor == 0)
                    return false;
            }
            return true;
        }
        public static void PrintArbol<T3>(Arbol<T3> arbolActual, int llamado)
        {
            for (int indice = 0; indice < llamado; indice++)
            {
                Console.Write("-");
            }
            Console.Write(arbolActual.Valor);
            Console.WriteLine();
            foreach (var hijo in arbolActual.Hijos)
                PrintArbol(hijo, llamado + 1);
        }
        public static void HazPreOrden<T1>(Arbol<T1> arbolActual, List<Arbol<T1>> preorden)
        {
            preorden.Add(arbolActual);
            foreach (var hijo in arbolActual.Hijos)
                HazPreOrden(hijo, preorden);
        }
        public static void RecorreArbol<T2>(Arbol<T2> arbolActual, int llamado, int nivel, ref int contador, Filtro<T2> condicion)
        {
            if (condicion(arbolActual.Valor) && llamado == nivel)
                contador++;
            foreach(var hijo in arbolActual.Hijos)
            {
                if (llamado + 1 <= nivel)
                    RecorreArbol(hijo, llamado + 1, nivel, ref contador, condicion);
            }
        }
        public static Arbol<T3> IteraArbol<T3>(Arbol<T3> raiz, int nivel, Filtro<T3> condicion)
        {
            List<Arbol<T3>> myPreorden = new List<Arbol<T3>>();

            HazPreOrden(raiz, myPreorden);

            int indiceAnterior = -1;
            int maximoAnterior = 0;

            for(int indice = 0; indice < myPreorden.Count; indice++)
            {
                int maximo = 0;
                RecorreArbol(myPreorden[indice], 0, nivel, ref maximo, condicion);
                if(maximo > maximoAnterior)
                {
                    maximoAnterior = maximo;
                    indiceAnterior = indice;
                }
            }
            return myPreorden[indiceAnterior];
        }
    }
}
