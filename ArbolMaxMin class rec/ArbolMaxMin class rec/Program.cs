using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolMaxMin_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<int> myArbol = new Arbol<int>(4,
                                        new Arbol<int>(3,
                                            new Arbol<int>(9, new Arbol<int>[0]),
                                            new Arbol<int>(7, new Arbol<int>[0])),
                                        new Arbol<int>(6,
                                            new Arbol<int>(5, new Arbol<int>[0])),
                                        new Arbol<int>(20,
                                            new Arbol<int>(10,
                                                new Arbol<int>(13, new Arbol<int>[0]),
                                                new Arbol<int>(2, new Arbol<int>[0]),
                                                new Arbol<int>(1, new Arbol<int>[0])),
                                            new Arbol<int>(10, new Arbol<int>[0])));

            Console.WriteLine(myArbol.Max);
            Console.WriteLine(Maximo(myArbol));
            int max = myArbol.Valor;
            Max(myArbol, ref max);
            Console.WriteLine(max);

            // el minimo es lo mismo cambinado la desigualdad
        }
        public static void Max<T>(Arbol<T> arbol, ref T max) where T :IComparable<T>
        {
            if(arbol.Valor.CompareTo(max) > 0)
            {
                max = arbol.Valor;
            }
            foreach(var hijo in arbol.Hijos)
            {
                Max(hijo, ref max);
            }
        }
        public static T Maximo<T>(Arbol<T> arbol) where T : IComparable<T>
        {
            T max = arbol.Valor;
            foreach(var hijo in arbol.Hijos)
            {
                if (Maximo(hijo).CompareTo(max) > 0)
                    max = Maximo(hijo);
            }
            return max;
        }

        public class Arbol<T> where T : IComparable<T>
        {
            public Arbol(T valor, params Arbol<T>[] hijos)
            {
                Valor = valor;
                Hijos = hijos;
            }
            public Arbol<T>[] Hijos
            {
                get;
                private set;
            }
            public T Valor
            {
                get;
                private set;
            }
            public T Max
            {
                get
                {
                    T max = this.Valor;

                    foreach(var hijo in this.Hijos)
                    {
                        if (hijo.Max.CompareTo(max) > 0)
                            max = hijo.Max;
                    }
                    return max;
                }
            }
        }
    }
}
