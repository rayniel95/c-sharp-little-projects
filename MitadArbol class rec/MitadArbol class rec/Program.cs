using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibEjercicioMitad;

namespace MitadArbol_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //Arbol<int> a = new Arbol<int>(5,
            //                    new Arbol<int>(1,
            //                        new Arbol<int>(2,
            //                            new Arbol<int>(3),
            //                            new Arbol<int>(9))),
            //                    new Arbol<int>(7),
            //                    new Arbol<int>(2,
            //                        new Arbol<int>(5),
            //                        new Arbol<int>(4)));

            //Console.WriteLine("Mitad(A) : " + ComoTexto(Resuelve(a)));

            #endregion
            #region Prueba2
            //Arbol<int> t = new Arbol<int>(4,
            //                    new Arbol<int>(4),
            //                    new Arbol<int>(2,
            //                        new Arbol<int>(1),
            //                        new Arbol<int>(4,
            //                            new Arbol<int>(4),
            //                            new Arbol<int>(2,
            //                                new Arbol<int>(1),
            //                                new Arbol<int>(7),
            //                                new Arbol<int>(9))),
            //                        new Arbol<int>(7),
            //                        new Arbol<int>(9)));

            //Console.WriteLine("Mitad(T) : " + ComoTexto(Resuelve(t)));

            #endregion
            #region Prueba3
            //Arbol<int> o = new Arbol<int>(6,
            //                    new Arbol<int>(6),
            //                    new Arbol<int>(6,
            //                        new Arbol<int>(6)));
       
            //Console.WriteLine("Mitad(O) : " + ComoTexto(Resuelve(o)));

            #endregion


        }

        public static Arbol<T5> Resuelve<T5>(Arbol<T5> arbol)
        {
            List<Arbol<T5>> preOrden = PreOrden(arbol);

            for (int indice = 1; indice < preOrden.Count; indice++)
            {
                if (Resuelve(arbol, preOrden[indice], preOrden[indice]))
                    return preOrden[indice];
            }
            return null;
        }
        public static bool Resuelve<T3>(Arbol<T3> arbolActual, Arbol<T3> arbolActualMitad, Arbol<T3> raizMitad)
        {
            #region Comprueba Igualdad
            if (arbolActual.Hijos.Contains(raizMitad, new ReferenciaEqualityComparer<T3>()))
            {
                if (arbolActual.Hijos.Count - 1 != arbolActualMitad.Hijos.Count) return false;

                else
                {
                    bool continuo = false;

                    for (int indice = 0; indice < arbolActual.Hijos.Count; indice++)
                    {
                        if (arbolActual.Hijos[indice] == raizMitad)
                        {
                            continuo = true;
                            continue;
                        }

                        else if (continuo && !arbolActual.Hijos[indice].Valor.Equals(arbolActualMitad.Hijos[indice - 1].Valor))
                            return false;

                        else if (!continuo && !arbolActual.Hijos[indice].Valor.Equals(arbolActualMitad.Hijos[indice].Valor))
                            return false;

                    }
                }
            }

            else if (arbolActual.Hijos.Count != arbolActualMitad.Hijos.Count)
                return false;

            else if (arbolActual.Hijos.Count == arbolActualMitad.Hijos.Count)
            {
                for (int indice = 0; indice < arbolActual.Hijos.Count; indice++)
                {
                    if (!arbolActual.Hijos[indice].Valor.Equals(arbolActualMitad.Hijos[indice].Valor))
                        return false;
                }
            }
            #endregion
            bool encontrado = false;

            for (int indice = 0; indice < arbolActual.Hijos.Count; indice++)
            {
                if (arbolActual.Hijos[indice] == raizMitad)
                {
                    encontrado = true;
                    continue;
                }
                if (encontrado && !Resuelve(arbolActual.Hijos[indice], arbolActualMitad.Hijos[indice - 1], raizMitad))
                    return false;
                else if (!encontrado && !Resuelve(arbolActual.Hijos[indice], arbolActualMitad.Hijos[indice], raizMitad))
                    return false;
            }
            return true;

        }
        public static List<Arbol<T2>> PreOrden<T2>(Arbol<T2> arbol)
        {
            List<Arbol<T2>> myLista = new List<Arbol<T2>>();
            PreOrden(arbol, myLista);
            return myLista;
        }
        public static void PreOrden<T1>(Arbol<T1> arbolActual, List<Arbol<T1>> lista)
        {
            lista.Add(arbolActual);
            foreach (var hijo in arbolActual.Hijos)
                PreOrden(hijo, lista);
        }
        public static string ComoTexto<T>(Arbol<T> a)
        {
            if (a == null)
                return "NULL";

            string result = "(" + a.Valor;
            if (a.Hijos.Count > 0)
            {
                result += " - " + ComoTexto(a.Hijos[0]);
                for (int i = 1; i < a.Hijos.Count; i++)
                    result += ", " + ComoTexto(a.Hijos[i]);
            }
            result += ")";
            return result;
        }
        public class ReferenciaEqualityComparer<T4> : IEqualityComparer<Arbol<T4>>
        {
            public bool Equals(Arbol<T4> x, Arbol<T4> y)
            {
                return x == y;
            }

            public int GetHashCode(Arbol<T4> obj)
            {
                return obj.GetHashCode();
            }
        }
    } 
}
