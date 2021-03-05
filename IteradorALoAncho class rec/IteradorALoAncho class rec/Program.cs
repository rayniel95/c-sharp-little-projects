using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteradorALoAncho_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<int> myArbol = new Arbol<int>(20,
                                        new Arbol<int>(4,
                                            new Arbol<int>(10),
                                            new Arbol<int>(15,
                                                new Arbol<int>(-1,
                                                    new Arbol<int>(-5),
                                                    new Arbol<int>(11),
                                                    new Arbol<int>(3,
                                                        new Arbol<int>(-9,
                                                            new Arbol<int>(14)))))),
                                        new Arbol<int>(30),
                                        new Arbol<int>(-22),
                                        new Arbol<int>(25,
                                            new Arbol<int>(17,
                                                new Arbol<int>(4),
                                                new Arbol<int>(14),
                                                new Arbol<int>(2),
                                                new Arbol<int>(-11)),
                                            new Arbol<int>(-8),
                                            new Arbol<int>(7,
                                                new Arbol<int>(13,
                                                    new Arbol<int>(40)),
                                                new Arbol<int>(33))));

            Iterador<int> miIterador = new Iterador<int>();
            int nivel = 0;

            foreach (IEnumerable<int> nodos in miIterador.IteradorAloAncho(myArbol, ValoresPositivos))
            {
                Console.WriteLine("Nivel {0}", nivel);
                foreach (int k in nodos)
                    Console.Write("{0} ", k);
                Console.WriteLine();
                nivel++;
            }


        }

        public class Iterador<T3> : IIteradores<T3>
        {
            Arbol<T3> arbol;
            public Iterador()
            {
            
            }
            public IEnumerable<IEnumerable<T3>> IteradorAloAncho(Arbol<T3> a, Func<T3, bool> filtro)
            {
                this.arbol = a;

                List<List<T3>> aLoAncho = new List<List<T3>>();
                List<T3> valores = new List<T3>();

                Queue<Arbol<T3>> arboles = new Queue<Arbol<T3>>();
                Queue<int> niveles = new Queue<int>();

                arboles.Enqueue(this.arbol);
                niveles.Enqueue(0);

                int nivelActual = 0;

                while (arboles.Count > 0)
                {
                    if(nivelActual != niveles.Peek())
                    {
                        aLoAncho.Add(valores);
                        valores = new List<T3>();
                        nivelActual++;
                    }
                    if(nivelActual == niveles.Peek())
                    {
                        Arbol<T3> arbolSacado = arboles.Dequeue();
                        int nivelSacado = niveles.Dequeue();

                        foreach(var hijo in arbolSacado.Hijos)
                        {
                            arboles.Enqueue(hijo);
                            niveles.Enqueue(nivelActual + 1);
                        }
                        if (filtro(arbolSacado.Valor))
                            valores.Add(arbolSacado.Valor);

                        if (arboles.Count == 0 && valores.Count > 0)
                            aLoAncho.Add(valores);
                    }
                }

                return aLoAncho;
            }
        }
        public static bool ValoresPositivos(int numero)
        {
            return numero >= 0;
        }

        interface IIteradores<T1>
        {
            IEnumerable<IEnumerable<T1>> IteradorAloAncho(Arbol<T1> a,
            Func<T1, bool> filtro);
        }
        public delegate R Func<T2, R>(T2 x);
      
        public class Arbol<T>
        {
            public T Valor { get; private set; }
            public IEnumerable<Arbol<T>> Hijos { get; private set; }
            public Arbol(T valor, params Arbol<T>[] hijos)
            {
                Valor = valor;
                Hijos = hijos;
            }
        }
    }
}
