using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Arboles;

namespace IteradorArbolesDesdeHojasHastaRaiz_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<string> a2 = new Arbol<string>("Hola",
                       new Arbol<string>("Mundo",
                           new Arbol<string>("Prueba")),
                       new Arbol<string>("Programa"),
                       new Arbol<string>("CS",
                           new Arbol<string>("5"),
                           new Arbol<string>("2",
                               new Arbol<string>("Aprobado"))));

            IEnumerable<int> longitudes = IteraHojas(a2, s => s.Length);

            foreach (var x in longitudes)
                Console.WriteLine("  {0},", x);
            //6, 8, 1, 8, 5, 1, 2, 4

            Arbol<int> a3 = new Arbol<int>(13,
                    new Arbol<int>(12,
                        new Arbol<int>(1),
                        new Arbol<int>(11,
                            new Arbol<int>(9,
                                new Arbol<int>(2),
                                new Arbol<int>(3)))),
                    new Arbol<int>(4),
                    new Arbol<int>(10,
                        new Arbol<int>(5),
                        new Arbol<int>(6),
                        new Arbol<int>(7),
                        new Arbol<int>(8)));

            IEnumerable<bool> sonPrimos = IteraHojas(a3, x => EsPrimo(x));
            Console.WriteLine();
            foreach (var x in sonPrimos)
                Console.WriteLine("  {0},", x);
            //false, true, true, false, true, false, true, false, false, false, true, false, true

            Arbol<int> a = new Arbol<int>(0,
                    new Arbol<int>(0),
                    new Arbol<int>(0));
            Console.WriteLine();
            var e = IteraHojas(a, x => 1 / x); // hacer esto no debe tener problemas

            foreach (var x in e) // la excepción ocurre aquí al tratar de acceder al primero
                Console.WriteLine(x);


        }

        public static bool EsPrimo(int p)
        {
            if (p <= 1) return false;

            for (int d = 2; d <= (int)Math.Sqrt(p); d++)
                if (p % d == 0) return false;

            return true;
        }


        public class MyArbol<T1>
        {
            List<MyArbol<T1>> hijos;
            public MyArbol(T1 valor, params MyArbol<T1>[] hijos)
            {
                this.hijos = hijos.ToList();
                Valor = valor;
            }
            public List<MyArbol<T1>> Hijos
            {
                get
                {
                    return new List<MyArbol<T1>>(this.hijos);
                }
            }
            public T1 Valor { get; private set; }
            public MyArbol<T1> AgregaHijo(T1 valorHijo)
            {
                MyArbol<T1> temp = new MyArbol<T1>(valorHijo, new MyArbol<T1>[0]);

                this.hijos.Add(temp);
                return temp;
            }
            public void EliminaHijo(MyArbol<T1> hijo)
            {
                this.hijos.Remove(hijo);
            }
        }

        public static void CopiaArbol<T2>(Arbol<T2> arbolActual, MyArbol<T2> copiaActual)
        {
            foreach (var hijo in arbolActual.Hijos)
            {
                MyArbol<T2> hijoCopiaActual = copiaActual.AgregaHijo(hijo.Valor);
                CopiaArbol(hijo, hijoCopiaActual);
            }
        }
        public static MyArbol<T3> CopiaArbol<T3>(Arbol<T3> raiz)
        {
            MyArbol<T3> temp = new MyArbol<T3>(raiz.Valor, new MyArbol<T3>[0]);
            CopiaArbol(raiz, temp);
            return temp;
        }

        public static void Poda<T4>(MyArbol<T4> arbolActual, MyArbol<T4> padre, List<T4> elementos)
        {
            if(arbolActual.Hijos.Count == 0)
            {
                elementos.Add(arbolActual.Valor);
                if (arbolActual != padre)
                    padre.EliminaHijo(arbolActual);
            }
            foreach (var hijo in arbolActual.Hijos)
                Poda(hijo, arbolActual, elementos);
        }

        public delegate R1 Func<T1, out R1>(T1 el);
        public static IEnumerable<R> IteraHojas<T7, R>(Arbol<T7> arbol, Func<T7, R> operacion)
        {
            List<T7> elementosOrdenados = new List<T7>();

            MyArbol<T7> myCopia = CopiaArbol(arbol);

            while(myCopia.Hijos.Count != 0)
            {
                Poda(myCopia, myCopia, elementosOrdenados);
            }
            elementosOrdenados.Add(arbol.Valor);

            foreach (var el in elementosOrdenados)
                yield return operacion(el);
            
        }
    }
}
