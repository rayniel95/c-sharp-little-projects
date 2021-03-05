using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostWanted_class__yield_
{
    class Program
    {
        static void Main(string[] args)
        {
            MostWanted<object> mw = new MostWanted<object>();
            mw.Add("k");
            mw.Add(5);
            mw.Add("z");
            mw.Add("m");
            mw.Add("l");

            foreach (object o in mw) 
                Console.WriteLine(o + " ");

            Console.WriteLine();
            Console.WriteLine(mw.Contains("m"));
            Console.WriteLine(mw.Contains("i"));
            Console.WriteLine(mw.Contains("l"));
            Console.WriteLine(mw.Contains("m"));
            Console.WriteLine(mw.Contains(5));
            Console.WriteLine();

            foreach (object o in mw) 
                Console.WriteLine(o + " "); // m 5 l k z

            Console.WriteLine(mw.Contains("l"));
            mw.Remove("m");
            mw.Add("y");
            Console.WriteLine(mw.Contains("y"));
            Console.WriteLine(mw.Contains("y"));
            Console.WriteLine();

            foreach (object o in mw) 
                Console.WriteLine(o + " "); // l y 5 k z
            Console.WriteLine();

            Console.WriteLine(mw.Count);
        }

        public interface IMostWanted<T1> : IEnumerable<T1>
        {
            //Permite conocer la cantidad de elementos
            //almacenados en la estructura
            int Count { get; }
            //Adiciona el elemento o a la colección
            //Si el elemento o ya se encuentra
            //almacenado en la colección este método
            //no hace nada
            //Si se intenta añadir el elemento null
            //el método debe lanzar ArgumentNullException
            void Add(T1 elemento);
            //Elimina el elemento o de la colección
            //Si el elemento o no se encuentra
            //almacenado en la colección este método
            //no hace nada
            void Remove(T1 elemento);
            //Devuelve true si el elemento o
            //se encuentra en la colección y
            //false en otro caso
            bool Contains(T1 elemento);
        }

        public class MostWanted<T2> : IMostWanted<T2>
        {
            class Nodo<T3>
            {
                public Nodo(T3 valor, Nodo<T3> siguiente = null)
                {
                    Valor = valor;
                    Siguiente = siguiente;
                }
                public Nodo<T3> Siguiente { get; set; }
                public T3 Valor { get; private set; }
                public int Peso { get; set; }

            }
            public int Count
            {
                get;
                private set;
                
                
            }
            Nodo<T2> primero;
            public MostWanted()
            {
                this.primero = null;
                Count = 0;
            }
            public void Add(T2 elemento)
            {
                if(this.primero == null)
                {
                    this.primero = new Nodo<T2>(elemento);
                    Count++;
                    return;
                }
                Nodo<T2> current = this.primero;

                while(current.Siguiente != null)
                {
                    current = current.Siguiente;
                }
                current.Siguiente = new Nodo<T2>(elemento);
                Count++;
            }

            public bool Contains(T2 elemento)
            {
                if (Count == 0) throw new InvalidOperationException();
                Nodo<T2> current = this.primero;
                while (current != null)
                {
                    if (current.Valor.Equals(elemento))
                    {
                        current.Peso++;
                        return true;
                    }
                    current = current.Siguiente;
                }

                return false;
            }

            public IEnumerator<T2> GetEnumerator()
            {
                int count = 0;
                int maximo = -1;
                int maximoAnterior = int.MaxValue;

                Nodo<T2> actual = null;

                while (count < Count)
                {
                    Nodo<T2> current = this.primero;
                    while(current != null)
                    {
                        if(current.Peso > maximo && current.Peso < maximoAnterior)
                        {
                            maximo = current.Peso;
                            actual = current;
                        }
                        current = current.Siguiente;
                    }
                    count++;
                    yield return actual.Valor;

                    current = actual.Siguiente;

                    while(current != null)
                    {
                        if (actual.Peso == current.Peso)
                        {
                            count++;
                            yield return current.Valor;
                        }
                        current = current.Siguiente;
                    }
                    maximoAnterior = maximo;
                    maximo = -1;
                }
            }

            public void Remove(T2 elemento)
            {
                if (Count == 0) throw new InvalidOperationException();

                if (this.primero.Valor.Equals(elemento))
                {
                    this.primero = this.primero.Siguiente;
                    Count--;
                    return;
                }
                Nodo<T2> current = this.primero;

                while(current.Siguiente != null)
                {
                    if(current.Siguiente.Valor.Equals(elemento))
                    {
                        current.Siguiente = current.Siguiente.Siguiente;
                        Count--;
                        return;                                                                                
                    }
                    current = current.Siguiente;
                }

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}

