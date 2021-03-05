using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionArbol_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //Arbol<int> myArbol = new Arbol<int>(1,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4)),
            //                            new Arbol<int>(7,
            //                                new Arbol<int>(6,
            //                                    new Arbol<int>(9)),
            //                                new Arbol<int>(8)));

            //List<Arbol<int>> myLista = InvierteArbol(myArbol);

            //PrintArbolNivel(myLista);

            #endregion
            #region Prueba2
            //Arbol<int> myArbol = new Arbol<int>(1,
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(3),
            //                                new Arbol<int>(4)),
            //                            new Arbol<int>(7,
            //                                new Arbol<int>(6,
            //                                    new Arbol<int>(9)),
            //                                new Arbol<int>(8,
            //                                    new Arbol<int>(10))));

            //List<Arbol<int>> myLista = InvierteArbol(myArbol);

            //PrintArbolNivel(myLista);


            #endregion
         
        }

        public static List<Arbol<T8>> InvierteArbol<T8>(Arbol<T8> arbol)
        {
            List<Arbol<T8>> myLista = new List<Arbol<T8>>();
            Resuelve(arbol, new Stack<Arbol<T8>>(), Altura(arbol), 0, myLista);

            return myLista;
        }
        public static void Resuelve<T3>(Arbol<T3> arbolActual, Stack<Arbol<T3>> pila, int altura, int llamado, List<Arbol<T3>> lista)
        {
            pila.Push(arbolActual);

            foreach(var hijo in arbolActual.HijosCopia)
            {
                Resuelve(hijo, pila, altura, llamado + 1, lista);
            }

            if(llamado == altura)
            {
                lista.Add(arbolActual);
                Invierte(pila);
            }
            pila.Pop();
        }
        public static int Altura<T2>(Arbol<T2> arbol)
        {
            int alt = 0;

            Altura(arbol, 0, ref alt);

            return alt;
        }
        public static void Altura<T7>(Arbol<T7> arbolActual, int llamado, ref int mejor)
        {
            if (llamado > mejor)
                mejor = llamado;
            foreach (var hijo in arbolActual.Hijos)
                Altura(hijo, llamado + 1, ref mejor);
        }
        public static void Invierte<T4>(Stack<Arbol<T4>> myPila)
        {
            List<Arbol<T4>> lista = myPila.ToList();

            for(int indice = 0; indice < lista.Count; indice++)
            {
                if(indice == 0)
                {
                    lista[indice].Hijos.Add(lista[indice + 1]);
                    lista[indice + 1].Hijos.RemoveAt(BuscaIndice(lista[indice + 1].Hijos, lista[indice]));
                }
                else if(indice > 0 && indice < lista.Count - 1)
                {
                    if(lista[indice].Hijos.Contains(lista[indice - 1], new ReferenciaEqualityComparer<T4>()))
                    {
                        lista[indice].Hijos.RemoveAt(BuscaIndice(lista[indice].Hijos, lista[indice - 1]));
                    }
                    if(!lista[indice].Hijos.Contains(lista[indice + 1], new ReferenciaEqualityComparer<T4>()))
                    {
                        lista[indice].Hijos.Add(lista[indice + 1]);
                    }
                }
                else if(indice == lista.Count - 1)
                {
                    if(lista[indice].Hijos.Contains(lista[indice - 1], new ReferenciaEqualityComparer<T4>()))
                    {
                        lista[indice].Hijos.RemoveAt(BuscaIndice(lista[indice].Hijos, lista[indice - 1]));
                    }
                }
            }
        }

        public class ReferenciaEqualityComparer<T9> : IEqualityComparer<Arbol<T9>>
        {
            public bool Equals(Arbol<T9> x, Arbol<T9> y)
            {
                return x == y;
            }

            public int GetHashCode(Arbol<T9> obj)
            {
                return obj.GetHashCode();
            }
        }
        public static int BuscaIndice<T6>(List<Arbol<T6>> myLista, Arbol<T6> buscado)
        {
            for(int indice = 0; indice < myLista.Count; indice++)
            {
                if (myLista[indice] == buscado)
                    return indice;
            }
            return -1;
        }
        public class Arbol<T1>
        {
            List<Arbol<T1>> hijos;
            public Arbol(T1 valor, params Arbol<T1>[] hijos)
            {
                Valor = valor;
                this.hijos = hijos.ToList();
            }
            public T1 Valor { get; private set; }
            public List<Arbol<T1>> HijosCopia
            {
                get { return new List<Arbol<T1>>(this.hijos); }
            }
            public List<Arbol<T1>> Hijos { get { return this.hijos; } }
        }
        public static void PrintArbolNivel<T11>(List<Arbol<T11>> listaArbol)
        {
            int altura = Altura(listaArbol[0]);

            for(int nivel = 0; nivel <= altura; nivel++)
            {
                foreach(var arbol in listaArbol)
                {
                    List<Arbol<T11>> myLista = new List<Arbol<T11>>();

                    HazALoAncho(arbol, myLista, 0, nivel);

                    PrintLista(myLista);
                }
            }
        }

        public static void HazALoAncho<T12>(Arbol<T12> arbolActual, List<Arbol<T12>> lista, int llamado, int nivel)
        {
            if (llamado == nivel)
            {
                lista.Add(arbolActual);
                return;
            }
            foreach (var hijo in arbolActual.Hijos)
                HazALoAncho(hijo, lista, llamado + 1, nivel);
        }
        public static void PrintLista<T13>(List<Arbol<T13>> myLista)
        {
            foreach(var el in myLista)
            {
                Console.Write(el.Valor);
            }
            Console.WriteLine();
        }
    }
}
