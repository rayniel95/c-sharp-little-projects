using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboreando_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba1
            ArbolBinario<int> uno = new ArbolBinario<int>(5,
                                            new ArbolBinario<int>(8,
                                                new ArbolBinario<int>(13)),
                                            new ArbolBinario<int>(9,
                                                new ArbolBinario<int>(2),
                                                new ArbolBinario<int>(6)));

            ArbolBinario<int> dos = new ArbolBinario<int>(2,
                                        new ArbolBinario<int>(1),
                                        new ArbolBinario<int>(4));

            Arborear(uno, dos, Suma);

            PrintArbol(uno, 0);

            Console.WriteLine();

            // prueba2
            ArbolBinario<string> primero = new ArbolBinario<string>("ti",
                                            new ArbolBinario<string>("la"));

            ArbolBinario<string> segundo = new ArbolBinario<string>("na",
                                                new ArbolBinario<string>("ti", null,
                                                        new ArbolBinario<string>("nce")),
                                                new ArbolBinario<string>("ss", null,
                                                    new ArbolBinario<string>("pri")));

            Arborear(primero, segundo, Concatena);

            PrintArbol(primero, 0);

        }
        public static string Concatena(string u, string d)
        {
            return u + d;
        }
        public static int Suma(int s, int q)
        {
            return s + q;
        }

        public static ArbolBinario<T3> Arborear<T3>(ArbolBinario<T3> primero, ArbolBinario<T3> segundo, Opera<T3> operacion)
        {
            int altura = Altura(primero);

            for(int nivel = 0; nivel <= altura; nivel++)
            {
                List<ArbolBinario<T3>> arbolesNivel = new List<ArbolBinario<T3>>();

                PreOrdenPorNivel(primero, 0, nivel, arbolesNivel);

                foreach(var arbol in arbolesNivel)
                {
                    Aplica(arbol, segundo, operacion);
                }
            }
            return primero;

        }


        public static void Aplica<T5>(ArbolBinario<T5> primero, ArbolBinario<T5> segundo, Opera<T5> opera)
        {
            primero.Valor = opera(primero.Valor, segundo.Valor);

            if (primero.Izquierdo != null && segundo.Izquierdo != null)
                Aplica(primero.Izquierdo, segundo.Izquierdo, opera);
            if (primero.Derecho != null && segundo.Derecho != null)
                Aplica(primero.Derecho, segundo.Derecho, opera);

        }
        public static void PreOrdenPorNivel<T4>(ArbolBinario<T4> arbol, int llamado, int nivel, List<ArbolBinario<T4>> lista)
        {
            if(llamado == nivel)
            {
                lista.Add(arbol);
                return;
            }
            if (arbol.Izquierdo != null)
                PreOrdenPorNivel(arbol.Izquierdo, llamado + 1, nivel, lista);
            if (arbol.Derecho != null)
                PreOrdenPorNivel(arbol.Derecho, llamado + 1, nivel, lista);
        }
        public static int Altura<T6>(ArbolBinario<T6> arbol)
        {
            int altura = 0;
            if(arbol.Izquierdo != null)
            {
                if (Altura(arbol.Izquierdo) > altura)
                    altura = Altura(arbol.Izquierdo);
            }
            if(arbol.Derecho != null)
            {
                if (Altura(arbol.Derecho) > altura)
                    altura = Altura(arbol.Derecho);
            }
            return 1 + altura;
        }
        public static void PrintArbol<T7>(ArbolBinario<T7> arbolActual, int llamado)
        {
            for(int nivel = 0; nivel <= llamado; nivel++)
                Console.Write("-");
            Console.Write(arbolActual.Valor);
            Console.WriteLine();

            if (arbolActual.Izquierdo != null)
                PrintArbol(arbolActual.Izquierdo, llamado + 1);
            if (arbolActual.Derecho != null)
                PrintArbol(arbolActual.Derecho, llamado + 1);
        }
        public class ArbolBinario<T1>
        {
            public ArbolBinario(T1 valor, ArbolBinario<T1> izquierdo = null, ArbolBinario<T1> derecho = null)
            {
                Valor = valor;
                Izquierdo = izquierdo;
                Derecho = derecho;
            }
            public T1 Valor { get; set; }
            public ArbolBinario<T1> Izquierdo { get; private set; }
            public ArbolBinario<T1> Derecho { get; private set; }

        }

        public delegate T2 Opera<T2>(T2 primero, T2 segundo);
    }
}
