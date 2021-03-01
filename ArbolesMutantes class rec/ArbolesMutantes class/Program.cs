using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesMutantes_class
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1 Metodos Auxiliares
            //ArbolBinario primero = new ArbolBinario(new ArbolBinario(), null);
            //ArbolBinario segundo = new ArbolBinario(new ArbolBinario(), null);

            //Console.WriteLine(ArbolesIguales(primero, segundo));
            #endregion
            #region Prueba2 Metodos Auxiliares
            //primero = new ArbolBinario(
            //                new ArbolBinario(
            //                    new ArbolBinario(), 
            //                new ArbolBinario()), null);
            //segundo = new ArbolBinario(new ArbolBinario(new ArbolBinario(), new ArbolBinario()), null);

            //Console.WriteLine(ArbolesIguales(primero, segundo));
            #endregion
            #region Prueba3 Metodos Auxiliares
            //primero = new ArbolBinario(
            //               new ArbolBinario(
            //                   new ArbolBinario(),
            //               new ArbolBinario()), new ArbolBinario(null, 
            //                                        new ArbolBinario()));
            //segundo = new ArbolBinario(
            //               new ArbolBinario(
            //                   new ArbolBinario(),
            //               new ArbolBinario()), new ArbolBinario(new ArbolBinario(),
            //                                        new ArbolBinario()));
            //Console.WriteLine(ArbolesIguales(primero, segundo));
            #endregion
            #region Prueba4 Metodos Auxiliares
            //primero = new ArbolBinario(
            //                new ArbolBinario(
            //                    new ArbolBinario(
            //                        new ArbolBinario(),
            //                        new ArbolBinario(
            //                            null,
            //                            new ArbolBinario(
            //                                new ArbolBinario(),
            //                                null))),
            //                    null),
            //                new ArbolBinario(
            //                    null,
            //                    new ArbolBinario(
            //                        new ArbolBinario(
            //                            null,
            //                            new ArbolBinario(
            //                                new ArbolBinario(),
            //                                null)),
            //                        new ArbolBinario())));
            //segundo = new ArbolBinario(
            //               new ArbolBinario(
            //                   new ArbolBinario(),
            //               new ArbolBinario()), new ArbolBinario(new ArbolBinario(),
            //                                        new ArbolBinario()));

            //Console.WriteLine(ArbolesIguales(primero, segundo));
            #endregion

            #region Prueba1
            //ArbolBinario primero = new ArbolBinario(
            //                            new ArbolBinario(
            //                                new ArbolBinario(),
            //                                new ArbolBinario()),
            //                            new ArbolBinario(
            //                                null,
            //                                new ArbolBinario()));

            //ArbolBinario segundo = new ArbolBinario(
            //                            new ArbolBinario(
            //                                new ArbolBinario(),
            //                                null),
            //                            new ArbolBinario(
            //                                new ArbolBinario(),
            //                                new ArbolBinario()));

            //Console.WriteLine(MinimoMutaciones(primero, segundo));

            #endregion
            #region Prueba2
            //ArbolBinario primero = new ArbolBinario(
            //                new ArbolBinario(
            //                    new ArbolBinario(
            //                        new ArbolBinario(
            //                            new ArbolBinario(
            //                                new ArbolBinario(),
            //                                null),
            //                            null),
            //                        new ArbolBinario()),
            //                    null),
            //                new ArbolBinario(
            //                    null,
            //                    new ArbolBinario(
            //                        new ArbolBinario(),
            //                        new ArbolBinario(
            //                            null,
            //                            new ArbolBinario(
            //                                null,
            //                                new ArbolBinario())))));
            //ArbolBinario segundo = new ArbolBinario(
            //            new ArbolBinario(
            //                new ArbolBinario(
            //                    new ArbolBinario(),
            //                    new ArbolBinario(
            //                        null,
            //                        new ArbolBinario(
            //                            new ArbolBinario(),
            //                            null))),
            //                null),
            //            new ArbolBinario(
            //                null,
            //                new ArbolBinario(
            //                    new ArbolBinario(
            //                        null,
            //                        new ArbolBinario(
            //                            new ArbolBinario(),
            //                            null)),
            //                    new ArbolBinario())));

            //Console.WriteLine(MinimoMutaciones(primero, segundo));

            #endregion

            //PrintPreOrden(primero);
            //Console.WriteLine();
            //PrintPreOrden(segundo);
        }

        public static bool ArbolesIguales(ArbolBinario primeroActual, ArbolBinario segundoActual)
        {
            if (primeroActual.EsHoja && segundoActual.EsHoja)
                return true;

            if (((primeroActual.Izquierdo != null && segundoActual.Izquierdo != null && ArbolesIguales(primeroActual.Izquierdo, segundoActual.Izquierdo)) ||
                (primeroActual.Izquierdo == null && segundoActual.Izquierdo == null)) && ((primeroActual.Derecho != null && segundoActual.Derecho != null && 
                ArbolesIguales(primeroActual.Derecho, segundoActual.Derecho)) || (primeroActual.Derecho == null && segundoActual.Derecho == null)))
                return true;

            return false;
        }
        public static int MinimoMutaciones(ArbolBinario uno, ArbolBinario dos)
        {
            int minimo = int.MaxValue;
            List<ArbolBinario> myLista = new List<ArbolBinario>();
            HazPreorden(uno, myLista);
            Resuelve(ref minimo, uno, dos, -1, myLista, 0);
            if (minimo == int.MaxValue)
                return -1;
            return minimo;
        }

        public static void Resuelve(ref int mejor, ArbolBinario primero, ArbolBinario segundo, int llamado, List<ArbolBinario> lista, int ultimoIndice)
        {
            if (ArbolesIguales(primero, segundo))
            {
                if (mejor > llamado)
                    mejor = llamado;
                return;
            }
            else if (ultimoIndice < lista.Count && lista[ultimoIndice].EsHoja) return;

            for(int indice = ultimoIndice; indice < lista.Count; indice++)
            {
                ArbolBinario temp = lista[indice].Izquierdo;
                lista[indice].Izquierdo = lista[indice].Derecho;
                lista[indice].Derecho = temp;

                Resuelve(ref mejor, primero, segundo, llamado + 1, lista, indice + 1);

                temp = lista[indice].Izquierdo;
                lista[indice].Izquierdo = lista[indice].Derecho;
                lista[indice].Derecho = temp;
            }
         
        }
        public static void HazPreorden(ArbolBinario arbol, List<ArbolBinario> lista)
        {
            lista.Add(arbol);
            if (arbol.Izquierdo != null) HazPreorden(arbol.Izquierdo, lista);
            if (arbol.Derecho != null) HazPreorden(arbol.Derecho, lista);
        }
        public class ArbolBinario
        {
            /// Hijo izquierdo del Árbol
            public ArbolBinario Izquierdo { get; set; }
            /// Hijo derecho del Arbol
            public ArbolBinario Derecho { get; set; }
            /// Propiedad que permite saber si es hoja o no del Árbol.
            /// Si no tiene ni hijo izquierdo ni derecho es una hoja.
            public bool EstaMutado { get; set; }
            public bool EsHoja
            {
                get { return Izquierdo == null && Derecho == null; }
            }
            /// Constructor por defecto.
            public ArbolBinario()
            {
                EstaMutado = false;
                Izquierdo = null;
                Derecho = null;
            }
            /// Constructor que tiene como parámetros los hijos izquierdo
            /// y derecho.
            public ArbolBinario(ArbolBinario izquierdo, ArbolBinario derecho)
            {
                Izquierdo = izquierdo;
                Derecho = derecho;
            }
        }
    }
}
