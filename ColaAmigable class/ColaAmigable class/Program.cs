using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAmigable_class
{
    public interface IConocido<T>
    { bool Conoce(T aquien); }
    public interface IColaAmigable<T1> where T1 : IConocido<T1>
    {
        void Enqueue(T1 elemento);
        T1 Dequeue();
        T1 Peek();
        int Count { get; }
        IEnumerable<T1> ColadosPor(T1 quien);
    }
    public class Estudiante : IConocido<Estudiante>
    {
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public Estudiante(string nombre, string grupo) { Nombre = nombre; Grupo = grupo; }
        public bool Conoce(Estudiante aquien) { return Grupo == aquien.Grupo; }
        public override bool Equals(object obj)
        {
            if (obj is Estudiante)
            {
                var estudiante = obj as Estudiante;
                return Grupo == estudiante.Grupo && Nombre == estudiante.Nombre;
            }
            return false;
        }
    }
    public class ColaAmigable : IColaAmigable<Estudiante>, IEnumerable<Estudiante>
    {
        class ColaAmigableEnumerator : IEnumerator<Estudiante>
        {
            Nodo<Estudiante> current;
            Estudiante quien;
            ColaAmigable cola;
            public ColaAmigableEnumerator(Estudiante quien, ColaAmigable cola)
            {
                this.quien = quien;
                this.cola = cola;
                Reset();
            }
            public Estudiante Current
            {
                get
                {
                    if (this.cola.Count > 0 && this.current != null)
                        return this.current.Valor;
                    throw new InvalidOperationException("No se ha hecho move next, la cola esta vacia, es un colado, o no esta en la cola");
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                if (this.current == null) return false;
                if (this.current.Anterior != null && this.current.Anterior.Valor.Conoce(this.quien))
                {
                    this.current = this.current.Anterior;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                this.current = this.cola.primero;
                while (this.current.Siguiente != null && !this.current.Valor.Equals(this.quien))
                    this.current = current.Siguiente;

                if (!this.current.Valor.Equals(quien)) this.current = null;
                else if (this.current.Siguiente != null && this.current.Siguiente.Valor.Conoce(this.quien)) this.current = null;
            }
        }
        Nodo<Estudiante> primero;
        int count;
        Estudiante quien;
        class Nodo<T1>
        {
            Nodo<T1> siguiente;
            T1 valor;
            Nodo<T1> anterior;
            public Nodo(T1 valor, Nodo<T1> siguiente, Nodo<T1> anterior)
            {
                this.siguiente = siguiente;
                this.valor = valor;
                this.anterior = anterior;
            }
            public Nodo<T1> Siguiente
            {
                get { return this.siguiente; }
                set { this.siguiente = value; }
            }
            public Nodo<T1> Anterior { get { return this.anterior; } set { this.anterior = value; } }
            public T1 Valor { get { return this.valor; } set { this.valor = value; } }

        }
        public ColaAmigable()
        {
            this.count = 0;
            this.primero = new Nodo<Estudiante>(null, null, null);
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public IEnumerable<Estudiante> ColadosPor(Estudiante quien)
        {
            this.quien = quien;
            return this;
        }

        public Estudiante Dequeue()
        {
            if (this.count > 0)
            {
                Estudiante temp = this.primero.Valor;
                this.primero = this.primero.Siguiente;
                this.primero.Anterior = null;
                this.count--;
                return temp;
            }
            throw new InvalidOperationException();
        }

        public void Enqueue(Estudiante elemento)
        {
            Nodo<Estudiante> current = this.primero;
            Nodo<Estudiante> nuevo = new Nodo<Estudiante>(elemento, null, null);
         
            if (this.count == 0) { this.primero = nuevo; this.count++; return; } 

            for(int indice = 0; indice < this.count; indice++)
            {
                if(indice == this.count - 1 && !current.Valor.Conoce(elemento)) { current.Siguiente = nuevo; nuevo.Anterior = current; break; }
                else if(current.Valor.Conoce(elemento))
                {
                    if (current.Siguiente != null && current.Siguiente.Valor.Conoce(elemento)){ current = current.Siguiente; continue; }
                    nuevo.Anterior = current.Anterior;
                    nuevo.Siguiente = current;
                    if (current.Anterior != null) current.Anterior.Siguiente = nuevo;
                    current.Anterior = nuevo;
                    if (current == this.primero) this.primero = nuevo;
                    break;
                }
                current = current.Siguiente;
            }

            this.count++;
        }

        public Estudiante Peek()
        {
            if(this.count > 0)
                return this.primero.Valor;
            throw new InvalidOperationException();
        }

        public IEnumerator<Estudiante> GetEnumerator()
        {
            return new ColaAmigableEnumerator(this.quien, this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ColaAmigable colaAmigable = new ColaAmigable();
            colaAmigable.Enqueue(new Estudiante("Jose", "C312")); // Jose 
            colaAmigable.Enqueue(new Estudiante("Maria", "C312")); // Maria-Jose
            Console.WriteLine(colaAmigable.Peek().Nombre);  // Maria
            colaAmigable.Enqueue(new Estudiante("Juan", "C513")); // Maria -Jose-Juan 
            colaAmigable.Enqueue(new Estudiante("Amanda", "C312")); // Maria-Amanda-Jose-Juan
            int count1 = colaAmigable.Count; // 4
            Console.WriteLine(count1);
            IEnumerable<Estudiante> my = colaAmigable.ColadosPor(new Estudiante("Jose", "C312")); // Maria-Amanda
            foreach (var elem in my) Console.WriteLine(elem.Nombre);
            my = colaAmigable.ColadosPor(new Estudiante("Amanda", "C312")); // ningún elemento
            foreach(var elem in my) Console.WriteLine(elem.Nombre);
            my = colaAmigable.ColadosPor(new Estudiante("Juan", "C513")); // ningún elemento 
            foreach (var elem in my) Console.WriteLine(elem);
            Console.WriteLine(colaAmigable.Dequeue().Nombre); // Amanda-Jose-Juan 
            int count2 = colaAmigable.Count; // 3 
            Console.WriteLine(count2);
            my = colaAmigable.ColadosPor(new Estudiante("Jose", "C312")); // Amanda
            foreach (var ele in my) Console.WriteLine(ele.Nombre);

        }
    }
}
