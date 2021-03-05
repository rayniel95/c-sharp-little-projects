using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClasePracticaArboles_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<string> miArbol =
                new Arbol<string>("A",
                  new Arbol<string>("B",
                    new Arbol<string>("D"),
                    new Arbol<string>("E",
                      new Arbol<string>("H",
                        new Arbol<string>("K")
                      )
                    ),
                    new Arbol<string>("F",
                      new Arbol<string>("G"),
                      new Arbol<string>("I")
                    )
                  ),
                  new Arbol<string>("C")
                );
            //Console.WriteLine(miArbol.CantidadHojas);
            //Console.WriteLine(miArbol.Diametro);
            //Console.WriteLine(miArbol.SegundaAltura);
            //Console.WriteLine(miArbol.SonPrimos("H", "F"));
            //Console.WriteLine(miArbol.EsHermano("B", "C"));
            //Console.WriteLine(miArbol.EsAncestro("C", "B"));
            //Console.WriteLine(miArbol.Contains("h"));

            foreach (var el in miArbol.PostOrdenConYield())
                Console.WriteLine(el);



        }

        class Arbol<T>
        {
            
            public int Diametro
            {
                get
                {
                    int diametro = 0;
                    for(int nivel = 0; nivel < Altura; nivel++)
                    {
                        int nuevo = 0;
                        DiametroPorNivel(nivel, ref nuevo, 0, this);
                        if (nuevo > diametro)
                            diametro = nuevo;
                    }
                    return diametro;
                }
            }
            public int SegundaAltura
            {
                get
                {
                    int primeraAltura = 0;
                    int segundaAltura = 0;
                    SecundaAltura(ref primeraAltura, ref segundaAltura, 0, this);
                    return segundaAltura;
                }
            }
            void SecundaAltura(ref int alturaMax, ref int alturaMedia, int llamados, Arbol<T> arbolActual)
            {
                if(llamados > alturaMax)
                {
                    alturaMedia = alturaMax;
                    alturaMax = llamados;
                }
                foreach (var hijo in arbolActual.Hijos)
                    SecundaAltura(ref alturaMax, ref alturaMedia, llamados + 1, hijo);
            }
            void DiametroPorNivel(int nivel, ref int diametro, int llamados, Arbol<T> arbolActual)
            {
                if (llamados == nivel)
                {
                    diametro++;
                    return;
                }

                foreach(var hijo in arbolActual.Hijos)
                {
                    DiametroPorNivel(nivel, ref diametro, llamados + 1, hijo);
                }
            }
            public bool SonPrimos(T primero, T segundo)
            {
                Arbol<T> uno = new Arbol<T>(primero, new Arbol<T>[0]);
                Arbol<T> dos = new Arbol<T>(segundo, new Arbol<T>[0]);
                bool contienePrimero = false;
                bool contieneSegundo = false;

                foreach(var hijo in this.Hijos)
                {
                    if (hijo.Hijos.Contains(uno, new ArbolPorValorEqualityComparer()))
                        contienePrimero = true;
                    if (hijo.Hijos.Contains(dos, new ArbolPorValorEqualityComparer()))
                        contieneSegundo = true;
                    if (contienePrimero && contieneSegundo)
                        return true;
                }
                foreach(var hijo in this.Hijos)
                {
                    if (hijo.SonPrimos(primero, segundo)) return true;
                }
                return false;
            }
            class ArbolPorValorEqualityComparer : IEqualityComparer<Arbol<T>>
            {
                public bool Equals(Arbol<T> x, Arbol<T> y)
                {
                    return x.Valor.Equals(y.Valor);
                }

                public int GetHashCode(Arbol<T> obj)
                {
                    return obj.Valor.GetHashCode();
                }
            }
            public T Valor { get; set; }
            List<Arbol<T>> hijos = new List<Arbol<T>>();
            public bool EsHermano(T primero, T segundo)
            {
                Arbol<T> uno = new Arbol<T>(primero, new Arbol<T>[0]);
                Arbol<T> dos = new Arbol<T>(segundo, new Arbol<T>[0]);

                if (this.Hijos.Contains(uno, new ArbolPorValorEqualityComparer()) && this.Hijos.Contains(dos, new ArbolPorValorEqualityComparer()))
                    return true;
                foreach(var hijo in this.Hijos)
                {
                    if (hijo.EsHermano(primero, segundo)) return true;
                }
                return false;
            }
            public Arbol(T valor, params Arbol<T>[] hijos)
            {
                this.Valor = valor;
                this.hijos = new List<Arbol<T>>(hijos);
            }
            public bool EsAncestro(T quien, T deQuien)
            {
                if(this.Valor.Equals(quien))
                {
                    foreach(var hijo in this.Hijos)
                    {
                        if (hijo.Contains(deQuien)) return true;
                    }
                }
                else
                {
                    foreach(var hijo in this.Hijos)
                    {
                        if (hijo.EsAncestro(quien, deQuien)) return true;
                    }
                }
                return false;
            }
            public List<Arbol<T>> Hijos { get { return hijos; } }
            public bool Contains(T valor)
            {
                if (this.Valor.Equals(valor)) return true;
                foreach(var hijo in this.Hijos)
                {
                    if (hijo.Contains(valor)) return true;
                }
                return false;
            }

            public int TotalNodos
            {
                get
                {
                    int total = 1;
                    foreach (Arbol<T> a in Hijos)
                        total += a.TotalNodos;
                    return total;
                }
            }

            public int Altura
            {
                get
                {
                    if (Hijos.Count == 0) return 0;
                    else
                    {
                        int max = 0;
                        foreach (Arbol<T> a in Hijos)
                        {
                            int altura = a.Altura;
                            if (altura > max) max = altura;
                        }
                        return 1 + max;
                    }
                }
            }

            #region PREORDEN CON IENUMERATOR
            public IEnumerable<T> PreOrden()
            {
                return new PreOrdenEnumerable<T>(this);
            }

            class PreOrdenEnumerable<T1> : IEnumerable<T1>
            {
                Arbol<T1> a;
                public PreOrdenEnumerable(Arbol<T1> a)
                {
                    this.a = a;
                }
                public IEnumerator<T1> GetEnumerator()
                {
                    return new PreOrdenEnumerator<T1>(a);
                }
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
            class PreOrdenEnumerator<T2> : IEnumerator<T2>
            {
                public T2 Current { get; protected set; }
                Stack<Arbol<T2>> pila;
                public PreOrdenEnumerator(Arbol<T2> a)
                {
                    pila = new Stack<Arbol<T2>>();
                    pila.Push(a);
                }
                public bool MoveNext()
                {
                    if (pila.Count != 0)
                    {
                        Arbol<T2> cursor = pila.Pop();
                        Current = cursor.Valor;
                        if (cursor.Hijos != null)
                            //PARA QUE QUEDE EL 1ER HIJO EN EL TOPE DE LA PILA
                            for (int k = cursor.Hijos.Count - 1; k >= 0; k--)
                                pila.Push(cursor.Hijos[k]);
                        return true;
                    }
                    return false;
                }
                object IEnumerator.Current
                {
                    get { return Current; }
                }
                public void Reset() { }
                public void Dispose() { }
            }
            #endregion

            #region PREORDEN CON YIELD
            public IEnumerable<T> PostOrdenConYield()
            {
                foreach (Arbol<T> hijo in Hijos)
                    foreach (T valor in hijo.PostOrdenConYield())
                        yield return valor;
                yield return Valor;
            }
            public IEnumerable<T> PreOrdenConYield()
            {
                yield return Valor;
                foreach (Arbol<T> hijo in Hijos)
                    foreach (T valor in hijo.PreOrdenConYield())
                        yield return valor;
            }
            #endregion

            #region Imprime Arbol en Preorden
            public void Print()
            {
                Print(this, 0, '.');
            }

            void Print(Arbol<T> a, int tab, char tabSymbol)
            {
                for (int k = 0; k < tab; k++) Console.Write(tabSymbol);
                Console.WriteLine(a.Valor);
                foreach (Arbol<T> hijo in a.Hijos) Print(hijo, tab + 2, tabSymbol);
            }
            public int CantidadHojas
            {
                get
                {
                    int total = 1;
                    if (this.Hijos.Count > 0)
                    {
                        total = 0;
                        foreach(Arbol<T> hijo in this.Hijos)
                        {
                            total += hijo.CantidadHojas;
                        }
                    }
                    return total;
                }
            }
            #endregion
        }

    }
}
