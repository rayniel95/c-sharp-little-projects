using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgualdadArbolesBinarios_rec
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class ArbolBinario
        {
            /// Hijo izquierdo del Árbol
            public ArbolBinario Izquierdo { get; set; }
            /// Hijo derecho del Arbol
            public ArbolBinario Derecho { get; set; }
            /// Propiedad que permite saber si es hoja o no del Árbol.
            /// Si no tiene ni hijo izquierdo ni derecho es una hoja.
            public bool EsHoja
            {
                get { return Izquierdo == null && Derecho == null; }
            }
            /// Constructor por defecto.
            public ArbolBinario()
            {
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
    }
}
