using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaArbol_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //Arbol<int> myArbol = new Arbol<int>(3,
            //                            new Arbol<int>(5,
            //                                new Arbol<int>(7, new Arbol<int>[0]),
            //                                new Arbol<int>(6, new Arbol<int>[0]),
            //                                new Arbol<int>(10, new Arbol<int>[0])),
            //                            new Arbol<int>(20,
            //                                new Arbol<int>(1, new Arbol<int>[0]),
            //                                new Arbol<int>(0,
            //                                    new Arbol<int>(4,
            //                                        new Arbol<int>(5, new Arbol<int>[0])),
            //                                    new Arbol<int>(8, new Arbol<int>[0]))));

            //PrintArbol(myArbol, 0);
            //myArbol.OrdenDescendiente();
            //Console.WriteLine();
            //PrintArbol(myArbol, 0);

            #endregion
            #region Prueba2

            //Arbol<int> myArbol = new Arbol<int>(5,
            //                            new Arbol<int>(6,
            //                                new Arbol<int>(8)),
            //                            new Arbol<int>(1,
            //                                new Arbol<int>(2),
            //                                new Arbol<int>(3)));

            //PrintArbol(myArbol, 0);
            //Console.WriteLine();
            //myArbol.OrdenDescendiente();

            //PrintArbol(myArbol, 0);

            #endregion

        }

        public class Arbol<T1> where T1 :IComparable<T1>
        {
            class DefeaultComparer : IComparer<T1>
            {
                public int Compare(T1 x, T1 y)
                {
                    return x.CompareTo(y);
                }
            }
            public Arbol(T1 valor, params Arbol<T1>[] hijos)
            {
                Valor = valor;
                Hijos = hijos;
            }
            public T1 Valor
            {
                get;
                private set;
            }
            public Arbol<T1>[] Hijos { get; private set; }
            public void OrdenDescendiente()
            {
                this.OrdenDescendiente(new DefeaultComparer());
            }
            public void OrdenDescendiente(IComparer<T1> comparer)
            {
                foreach (var hijo in this.Hijos)
                    hijo.OrdenDescendiente(comparer);

                T1 min = this.Valor;
                Arbol<T1> arbol = this;

                foreach(var hijo in this.Hijos)
                {
                    if(comparer.Compare(hijo.Valor, min) < 0)
                    {
                        min = hijo.Valor;
                        arbol = hijo;
                    }
                }
                if(arbol != this)
                {
                    arbol.Valor = this.Valor;
                    this.Valor = min;
                }
                foreach (var hijo in this.Hijos)
                    hijo.OrdenDescendiente(comparer);
            }

        }
        public static void PrintArbol<T3>(Arbol<T3> arbolActual, int llamado) where T3 :IComparable<T3>
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
    }
}
