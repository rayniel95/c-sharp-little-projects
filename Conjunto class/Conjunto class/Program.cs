using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conjunto_class
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet s = new Conjunto();
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

            ISet other = new Conjunto();
            other.Add("k");
            other.Add(5);
            other.Add("z");
            other.Add("m");
            other.Add("l");
            ISet union = s.Union(other);

            foreach (object o in union) 
                Console.Write(o + " ");
            Console.WriteLine();
            Console.WriteLine();

            foreach (object o in other) 
                Console.Write(o + " ");
            Console.WriteLine();
            Console.WriteLine();

            ISet intersection = s.Intersection(other);

            foreach (object o in intersection) 
                Console.Write(o + " "); 

        }
        public interface ISet : System.Collections.IEnumerable
        {
            //Permite conocer la cantidad de elementos
            //almacenados en el conjunto
            int Count { get; }
            //Añade un elemento al conjunto.
            //Si el elemento ya se encuentra en el conjunto no
            //se hace nada
            //Si se intenta añadir el elemento null al conjunto
            //el método debe lanzar ArgumentNullException
            void Add(object o);
            //Quita el elemento del conjunto
            //Si no está no se hace nada
            void Remove(object o);
            //Devuelve true si el elemento o
            //se encuentra en el conjunto y
            //false en caso contrario
            bool Contains(object o);
            //Devuelve un nuevo conjunto que resulta
            //de realizar la unión de este conjunto (this)
            //con el conjunto other. Ni este conjunto (this)
            //ni el conjunto other son afectados por esta operación. //Si el valor de other es null el método debe //lanzar la excepción ArgumentNullException
            ISet Union(ISet other);
            //Devuelve un nuevo conjunto que resulta
            //de realizar la intersección de este conjunto (this)
            //con el conjunto other. Ni este conjunto (this)
            //ni el conjunto other son afectados por esta operación.
            //Si el valor de other es null el método debe
            //lanzar la excepción ArgumentNullException
            ISet Intersection(ISet other);
        }
        public class Conjunto : ISet
        {
            class ConjuntoEnumerator : IEnumerator
            {
                Conjunto conjunto;
                Nodo cursor;
                object current;
                public ConjuntoEnumerator(Conjunto conjunto)
                {
                    this.cursor = null;
                    this.current = null;
                    this.conjunto = conjunto;
                }
                public object Current
                {
                    get
                    {
                        if (this.cursor == null) throw new InvalidOperationException();
                        return this.current;
                    }
                }

                public bool MoveNext()
                {
                    if (this.conjunto.count == 0) return false;
                    if(this.cursor == null) { this.cursor = this.conjunto.primero; this.current = this.cursor.Valor; return true; }

                    if(this.cursor.Siguiente != null)
                    {
                        this.cursor = this.cursor.Siguiente;
                        this.current = this.cursor.Valor;
                        return true;
                    }
                    return false;


                }

                public void Reset()
                {
                    this.cursor = null;
                    this.cursor = null;
                }
            }
            class Nodo
            {
                object valor;
                Nodo siguiente;
                public Nodo(object valor, Nodo siguiente = null)
                {
                    this.siguiente = siguiente;
                    this.valor = valor;

                }
                public object Valor
                {
                    get { return this.valor; }
                    set { this.valor = value; }
                }
                public Nodo Siguiente
                {
                    get { return this.siguiente; }
                    set { this.siguiente = value; }
                }
            }
            Nodo primero;
            int count;
            public Conjunto()
            {
                this.primero = null;
                this.count = 0;
            }
            public int Count
            {
                get
                {
                    return this.count;
                }
            }

            public void Add(object o)
            {
                if (this.Contains(o)) return;
                if (this.count == 0)
                {
                    this.primero = new Nodo(o);
                    this.count++;
                    return;
                }
                Nodo current = this.primero;
                while (current.Siguiente != null)
                    current = current.Siguiente;
                current.Siguiente = new Nodo(o);
                this.count++;

            }

            public bool Contains(object o)
            {
                Nodo current = this.primero;

                while(current != null)
                {
                    if (current.Valor.Equals(o))
                        return true;
                    current = current.Siguiente;
                }
                return false;
            }

            public IEnumerator GetEnumerator()
            {
                return new ConjuntoEnumerator(this);
            }

            public ISet Intersection(ISet other)
            {
                ISet nuevoConjunto = new Conjunto();

                IEnumerator conjuntoNumerator = this.GetEnumerator();

                while (conjuntoNumerator.MoveNext())
                {
                    if (other.Contains(conjuntoNumerator.Current))
                        nuevoConjunto.Add(conjuntoNumerator.Current);
                }
                return nuevoConjunto;

            }

            public void Remove(object o)
            {
                if (this.count == 0) return;

                if (this.primero.Valor.Equals(o))
                {
                    this.primero = this.primero.Siguiente;
                    this.count--;
                    return;
                }
            
                Nodo current = this.primero;

                while (current.Siguiente!= null)
                {
                    if (current.Siguiente.Valor.Equals(o))
                    {
                        current.Siguiente = current.Siguiente.Siguiente;
                        this.count--;
                        return;
                    }
                    current = current.Siguiente;
                }
       
                
            }

            public ISet Union(ISet other)
            {
                ISet nuevoConjunto = new Conjunto();

                IEnumerator thisEnumerator = this.GetEnumerator();

                while (thisEnumerator.MoveNext())
                    nuevoConjunto.Add(thisEnumerator.Current);

                IEnumerator otherNumerator = other.GetEnumerator();
                
                while(otherNumerator.MoveNext())
                {
                    nuevoConjunto.Add(otherNumerator.Current);
                }
                return nuevoConjunto;
            }

        }
    }
}

