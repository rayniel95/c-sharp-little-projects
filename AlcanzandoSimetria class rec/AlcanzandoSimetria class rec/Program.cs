using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanzandoSimetria_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //ArbolBinario myArbol = new ArbolBinario(1,
            //                            new ArbolBinario(2,
            //                                new ArbolBinario(3,
            //                                    new ArbolBinario(4, null, null),
            //                                    new ArbolBinario(5, null, null)), null),
            //                            new ArbolBinario(6, null,
            //                                new ArbolBinario(7,
            //                                    new ArbolBinario(8, null,
            //                                        new ArbolBinario(9, null, null)), null)));

            //Console.WriteLine(MinimoInserciones1(myArbol));
            //Console.WriteLine(MinimoInserciones2(myArbol));

            //PrintArbol(myArbol, 0);


            #endregion
            #region Prueba2

            ArbolBinario myArbol = new ArbolBinario(1,
                                        new ArbolBinario(2,
                                            new ArbolBinario(3, null, null),
                                            new ArbolBinario(4,
                                                new ArbolBinario(5, null, null), null)),
                                        new ArbolBinario(6, null,
                                            new ArbolBinario(7, null, null)));

            Console.WriteLine(MinimoInserciones1(myArbol));
            Console.WriteLine(MinimoInserciones2(myArbol));




            #endregion




        }


        public static int MinimoInserciones1(ArbolBinario arbol)
        {
            int cuantos = 0;

            Resuelve1(arbol, arbol, ref cuantos);

            return cuantos;
         
        }
        public static int MinimoInserciones2(ArbolBinario arbol)
        {
            int altura = 0;
            Altura(arbol, 0, ref altura);
            List<ArbolBinario> nueva = new List<ArbolBinario>();
            nueva.Add(arbol);
            return Resuelve2(nueva, altura, 0, 0);
        }

        public static int Resuelve2(List<ArbolBinario> listaArboles, int altura, int llamado, int diferencia)
        {
            if (llamado > altura)
                return diferencia;

            List<ArbolBinario> nueva = new List<ArbolBinario>();

            foreach(var arbol in listaArboles)
            {
                if(arbol == null)
                {
                    nueva.Add(null);
                    nueva.Add(null);
                    continue;
                }
                nueva.Add(arbol.HijoIzq);
                nueva.Add(arbol.HijoDer);

            }

            diferencia += BuscaDiferencia(listaArboles.ToArray());

            return Resuelve2(nueva, altura, llamado + 1, diferencia);
        }
        public static void Resuelve1(ArbolBinario arbolIzq, ArbolBinario arbolDer, ref int contador)
        {
            if ((arbolDer == null && arbolIzq != null) || (arbolIzq == null && arbolDer != null))
                contador++;

            if (arbolIzq != null && arbolDer == null)
                Resuelve1(arbolIzq.HijoIzq, null, ref contador);
            else if (arbolIzq == null && arbolDer != null)
                Resuelve1(null, arbolDer.HijoDer, ref contador);
            else if (arbolIzq != null && arbolDer != null)
                Resuelve1(arbolIzq.HijoIzq, arbolDer.HijoDer, ref contador);

            if (arbolIzq == arbolDer) return;

            if (arbolIzq != null && arbolDer == null)
                Resuelve1(arbolIzq.HijoDer, null, ref contador);
            else if (arbolIzq == null && arbolDer != null)
                Resuelve1(null, arbolDer.HijoIzq, ref contador);
            else if (arbolIzq != null && arbolDer != null)
                Resuelve1(arbolIzq.HijoDer, arbolDer.HijoIzq, ref contador);
        }
        public static void Altura(ArbolBinario arbolActual, int llamado, ref int mayor)
        {
            if (llamado > mayor)
                mayor = llamado;
            if (arbolActual.HijoIzq != null)
                Altura(arbolActual.HijoIzq, llamado + 1, ref mayor);
            if (arbolActual.HijoDer != null)
                Altura(arbolActual.HijoDer, llamado + 1, ref mayor);

        }

        public static int BuscaDiferencia(ArbolBinario[] array)
        {
            int contador = 0;

            for(int indice = 0; indice < array.Length; indice++)
            {
                if(array[indice] == null && array[array.Length - 1 - indice] != null || 
                    array[indice] != null && array[array.Length - 1 - indice] == null)
                {
                    contador++;
                }
            }
            return contador/2;
        }

        public static void PrintArbol(ArbolBinario arbolActual, int llamado)
        {
            for(int veces = 0; veces <= llamado; veces++)
            {
                Console.Write("-");
            }
            Console.Write(arbolActual.Valor);
            Console.WriteLine();
            if (arbolActual.HijoIzq != null)
                PrintArbol(arbolActual.HijoIzq, llamado + 1);
            if (arbolActual.HijoDer != null)
                PrintArbol(arbolActual.HijoDer, llamado + 1);
        }
        public class ArbolBinario
        {
            public ArbolBinario(int valor, ArbolBinario hijoIzq, ArbolBinario hijoDer)
            {
                Valor = valor;
                HijoDer = hijoDer;
                HijoIzq = hijoIzq;
            }
            public int Valor { get; private set; }
            public ArbolBinario HijoDer { get; private set; }
            public ArbolBinario HijoIzq { get; private set; }
        }

    }
}
