using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAmigable_class__yield_
{
    class Program
    {
        static void Main(string[] args)
        {
            ColaAmigable<Estudiante> colaAmigable = new ColaAmigable<Estudiante>();

            colaAmigable.Enqueue(new Estudiante("Jose", "C312")); // Jose 

            colaAmigable.Enqueue(new Estudiante("Maria", "C312")); // Maria-Jose
            colaAmigable.Peek(); // Maria
            colaAmigable.Enqueue(new Estudiante("Juan", "C513")); // Maria-Jose-Juan 
            colaAmigable.Enqueue(new Estudiante("Amanda", "C312")); // Maria-Amanda-Jose-Juan
            int count1 = colaAmigable.Count; // 4

            foreach(var el in colaAmigable.ColadosPor(new Estudiante("Jose", "C312")))
                Console.WriteLine(el.Nombre);

            foreach(var el in colaAmigable.ColadosPor(new Estudiante("Amanda", "C312")))
                Console.WriteLine(el.Nombre);// ningún elemento
            foreach(var el in colaAmigable.ColadosPor(new Estudiante("Juan", "C513")))
                Console.WriteLine(el.Nombre);// ningún elemento 
            colaAmigable.Dequeue(); // Amanda-Jose-Juan 
            int count2 = colaAmigable.Count; // 3 
            foreach(var el in colaAmigable.ColadosPor(new Estudiante("Jose", "C312")))
                Console.WriteLine(el.Nombre);// Amanda


        }

        public interface IConocido<T>
        {
            bool Conoce(T aquien);
        }

        public interface IColaAmigable<T> where T : IConocido<T>
        {
            void Enqueue(T elemento);
            T Dequeue();
            T Peek();
            int Count { get; }
            IEnumerable<T> ColadosPor(T quien);
        }

        public class ColaAmigable<T1> : IColaAmigable<T1> where T1 : IConocido<T1>
        {
            class Nodo<T2>
            {
                public Nodo(T2 valor, Nodo<T2> anterior = null, Nodo<T2> siguiente = null)
                {
                    Valor = valor;
                    Siguiente = siguiente;
                    Anterior = anterior;
                }
                public Nodo<T2> Anterior
                {
                    get;
                    set;
                }
                public Nodo<T2> Siguiente { get; set; }
                public T2 Valor { get; }
                   
            }
            Nodo<T1> primero;


            public int Count
            {
                get;
                private set;
              
            }
            public ColaAmigable()
            {
                Count = 0;
                this.primero = null;
            }
            public IEnumerable<T1> ColadosPor(T1 quien)
            {
                Nodo<T1> current = this.primero;
                bool seEncontro = false;
                while(current.Siguiente != null)
                {
                    if (current.Valor.Equals(quien) && current.Siguiente == null || 
                         current.Valor.Equals(quien) && current.Siguiente != null && !quien.Conoce(current.Siguiente.Valor))
                    {
                        seEncontro = true;
                        break;
                    }
                    current = current.Siguiente;
                }
                if (!seEncontro) yield break;
                current = current.Anterior;

                while (current != null)
                {
                    if (quien.Conoce(current.Valor))
                        yield return current.Valor;
                    current = current.Anterior; 
                }
                yield break;
            }

            public T1 Dequeue()
            {
                if (Count == 0) throw new InvalidOperationException();
                T1 temp = this.primero.Valor;
                this.primero = this.primero.Siguiente;
                this.primero.Anterior = null;
                Count--;
                return temp;
            }

            public void Enqueue(T1 elemento)
            {
                if(Count == 0)
                {
                    this.primero = new Nodo<T1>(elemento);
                    Count++;
                    return;
                }
                if(elemento.Conoce(this.primero.Valor) && this.primero.Siguiente == null || 
                    elemento.Conoce(this.primero.Valor) && this.primero.Siguiente != null && !elemento.Conoce(this.primero.Siguiente.Valor))
                {
                    Nodo<T1> temp = new Nodo<T1>(elemento, null, this.primero);
                    this.primero.Anterior = temp;
                    this.primero = temp;
                    Count++;
                    return;
                }

                Nodo<T1> current = this.primero;

                while(current.Siguiente != null)
                {
                    if (elemento.Conoce(current.Siguiente.Valor) && current.Siguiente == null || 
                         elemento.Conoce(current.Siguiente.Valor) && current.Siguiente.Siguiente != null && !elemento.Conoce(current.Siguiente.Siguiente.Valor))
                        break;
                    current = current.Siguiente;
                }
                Nodo<T1> temp2 = new Nodo<T1>(elemento, current, current.Siguiente);

                if (current.Siguiente != null)
                    current.Siguiente.Anterior = temp2;
                current.Siguiente = temp2;

                

                Count++;
            }

            public T1 Peek()
            {
                if (Count == 0) throw new InvalidOperationException();
                return this.primero.Valor;
            }
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
    }
}
