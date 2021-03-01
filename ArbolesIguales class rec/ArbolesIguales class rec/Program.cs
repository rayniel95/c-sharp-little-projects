using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesIguales_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //Arbol<int> primero = new Arbol<int>(1,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(2),
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4)),
            //                            new Arbol<int>(3,
            //                                new Arbol<int>(5)),
            //                            new Arbol<int>(4,
            //                                new Arbol<int>(6),
            //                                new Arbol<int>(8)));

            //Arbol<int> segundo = new Arbol<int>(10,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)),
            //                            new Arbol<int>(1,
            //                                new Arbol<int>(2)),
            //                            new Arbol<int>(3,
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)));

            //Console.WriteLine(SonIguales(primero, segundo));

            #endregion
            #region Prueba2

            //Arbol<int> primero = new Arbol<int>(1,
            //                         new Arbol<int>(2,
            //                             new Arbol<int>(2),
            //                             new Arbol<int>(3),
            //                             new Arbol<int>(4)),
            //                         new Arbol<int>(3,
            //                             new Arbol<int>(5)),
            //                         new Arbol<int>(4,
            //                             new Arbol<int>(6),
            //                             new Arbol<int>(8)));

            //Arbol<int> segundo = new Arbol<int>(10,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)),
            //                            new Arbol<int>(1,
            //                                new Arbol<int>(2)),
            //                            new Arbol<int>(3,
            //                                new Arbol<int>(4)));

            //Console.WriteLine(SonIguales(primero, segundo));

            #endregion
            #region Prueba3

            //Arbol<int> primero = new Arbol<int>(1,
            //                         new Arbol<int>(2,
            //                             new Arbol<int>(2),
            //                             new Arbol<int>(3),
            //                             new Arbol<int>(4)),
            //                         new Arbol<int>(3,
            //                             new Arbol<int>(5)),
            //                         new Arbol<int>(4,
            //                             new Arbol<int>(6),
            //                             new Arbol<int>(8)));

            //Arbol<int> segundo = new Arbol<int>(10,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)),
            //                            new Arbol<int>(1),
            //                            new Arbol<int>(3,
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)));

            //Console.WriteLine(SonIguales(primero, segundo));


            #endregion
            #region Prueba4

            //Arbol<int> primero = new Arbol<int>(1,
            //                         new Arbol<int>(2,
            //                             new Arbol<int>(2),
            //                             new Arbol<int>(3),
            //                             new Arbol<int>(4)),
            //                         new Arbol<int>(3,
            //                             new Arbol<int>(5,
            //                                new Arbol<int>(3))),
            //                         new Arbol<int>(4,
            //                             new Arbol<int>(6),
            //                             new Arbol<int>(8)));

            //Arbol<int> segundo = new Arbol<int>(10,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)),
            //                            new Arbol<int>(1,
            //                                new Arbol<int>(2,
            //                                    new Arbol<int>(4))),
            //                            new Arbol<int>(3,
            //                                new Arbol<int>(4),
            //                                new Arbol<int>(5)));

            //Console.WriteLine(SonIguales(primero, segundo));


            #endregion
        }
        public static bool SonIguales<T3>(Arbol<T3> uno, Arbol<T3> dos)
        {
            bool iguales = true;

            Resuelve(uno, dos, ref iguales);

            return iguales;
        }
        public static void Resuelve<T2>(Arbol<T2> primero, Arbol<T2> segundo, ref bool sonIguales)
        {
            if(primero.Hijos.Length != segundo.Hijos.Length)
            {
                sonIguales = false;
                return;
            }

            for(int indice = 0; indice < primero.Hijos.Length; indice++)
            {
                Resuelve(primero.Hijos[indice], segundo.Hijos[indice], ref sonIguales);
            }
        }

        public class Arbol<T1>
        {
            public Arbol(T1 valor, params Arbol<T1>[] hijos)
            {
                Valor = valor;
                Hijos = hijos;
            }
            public Arbol<T1>[] Hijos { get; private set; }
            public T1 Valor { get; private set; }
        }
    }
}
