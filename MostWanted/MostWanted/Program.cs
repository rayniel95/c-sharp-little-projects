using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostWanted
{
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
        void Add(T1 objeto);
        //Elimina el elemento o de la colección
        //Si el elemento o no se encuentra
        //almacenado en la colección este método
        //no hace nada
        void Remove(T1 objeto);
        //Devuelve true si el elemento o
        //se encuentra en la colección y
        //false en otro caso
        bool Contains(T1 objeto);
    }

    public class MostWanted<T2> : IMostWanted<T2>
    {
        class MostWantedEnumerator : IEnumerator<T2>
        {
            int identidadAnterior;
            MostWanted<T2> cola;
            T2 current;
            int mayorPeso;
            int anteriorMayorPeso;
            List<int> identidades;
            public MostWantedEnumerator(MostWanted<T2> cola)
            {
                this.identidadAnterior = -1;
                this.mayorPeso = -1;
                this.cola = cola;
                this.anteriorMayorPeso = int.MaxValue;
                this.identidades = new List<int>();
            }
      
            public T2 Current
            {
                get
                {
                    if (this.identidades.Count == 0) throw new InvalidOperationException();
                    return this.current;
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
                Nodo<T2> nodoActual = this.cola.primero;
                int identidadActual = -1;

                while (nodoActual != null)
                {
                    if (nodoActual.Peso>this.mayorPeso && nodoActual.Peso<this.anteriorMayorPeso && nodoActual.ID != this.identidadAnterior)
                    {
                        this.current = nodoActual.Valor;
                        this.mayorPeso = nodoActual.Peso;
                        identidadActual = nodoActual.ID;
                    }
                    else if(nodoActual.Peso == this.anteriorMayorPeso && !this.identidades.Contains(nodoActual.ID))
                    {
                        this.current = nodoActual.Valor;
                        identidadActual = nodoActual.ID;
                        this.mayorPeso = nodoActual.Peso;
                        break;
                    }
                    nodoActual = nodoActual.Siguiente;
                }

                if(identidadActual != -1 && identidadActual!= identidadAnterior)
                {
                    this.anteriorMayorPeso = this.mayorPeso;
                    this.mayorPeso = -1;
                    this.identidadAnterior = identidadActual;
                    this.identidades.Add(identidadActual);
                    return true;
                }
                return false;

            }

            public void Reset()
            {
                this.mayorPeso = -1;
            }
        }
        class Nodo<T3>
        {
            T3 valor;
            Nodo<T3> siguiente;
            int peso;
            int identidad;
            public Nodo(int identidad, T3 valor, Nodo<T3> siguiente = null, int peso = 0)
            {
                this.valor = valor;
                this.identidad = identidad;
                this.siguiente = siguiente;
                this.peso = peso;
            }
            public Nodo<T3> Siguiente
            {
                get { return this.siguiente; }
                set { this.siguiente = value; }
            }
            public int ID { get { return this.identidad; } }
            public T3 Valor
            {
                get { return this.valor; }
            }
            public int Peso
            {
                get { return this.peso; }
                set { this.peso = value; }
            }
        }
        int count;
        Nodo<T2> primero;
        int identidad;
        public MostWanted()
        {
            this.count = 0;
            this.identidad = 0;
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T2 objeto)
        {
            this.identidad++;
            if (this.count == 0)
            {
                this.primero = new Nodo<T2>(this.identidad, objeto);
                this.count++;
                return;
            }
           
            Nodo<T2> current = this.primero;

            while (current.Siguiente != null) current = current.Siguiente;
            current.Siguiente = new Nodo<T2>(this.identidad, objeto);

            this.count++;
            
        }

        public bool Contains(T2 objeto)
        {
            if (this.count == 0) throw new InvalidOperationException();

            Nodo<T2> current = this.primero;

            while(current != null)
            {
                if (current.Valor.Equals(objeto)) { current.Peso++; return true; }
                current = current.Siguiente;
            }
            return false;
        }

        public IEnumerator<T2> GetEnumerator()
        {
            return new MostWantedEnumerator(this);
        }

        public void Remove(T2 objeto)
        {
            if (this.count == 0) throw new InvalidOperationException();

            if (this.primero.Valor.Equals(objeto)) { this.primero = this.primero.Siguiente; this.count--; return; }

            Nodo<T2> current = this.primero;

            while(current != null)
            {
                if (current.Siguiente != null && current.Siguiente.Valor.Equals(objeto) && current.Siguiente.Siguiente != null)
                    current.Siguiente = current.Siguiente.Siguiente;
                
                else if (current.Siguiente != null && current.Siguiente.Valor.Equals(objeto))
                    current.Siguiente = null;

                current = current.Siguiente;
            }
            this.count--;

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
            MostWanted<int> my = new MostWanted<int>();

            my.Add(1);
            my.Add(2);
            my.Add(4);
            my.Add(7);
            Console.WriteLine(my.Count);
            my.Contains(4);
            my.Remove(2);
            Console.WriteLine(my.Count);
            foreach (var el in my) Console.WriteLine(el);
        }
    }
}
