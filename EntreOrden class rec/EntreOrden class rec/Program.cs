using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreOrden_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //ArbolBinario<int> myArbol = new ArbolBinario<int>(1,
            //                                    new ArbolBinario<int>(2,
            //                                        new ArbolBinario<int>(3),
            //                                        new ArbolBinario<int>(4)),
            //                                    new ArbolBinario<int>(5, 
            //                                    new ArbolBinario<int>(9),
            //                                    new ArbolBinario<int>(6)));
            //List<ArbolBinario<int>> myLista = new List<ArbolBinario<int>>();
            //HazEntreOrden(myArbol, myLista);
            //PrintLista(myLista);
            #endregion
            #region Prueba2
            //ArbolBinario<string> myArbol = new ArbolBinario<string>("*",
            //                                        new ArbolBinario<string>("-",
            //                                            new ArbolBinario<string>("a"),
            //                                            new ArbolBinario<string>("b")),
            //                                        new ArbolBinario<string>("*",
            //                                            new ArbolBinario<string>("+",
            //                                                new ArbolBinario<string>("c"),
            //                                                new ArbolBinario<string>("3")),
            //                                            new ArbolBinario<string>("%",
            //                                                new ArbolBinario<string>("e"),
            //                                                new ArbolBinario<string>("2"))));

            //List<ArbolBinario<string>> myLista = new List<ArbolBinario<string>>();
            //HazEntreOrden(myArbol, myLista);
            //PrintLista(myLista);

            #endregion


        }

        public static void HazEntreOrden<T3>(ArbolBinario<T3> arbolActual, List<ArbolBinario<T3>> lista)
        {
            if (arbolActual.HijoIzq != null)
                HazEntreOrden(arbolActual.HijoIzq, lista);

            lista.Add(arbolActual);

            if (arbolActual.HijoDer != null)
                HazEntreOrden(arbolActual.HijoDer, lista);

        }
        public static void PrintLista<T2>(List<ArbolBinario<T2>> myLista)
        {
            foreach(var arbol in myLista)
            {
                Console.WriteLine(arbol.Valor);
                
            }
        }
        public class ArbolBinario<T1>
        {
            public ArbolBinario(T1 valor, ArbolBinario<T1> hijoIzq=null, ArbolBinario<T1> hijoDer=null)
            {
                Valor = valor;
                HijoIzq = hijoIzq;
                HijoDer = hijoDer;
            }
            public T1 Valor { get; set; }
            public ArbolBinario<T1> HijoIzq { get; set; }
            public ArbolBinario<T1> HijoDer { get; set; }
        }

    }
}
