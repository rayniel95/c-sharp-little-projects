using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaConPrioridad_class
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            //ColaConPrioridad<string> cola = new ColaConPrioridad<string>();
            //cola.Enqueue("azul", 3); // azul 
            //cola.Enqueue("rojo", 4); // rojo, azul
            //cola.Peek(); // El resultado debe ser rojo'.
            //cola.Enqueue("verde", 3); // rojo, azul, verde 
            //cola.Enqueue("blanco", 8); // blanco, rojo, azul, verde
            //int count1 = cola.Count; // El resultado debe ser 4.
            //cola.ElementosConIgualPrioridad("verde"); // El resultado debe ser 'azul, verde'.
            //cola.ElementosConIgualPrioridad("cyan"); // El resultado debe ser un iterador vacío. 
            //string s = cola.Dequeue(); // El resultado debe ser 'blanco'. 
            //int count2 = cola.Count; // El resultado debe ser 3 (rojo, azul, verde). 
            //cola.ElementosConIgualPrioridad("rojo"); // La respuesta debe ser 'rojo'.



            #endregion


        }

        public class ColaConPrioridad<T1> : IColaConPrioridad<T1>
        {
            class Nodo<T3>
            {
                public Nodo(T3 valor, int prioridad, Nodo<T3> siguiente=null)
                {
                    Valor = valor;
                    Siguiente = siguiente;
                    Prioridad = prioridad;
                }
                public T3 Valor { get; private set; }
                public Nodo<T3> Siguiente { get; set; }
                public int Prioridad { get; private set; }
            }

            Nodo<T1> primero;
            public ColaConPrioridad()
            {
                this.primero = null;
            }
            public int Count
            {
                get
                {
                    Nodo<T1> current = this.primero;
                    int cuantos = 0;
                    while(current != null)
                    {
                        cuantos++;
                        current = current.Siguiente;
                    }
                    return cuantos;
                }
            }

            public T1 Dequeue()
            {
                if (this.Count == 0) throw new InvalidOperationException();
                T1 temp = this.primero.Valor;
                this.primero = this.primero.Siguiente;
                return temp;
            }

            public IEnumerable<T1> ElementosConIgualPrioridad(T1 quien)
            {
                List<T1> lista = new List<T1>();
                int prioridad = -1;
                Nodo<T1> current = this.primero;

                while(current != null)
                {
                    if (current.Valor.Equals(quien))
                    {
                        prioridad = current.Prioridad;
                        break;
                    }
                    current = current.Siguiente;
                }

                current = this.primero;

                while (current != null)
                {
                    if(current.Prioridad == prioridad)
                    {
                        lista.Add(current.Valor);
                    }
                    current = current.Siguiente;
                }
                return lista;

            }

            public void Enqueue(T1 elemento, int p)
            {
                if(this.Count == 0) { this.primero = new Nodo<T1>(elemento, p); return; }

                if (p > this.primero.Prioridad)
                {
                    Nodo<T1> nuevo = new Nodo<T1>(elemento, p, this.primero);
                    this.primero = nuevo;
                    return;

                }

                Nodo<T1> current = this.primero;

                while(current.Siguiente != null)
                {
                    if(current.Siguiente.Prioridad < p)
                    {
                        Nodo<T1> nuevo = new Nodo<T1>(elemento, p, current.Siguiente);
                        current.Siguiente = nuevo;
                        return;
                    }
                    current = current.Siguiente;
                }
                current.Siguiente = new Nodo<T1>(elemento, p);


            }

            public T1 Peek()
            {
                if (this.Count == 0) throw new InvalidOperationException();
                return this.primero.Valor;
            }
        }

        public interface IColaConPrioridad<T>
        { 
            /// <summary> 
            /// Añade el elemento a la cola con prioridad. El elemento deberá insertarse 
            /// delante del primer elemento cuya prioridad sea menor estricta que la del 
            /// elemento a insertar. 
            /// En caso de no encontrar ningún elemento que cumpla la anterior condición 
            /// se deberá incorporar el nuevo elemento al final de la cola. 
            /// </summary> 
            /// <param name="elemento">Elemento que deberá añadirse a la cola.</param> 
            /// <param name="p">Prioridad del elemento a insertar.</param> 
            void Enqueue(T elemento, int p);
            /// <summary> 
            /// Quita el primer elemento de la cola, devolviendo su valor. 
            /// </summary> 
            T Dequeue();
            /// <summary> 
            /// Devuelve el valor del primer elemento de la cola, sin quitarlo. 
            /// </summary> 
            T Peek();
            /// <summary> 
            /// Devuelve la cantidad de elementos almacenados en la cola. 
            /// </summary> 
            int Count { get; }
            /// <summary> 
            /// Devuelve un iterador que permite iterar por los elementos que están en la 
            /// cola y que tienen la misma prioridad con que se insertó el elemento pasado 
            /// como parámetro. 
            /// Si el elemento pasado como parámetro no está en la cola, este método 
            /// devuelve un iterador vacío. 
            /// </summary> 
            IEnumerable<T> ElementosConIgualPrioridad(T quien);
        }



    }
}
