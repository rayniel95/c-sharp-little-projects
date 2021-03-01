using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conjunto_class__yield_
{
    class Program
    {
        static void Main(string[] args)
        {
             ISet<object> s = new Conjunto<object>();
            s.Add("a");
            s.Add("z");
            s.Add(5);
            s.Add("h");
            Console.WriteLine(s.Contains(5));
            Console.WriteLine(s.Contains("k"));
            DateTime dt = new DateTime(2005, 5, 4);
            Console.WriteLine(s.Contains(dt));

            foreach (object o in s) 
                Console.Write(o + " ");
            Console.WriteLine();
            Console.WriteLine(s.Count);

            s.Add("a");
            Console.WriteLine(s.Count);
            s.Remove("i");
            Console.WriteLine(s.Count);

            s.Remove(5);
            Console.WriteLine(s.Count);

            Console.WriteLine();

            ISet<object> other = new Conjunto<object>();
            other.Add("k");
            other.Add(5);
            other.Add("z");
            other.Add("m");
            other.Add("l");
            ISet<object> union = s.Union(other);

            foreach (object o in union) 
                Console.Write(o + " ");
            Console.WriteLine();
            Console.WriteLine();

            foreach (object o in other) 
                Console.Write(o + " ");
            Console.WriteLine();
            Console.WriteLine();

            ISet<object> intersection = s.Intersection(other);

            foreach (object o in intersection) 
                Console.Write(o + " "); 

        }

        public interface ISet<T1>:IEnumerable<T1>
        {
            int Count { get; }
            //Añade un elemento al conjunto.
            //Si el elemento ya se encuentra en el conjunto no
            //se hace nada
            //Si se intenta añadir el elemento null al conjunto
            //el método debe lanzar ArgumentNullException
            void Add(T1 elemento);
            //Quita el elemento del conjunto
            //Si no está no se hace nada
            void Remove(T1 elemento);
            //Devuelve true si el elemento o
            //se encuentra en el conjunto y
            //false en caso contrario
            bool Contains(T1 elemento);
            //Devuelve un nuevo conjunto que resulta
            //de realizar la unión de este conjunto (this)
            //con el conjunto other. Ni este conjunto (this)
            //ni el conjunto other son afectados por esta operación. //Si el valor de other es null el método debe //lanzar la excepción ArgumentNullException
            ISet<T1> Union(ISet<T1> other);
            //Devuelve un nuevo conjunto que resulta
            //de realizar la intersección de este conjunto (this)
            //con el conjunto other. Ni este conjunto (this)
            //ni el conjunto other son afectados por esta operación.
            //Si el valor de other es null el método debe
            //lanzar la excepción ArgumentNullException
            ISet<T1> Intersection(ISet<T1> other);
        }

        public class Conjunto<T1> : ISet<T1>
        {
            class Nodo<T2>
            {
                public Nodo(T2 valor, Nodo<T2> siguiente = null)
                {
                    Valor = valor;
                    Siguiente = siguiente;
                }
                public T2 Valor
                { get; }
                public Nodo<T2> Siguiente
                { get; set; }
            }

            public int Count
            {
                get;
                private set;
            }
            Nodo<T1> primero;
            public Conjunto()
            {
                Count = 0;
                this.primero = null;
            }
            public void Add(T1 elemento)
            {
                if(Count == 0)
                {
                    this.primero = new Nodo<T1>(elemento);
                    Count++;
                    return;
                }
                if (this.Contains(elemento)) return;
                Nodo<T1> current = this.primero;
                while(current.Siguiente != null)
                {
                    current = current.Siguiente;
                }
                current.Siguiente = new Nodo<T1>(elemento);
                Count++;
            }

            public bool Contains(T1 elemento)
            {
                foreach(T1 el in this)
                {
                    if (el.Equals(elemento))
                        return true;
                }
                return false;

            }

            public IEnumerator<T1> GetEnumerator()
            {
                Nodo<T1> current = this.primero;
                while(current != null)
                {
                    yield return current.Valor;
                    current = current.Siguiente;
                }
                yield break;
            }

            public ISet<T1> Intersection(ISet<T1> other)
            {
                Conjunto<T1> nuevo = new Conjunto<T1>();

                foreach(T1 el in this)
                {
                    if (other.Contains(el))
                        nuevo.Add(el);
                }
                return nuevo;
            }

            public void Remove(T1 elemento)
            {
                if(elemento.Equals(this.primero.Valor))
                {
                    this.primero = this.primero.Siguiente;
                    Count--;
                    return;
                }
                Nodo<T1> current = this.primero;

                while (current.Siguiente != null && !current.Siguiente.Valor.Equals(elemento))
                    current = current.Siguiente;
                if (current.Siguiente != null)
                {
                    current.Siguiente = current.Siguiente.Siguiente;
                    Count--;
                }
            }

            public ISet<T1> Union(ISet<T1> other)
            {
                Conjunto<T1> nuevo = new Conjunto<T1>();

                foreach (T1 el in this)
                    nuevo.Add(el);
                foreach (T1 el in other)
                    nuevo.Add(el);
                return nuevo;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
