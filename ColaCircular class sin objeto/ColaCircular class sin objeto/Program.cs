using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaCircular_class_sin_objeto
{
    class Program
    {
        public class ColaCircular<T1>
        {
            T1[] cola;
            int primero;
            int ultimo;
            int count;
            public ColaCircular()
            {
                this.cola = new T1[5];
                this.count = 0;
                this.primero = -1;
            }
            public void Enqueue(T1 item)
            {
                if (this.count == 0)
                {
                    this.primero++;
                    this.cola[this.primero] = item;
                    this.count++;
                    return;
                }

                if(this.count == this.cola.Length)
                {
                    T1[] temp = new T1[this.count * 2];

                    for (int indice = 0; indice < this.count; indice++)
                        temp[indice] = this.cola[(this.primero + 1) % this.count];

                    this.cola = temp;

                    this.primero = 0;
                    this.ultimo = this.count - 1;

                }

                this.ultimo = (this.ultimo + 1) % this.cola.Length;

                this.cola[this.ultimo] = item;

                this.count++;

            }
            public T1 Peek { get
                {
                    if (this.count == 0) throw new InvalidOperationException();

                    return this.cola[this.primero];
                } }
            //public T1 Dequeue()
            //{
            //    T1 temp = this.cola[this.primero];

            //    this.primero = (this.primero + 1) % this.cola.Length;
               
            //}
        }
        static void Main(string[] args)
        {
            Console.WriteLine(4%3);
        }
    }
}
