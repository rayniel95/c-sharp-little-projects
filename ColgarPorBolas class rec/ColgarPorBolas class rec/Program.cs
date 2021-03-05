using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColgarPorBolas_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba1
            Arbol<int> myArbol = new Arbol<int>(1,
                                        new Arbol<int>(2,
                                            new Arbol<int>(5,
                                                new Arbol<int>(8),
                                                new Arbol<int>(9,
                                                    new Arbol<int>(10,
                                                        new Arbol<int>(11),
                                                        new Arbol<int>(12,
                                                            new Arbol<int>(13)))))),
                                        new Arbol<int>(3,
                                            new Arbol<int>(6),
                                            new Arbol<int>(7)),
                                        new Arbol<int>(4));
            bool seEncontro = false;
            Resuelve(myArbol, myArbol, ref seEncontro, 10, ref myArbol);
            PrintArbol(myArbol, 0);


        }

        public static void Resuelve<T4>(Arbol<T4> arbolActual, Arbol<T4> padre, ref bool encontrado, T4 buscado, ref Arbol<T4> raiz)
        {
            if (arbolActual.Valor.Equals(buscado))
            {
                raiz = arbolActual;
                encontrado = true;

                if (encontrado)
                {
                    arbolActual.Hijos.Insert(0, padre);

                    int indiceHijo = 0;

                    for (int indice = 0; indice < padre.Hijos.Count; indice++)
                    {
                        if (padre.Hijos[indice] == arbolActual)
                        {
                            indiceHijo = indice;
                            break;
                        }
                    }
                    padre.Hijos.RemoveAt(indiceHijo);
                    return;
                }
            }
            List<Arbol<T4>> copiaHijos = new List<Arbol<T4>>(arbolActual.Hijos);
            foreach(var hijo in copiaHijos)
            {

                Resuelve(hijo, arbolActual, ref encontrado, buscado, ref raiz);

                if (encontrado)
                {
                    arbolActual.Hijos.Insert(0, padre);

                    int indiceHijo = 0;

                    for (int indice = 0; indice < padre.Hijos.Count; indice++)
                    {
                        if (padre.Hijos[indice] == arbolActual)
                        {
                            indiceHijo = indice;
                            break;
                        }
                    }
                    padre.Hijos.RemoveAt(indiceHijo);
                    return;
                }

            }


        }
        public static void PrintArbol<T3>(Arbol<T3> arbolActual, int llamado) where T3 : IComparable<T3>
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

        public class Arbol<T1>
        {
            public Arbol(T1 valor, params Arbol<T1>[] hijos)
            {
                Valor = valor;
                Hijos = hijos.ToList();
            }
            public T1 Valor { get; private set; }
            public List<Arbol<T1>> Hijos { get; private set; }
        }
    }
}
