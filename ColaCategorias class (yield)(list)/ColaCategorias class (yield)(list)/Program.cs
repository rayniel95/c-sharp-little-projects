using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaCategorias_class__yield__list_
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba1
            //ColaCategoria<string> q = new ColaCategoria<string>();
            //string catPlanJaba = "Plan Jaba";
            //string catNormal = "Normal";
            //string catEmbarazadas = "Embarazadas";
            //q.AgregaCategoria(catPlanJaba, 2);
            //q.AgregaCategoria(catNormal, 1);
            //q.AgregaCategoria(catEmbarazadas, 4);
            //q.Enqueue(catPlanJaba, "Juan");
            //q.Enqueue(catPlanJaba, "Pedro");
            //q.Enqueue(catNormal, "Jose");
            //q.Enqueue(catEmbarazadas, "Ana");
            //q.Enqueue(catNormal, "Maria");
            //q.Enqueue(catNormal, "Carlos");
            //q.Enqueue(catEmbarazadas, "Arnold");
            //q.Enqueue(catPlanJaba, "Jesus");

            //foreach(var el in q)
            //    Console.WriteLine(el);

            //Console.WriteLine();

            //q.Dequeue();
            //q.Dequeue();
            //q.Dequeue();
            //q.Enqueue(catEmbarazadas, "Lola");
            //q.Enqueue(catPlanJaba, "Raul");

            //foreach(var el in q)
            //    Console.WriteLine(el);

            //Console.WriteLine();

            // prueba2
            //ColaCategoria<int> q = new ColaCategoria<int>();
            //q.AgregaCategoria("rojo", 10);
            //q.AgregaCategoria("verde", 2);
            //q.AgregaCategoria("azul", 1);
            //q.Enqueue("rojo", 1);
            //q.Enqueue("rojo", 2);
            //q.Enqueue("rojo", 3);
            //q.Dequeue();
            //q.Dequeue();
            //q.Dequeue();
            //q.Enqueue("verde", 4);
            //q.Enqueue("verde", 5);
            //q.Enqueue("verde", 6);
            //q.Enqueue("azul", 7);
            //q.Enqueue("rojo", 8);

            //foreach (var el in q)
            //    Console.WriteLine(el);


            // prueba3
            //ColaCategoria<string> q = new ColaCategoria<string>();
            //q.AgregaCategoria("A", 1);
            //q.Enqueue("A", "A1");
            //Console.WriteLine(q.Dequeue());
            //q.AgregaCategoria("B", 2);
            //q.Enqueue("B", "B1");
            //q.Enqueue("B", "B2");
            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());
            //q.Enqueue("A", "A2");
            //q.Enqueue("B", "B3");
            //q.Enqueue("B", "B4");
            //Console.WriteLine("Peek :" + q.Peek());
            //q.AgregaCategoria("C", 1);
            //q.Enqueue("C", "C1");

            //foreach(var el in q)
            //    Console.WriteLine(el);




        }

        public interface IColaCategoria<T1>
        {
            void AgregaCategoria(string categoria, int cantidad);

            IEnumerable<string> Categorias { get; }
            void Enqueue(string categoria, T1 valor);
            T1 Dequeue();
            T1 Peek();
            int Count { get; }
            IEnumerator<T1> GetEnumerator();
        }

        public class ColaCategoria<T1> : IColaCategoria<T1>
        {
            List<int> valores;
            List<string> categorias;
            List<Queue<T1>> elementos;
            int elementosSacados;
            int elementoActual;
            public ColaCategoria()
            {
                this.valores = new List<int>();
                this.categorias = new List<string>();
                this.elementos = new List<Queue<T1>>();
                this.elementosSacados = 0;
                this.elementoActual = 0;
            }
            public IEnumerable<string> Categorias
            {
                get
                {
                    return this.categorias;
                }
            }

            public int Count
            {
                get
                {
                    int count = 0;
                    foreach(var el in this.elementos)
                    {
                        count += el.Count;
                    }
                    return count;
                }
            }

            public void AgregaCategoria(string categoria, int cantidad)
            {
                if (categoria.Replace(" ", "") == "" || categoria == null || cantidad < 0 || this.categorias.Contains(categoria)) throw new InvalidOperationException();

                this.categorias.Add(categoria);
                this.valores.Add(cantidad);
                this.elementos.Add(new Queue<T1>());
            }

            public T1 Dequeue()
            {
                if (Count == 0) throw new InvalidOperationException();

                if(this.elementosSacados == this.valores[this.elementoActual])
                {
                    this.elementosSacados = 0;
                    this.elementoActual++;
                }
                if (this.elementoActual == this.categorias.Count)
                    this.elementoActual = 0;

                while(this.elementos[this.elementoActual].Count == 0)
                {
                    this.elementoActual++;
                    if (this.elementoActual == this.categorias.Count)
                        this.elementoActual = 0;
                }

                this.elementosSacados++;
                return this.elementos[this.elementoActual].Dequeue();
            }

            public void Enqueue(string categoria, T1 valor)
            {
                // falta el control de excepciones aca
                this.elementos[this.categorias.IndexOf(categoria)].Enqueue(valor);
            }

            public IEnumerator<T1> GetEnumerator()
            {
                List<Queue<T1>> temp = new List<Queue<T1>>();

                foreach(var el in this.elementos)
                {
                    temp.Add(new Queue<T1>(el));
                }

                int tempElemActual = this.elementoActual;
                int tempElemSacados = this.elementosSacados;
                while (HayElementos(temp))
                {
                    for(int indice = tempElemActual; indice < this.categorias.Count && HayElementos(temp); indice++)
                    {
                        for(int veces = tempElemSacados; veces < this.valores[indice]; veces++)
                        {
                            if(temp[indice].Count > 0)
                                yield return temp[indice].Dequeue();
                        }
                        tempElemSacados = 0;
                    }
                    tempElemActual = 0;
                }
                yield break;
            }
            bool HayElementos(List<Queue<T1>> elem)
            {
                foreach(var el in elem)
                {
                    if (el.Count > 0)
                        return true;
                }
                return false;
            }
            public T1 Peek()
            {
                if (Count == 0) throw new InvalidOperationException();
                int tempSacados = this.elementosSacados;
                int tempActual = this.elementoActual;
                if (tempSacados == this.valores[tempActual])
                {
                    tempSacados = 0;
                    tempActual++;
                }
                if (tempActual == this.categorias.Count)
                    tempActual = 0;

                while (this.elementos[tempActual].Count == 0)
                {
                    tempActual++;
                    if (tempActual == this.categorias.Count)
                        tempActual = 0;
                }

                return this.elementos[tempActual].Peek();
            }
        }
    }
}
