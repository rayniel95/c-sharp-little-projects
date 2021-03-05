using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiferenciaArboles_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //Arbol<string> primero = new Arbol<string>("a",
            //                                new Arbol<string>("b"));

            //Arbol<string> segundo = new Arbol<string>("a",
            //                                new Arbol<string>("c"));

            //Console.WriteLine(Diferencia(primero, segundo));

            #endregion

            #region Prueba2

            //Arbol<int> primero = new Arbol<int>(2,
            //                            new Arbol<int>(7),
            //                            new Arbol<int>(15,
            //                                new Arbol<int>(9),
            //                                new Arbol<int>(20)));
            //Arbol<int> segundo = new Arbol<int>(2,
            //                            new Arbol<int>(15,
            //                                new Arbol<int>(20)),
            //                            new Arbol<int>(10));

            //Console.WriteLine(Diferencia(primero, segundo));


            #endregion

            #region Prueba3

            Arbol<object> primero = new Arbol<object>("a",
                                            new Arbol<object>(9,
                                                new Arbol<object>("i",
                                                    new Arbol<object>("k"))));
            Arbol<object> segundo = new Arbol<object>("a",
                                            new Arbol<object>("b"));

            Console.WriteLine(Diferencia(primero, segundo));


            #endregion

        }

        public static int Diferencia<T1>(Arbol<T1> primero, Arbol<T1> segundo)
        {
            int alturaPrimero = 0;
            NivelArbol(primero, ref alturaPrimero, 0);

            int alturaSegundo = 0;
            NivelArbol(segundo, ref alturaSegundo, 0);

            int diferencia = 0;

            for(int nivel = 1; nivel <= Math.Max(alturaPrimero, alturaSegundo); nivel++)
            {
                List<T1> valoresPrimero = new List<T1>();
                List<T1> valoresSegundo = new List<T1>();

                PreOrdenNivel(primero, valoresPrimero, 0, nivel);
                PreOrdenNivel(segundo, valoresSegundo, 0, nivel);

                diferencia += Diferencia(valoresPrimero, valoresSegundo);
            }
            return diferencia;
        }
        public static int Diferencia<T4>(List<T4> primera, List<T4> segunda)
        {
            int diferencia = 0;
            foreach(var element in primera)
            {
                if (!segunda.Contains(element))
                    diferencia++;
            }
            foreach(var element in segunda)
            {
                if (!primera.Contains(element))
                    diferencia++;
            }
            return diferencia;
        }
        public static void PreOrdenNivel<T3>(Arbol<T3> arbolActual, List<T3> valoresNivel, int llamado, int nivel)
        {
            if (llamado == nivel)
            {
                valoresNivel.Add(arbolActual.Valor);
                return;
            }
            else if (llamado > nivel)
                return;
            foreach (var hijo in arbolActual.Hijos)
                PreOrdenNivel(hijo, valoresNivel, llamado + 1, nivel);
        }
        public static void NivelArbol<T2>(Arbol<T2> arbolActual, ref int nivel, int llamado)
        {
            if (llamado > nivel)
                nivel = llamado;
            foreach (var hijo in arbolActual.Hijos)
                NivelArbol(hijo, ref nivel, llamado + 1);
        }
        public class Arbol<T>
        {
            public T Valor
            { private set; get; }
            public List<Arbol<T>> Hijos
            { private set; get; }
            public Arbol(T valor, params Arbol<T>[] hijos)
            {
                Valor = valor;
                Hijos = new List<Arbol<T>>(hijos);
            }
        }
    }
}
