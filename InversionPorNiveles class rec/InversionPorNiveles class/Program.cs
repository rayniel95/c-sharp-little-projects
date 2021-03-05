using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionPorNiveles_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<string> raiz = new Arbol<string>("a",
                new Arbol<string>("b",
                    new Arbol<string>("c", null),
                    new Arbol<string>("d",
                        new Arbol<string>("j",
                            new Arbol<string>("k", null),
                            new Arbol<string>("l", null)),
                        new Arbol<string>("k", null),
                        new Arbol<string>("s",
                            new Arbol<string>("c", null)))),
                new Arbol<string>("e",
                    new Arbol<string>("f", null),
                    new Arbol<string>("p", null)),
                new Arbol<string>("g",
                    new Arbol<string>("h",
                        new Arbol<string>("k", null),
                        new Arbol<string>("n", null)),
                    new Arbol<string>("i",
                        new Arbol<string>("q",
                            new Arbol<string>("n", null),
                            new Arbol<string>("r", null),
                            new Arbol<string>("b", null)),
                        new Arbol<string>("o", null))));

            PrintArbol(raiz, 0);

            Resuelve(raiz, new int[] { 1, 3 });

            PrintArbol(raiz, 0);
        }

        public static void Resuelve<T2>(Arbol<T2> arbol, int[] niveles)
        {
            foreach(var myNivel in niveles)
            {
                List<T2> myValores = new List<T2>();

                Cosecha(arbol, 0, myValores, myNivel);

                myValores.Reverse();
                int myContador = 0;

                Siembra(arbol, 0, myValores, myNivel, ref myContador);
            }
        }
        public static void Siembra<T5>(Arbol<T5> arbolActual, int llamado, List<T5> valores, int nivel, ref int cuantos)
        {
            if (llamado == nivel)
            {
                arbolActual.Valor = valores[cuantos];
                cuantos++;
            }
            foreach (var hijo in arbolActual.Hijos)
            {
                if(llamado + 1 <= nivel)
                    Siembra(hijo, llamado + 1, valores, nivel, ref cuantos);
            }
            
        }
        public static void Cosecha<T4>(Arbol<T4> arbolActual, int llamado, List<T4> valores, int nivel)
        {
            if (llamado == nivel)
                valores.Add(arbolActual.Valor);
            foreach (var hijo in arbolActual.Hijos)
            {
                if(llamado + 1 <= nivel)
                    Cosecha(hijo, llamado + 1, valores, nivel);
            }
        }

        public class Arbol<T1>
        {
            List<Arbol<T1>> hijos;

            public Arbol(T1 valor, params Arbol<T1>[] hijos)
            {
                Valor = valor;
                if (hijos == null)
                    this.hijos = new List<Arbol<T1>>();
                else
                    this.hijos = hijos.ToList();
            }
            public T1 Valor
            {
                get;
                set;
            }
            public List<Arbol<T1>> Hijos
            {
                get { return this.hijos; }
            }
        }

        public static void PrintArbol<T3>(Arbol<T3> arbolActual, int llamado)
        {
            for(int indice = 0; indice < llamado; indice++)
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
