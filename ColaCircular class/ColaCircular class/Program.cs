using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ColaCircular_class
{
    public class ColaCircular<T1>:IEnumerable<T1>
    {
        class Objeto<T2>
        {
            ulong lugar;
            T2 elemento;
            public Objeto(T2 elemento, ulong lugar)
            { this.lugar = lugar; this.elemento = elemento; }
            public ulong Lugar { get { return this.lugar; } set { this.lugar = value; } }
            public T2 Elemento { get { return this.elemento; } set { this.elemento = value; } }
        }

        List<Objeto<T1>> cola;
        ulong lugar;
        Objeto<T1> primero;
        int count;

        public ColaCircular() { this.cola = new List<Objeto<T1>>(); this.lugar = 0; this.count = 0; }
        public int Count { get { return this.count; } }
        public bool Contains(T1 item)
        {
            if (this.count == 0) throw new InvalidOperationException("La cola esta vacia");

            foreach(var el in this.cola)
            {
                if (el.Elemento.Equals(item))
                    return true;
            }
            return false;
        }
        public void Enqueue(T1 item)
        {
            if (this.count == 0) { this.primero = new Objeto<T1>(item, this.lugar); this.lugar++; this.count++; this.cola.Add(this.primero); return; }

            if (this.cola.Contains(null)) { this.cola[this.cola.IndexOf(null)] = new Objeto<T1>(item, this.lugar); this.lugar++; this.count++; return; }

            this.cola.Add(new Objeto<T1>(item, this.lugar));
            this.count++;
            this.lugar++;

        }
        public T1 Dequeue()
        {
            // se hubiera podido prescindir de la variable primero, bastaria buscar el objeto con menor lugar y ese seria el primero, pero esta operacion es mas costosa
            // que tener una referencia a dicho elemento y cambiar esta referencia al proximo menor cada vez que se saque un elemento, pues cada vez que se quisiere peek
            // se tendria que buscar el menor de los lugares.

            if (this.count == 0) throw new InvalidOperationException("La cola esta vacia");

            T1 temp = this.primero.Elemento;

            this.count--;

            this.primero = this.Proximo(this.primero.Lugar + 1);

            return temp;
        }
        Objeto<T1> Proximo(ulong lugar)
        {
            foreach (var el in this.cola)
            {
                if (el.Lugar == lugar)
                    return el;
            }
            return null;
        }
        public T1 Peek() { return this.primero.Elemento; }

        public IEnumerator<T1> GetEnumerator()
        {
            for (ulong primero = this.primero.Lugar; primero <= this.lugar; primero++)
            {
                for(int segundo = 0; segundo < this.cola.Count; segundo++)
                {
                    if(this.cola[segundo] != null && this.cola[segundo].Lugar == primero)
                    { yield return this.cola[segundo].Elemento; break; }
                }
            }
             
          
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
            List<int> my = new List<int>() { 1, 2, 4 };

            my.Remove(2);
            Console.WriteLine(my.Count);
        }
    }
}
