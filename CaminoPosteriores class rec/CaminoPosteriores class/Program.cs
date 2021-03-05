using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Arboles;

namespace CaminoPosteriores_class
{
    class Program
    {
        static void Main(string[] args)
        {

            Arbol<int> myArbol = new Arbol<int>(2,
                                        new Arbol<int>(23,
                                            new Arbol<int>(3,
                                                new Arbol<int>(31,
                                                    new Arbol<int>(40,
                                                        new Arbol<int>(48,
                                                            new Arbol<int>[0]),
                                                        new Arbol<int>(41,
                                                            new Arbol<int>[0]))),
                                                new Arbol<int>(32,
                                                    new Arbol<int>[0])),
                                            new Arbol<int>(6,
                                                new Arbol<int>(61,
                                                    new Arbol<int>(77,
                                                        new Arbol<int>[0]),
                                                    new Arbol<int>(67,
                                                        new Arbol<int>(15,
                                                            new Arbol<int>(23,
                                                                new Arbol<int>[0])),
                                                        new Arbol<int>(39,
                                                            new Arbol<int>[0]))))),
                                        new Arbol<int>(22,
                                            new Arbol<int>(4,
                                                new Arbol<int>[0]),
                                            new Arbol<int>(8,
                                                new Arbol<int>(82,
                                                    new Arbol<int>[0]),
                                                new Arbol<int>(84,
                                                    new Arbol<int>(99,
                                                        new Arbol<int>[0]),
                                                    new Arbol<int>(42,
                                                        new Arbol<int>(52,
                                                            new Arbol<int>[0]),
                                                        new Arbol<int>(57,
                                                            new Arbol<int>[0])))),
                                            new Arbol<int>(5, 
                                                new Arbol<int>(55,
                                                    new Arbol<int>(88,
                                                        new Arbol<int>[0]),
                                                    new Arbol<int>(100,
                                                        new Arbol<int>(43,
                                                            new Arbol<int>[0]),
                                                        new Arbol<int>(18,
                                                            new Arbol<int>(28,
                                                                new Arbol<int>[0]))),
                                                    new Arbol<int>(66,
                                                        new Arbol<int>[0])),
                                                new Arbol<int>(59,
                                                    new Arbol<int>(102,
                                                        new Arbol<int>(0,
                                                            new Arbol<int>[0]),
                                                        new Arbol<int>(50,
                                                            new Arbol<int>[0]))))),
                                        new Arbol<int>(21, 
                                            new Arbol<int>(1,
                                                new Arbol<int>[0]),
                                            new Arbol<int>(9,
                                                new Arbol<int>(90,
                                                    new Arbol<int>(33,
                                                        new Arbol<int>[0])))),
                                        new Arbol<int>(24,
                                            new Arbol<int>(7,
                                                new Arbol<int>[0]),
                                            new Arbol<int>(3,
                                                new Arbol<int>(30,
                                                    new Arbol<int>[0])),
                                            new Arbol<int>(10,
                                                new Arbol<int>(11,
                                                    new Arbol<int>(22,
                                                        new Arbol<int>[0]),
                                                    new Arbol<int>(44,
                                                        new Arbol<int>[0])))));

            //PrintArbol(myArbol, 0);

            foreach(var el in Camino(myArbol, 2))
                Console.WriteLine(el);
            Console.WriteLine();
            foreach(var el in Posteriores(myArbol, 2))
                Console.WriteLine(el);

        }



        public static IEnumerable<T2> Camino<T2>(Arbol<T2> arbol, T2 myValor)
        {
            List<T2> myCamino = new List<T2>();
            myCamino.Add(arbol.Valor);
            if (Resuelve<T2>(arbol, myCamino, myValor))
                return myCamino;
            return null;
        }

        public static IEnumerable<T4> Posteriores<T4>(Arbol<T4> arbol, T4 myValor)
        {
            IEnumerable<T4> camino = Camino(arbol, myValor);

            List<T4> myPosteriores = new List<T4>();

            if (camino.Count() > 0)
            {
                Posteriores(arbol, camino, myPosteriores, 1);
                return myPosteriores;
            }
            return null;

        }
        public static bool Resuelve<T1>(Arbol<T1> arbolActual, List<T1> caminoActual, T1 valor)
        {
            if(arbolActual.Valor.Equals(valor))
            {
                return true;
            }
            foreach(var hijo in arbolActual.Hijos)
            {
                caminoActual.Add(hijo.Valor);
                if (Resuelve(hijo, caminoActual, valor))
                    return true;
                caminoActual.RemoveAt(caminoActual.Count - 1);
            }
            return false;
        }
        public static void Posteriores<T3>(Arbol<T3> arbolActual, IEnumerable<T3> camino, List<T3> posteriores, int llamado)
        {
            if(llamado <= camino.Count() - 1)
            {
                bool agrega = false;

                foreach (var hijo in arbolActual.Hijos)
                {
                    if (agrega)
                        AgregaDerecha(hijo, posteriores);

                    if (hijo.Valor.Equals(camino.ElementAt(llamado)))
                    {
                        agrega = true;
                        Posteriores(hijo, camino, posteriores, llamado + 1);
                    }
                }
            }
        }
        public static void AgregaDerecha<T2>(Arbol<T2> arbol, List<T2> lista)
        {
            lista.Add(arbol.Valor);
            foreach (var hijo in arbol.Hijos)
                AgregaDerecha(hijo, lista);
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
    }
}
