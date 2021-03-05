using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaCategoria_class
{
    class Program
    {
        static void Main(string[] args)
        {
            ColaConCategoria<string> q = new ColaConCategoria<string>();
            string catPlanJaba = "Plan Jaba";
            string catNormal = "Normal";
            string catEmbarazadas = "Embarazadas";

            q.AgregaCategoria(catPlanJaba, 2);
            q.AgregaCategoria(catNormal, 1);
            q.AgregaCategoria(catEmbarazadas, 4);

            q.Enqueue(catPlanJaba, "Juan");
            q.Enqueue(catPlanJaba, "Pedro");
            q.Enqueue(catNormal, "Jose");
            q.Enqueue(catEmbarazadas, "Ana");
            q.Enqueue(catNormal, "Maria");
            q.Enqueue(catNormal, "Carlos");
            q.Enqueue(catEmbarazadas, "Arnold");
            q.Enqueue(catPlanJaba, "Jesus");

            IEnumerator<string> cosa = q.GetEnumerator();

            while(cosa.MoveNext())
                Console.WriteLine(cosa.Current);

            q.Enqueue(catEmbarazadas, "Lola");
            q.Enqueue(catPlanJaba, "Raul");

            Console.WriteLine();

            ColaConCategoria<int> t = new ColaConCategoria<int>();
            t.AgregaCategoria("rojo", 10);
            t.AgregaCategoria("verde", 2);
            t.AgregaCategoria("azul", 1);

            t.Enqueue("rojo", 1);
            t.Enqueue("rojo", 2);
            t.Enqueue("rojo", 3);

            Console.WriteLine(t.Dequeue());
            Console.WriteLine(t.Dequeue());
            Console.WriteLine(t.Dequeue());

            t.Enqueue("verde", 4);
            t.Enqueue("verde", 5);
            t.Enqueue("verde", 6);
            t.Enqueue("azul", 7);
            t.Enqueue("rojo", 8);

            IEnumerator<int> cosa2 = t.GetEnumerator();

            while (cosa2.MoveNext())
                Console.Write(cosa2.Current);
        }
        public class ColaConCategoria<T1> : IEnumerable<T1>
        {
            class EnumerableCategorias : IEnumerable<string>
            {
                List<Categoria> categor;
                public EnumerableCategorias(List<Categoria> categor)
                {
                    this.categor = categor;
                }
                public IEnumerator<string> GetEnumerator()
                {
                    return new CategoriaEnumerator(this.categor);
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
            class CategoriaEnumerator : IEnumerator<string>
            {
                int cursor;
                string current;
                List<Categoria> categorias;
                public CategoriaEnumerator(List<Categoria> categorias)
                {
                    this.cursor = -1;
                    this.current = null;
                    this.categorias = categorias;
                }
                public string Current
                {
                    get
                    {
                        if (this.cursor == -1 || this.categorias.Count == 0)
                            throw new InvalidOperationException();
                        return this.current;
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        return this.Current;
                    }
                }

                public void Dispose()
                {
         
                }

                public bool MoveNext()
                {
                    this.cursor++;
                    if(this.cursor < this.categorias.Count)
                    {
                        this.current = this.categorias[this.cursor].Nombre;
                        return true;
                    }
                    return false;
                }

                public void Reset()
                {
                    this.current = null;
                    this.cursor = -1;
                }
            }
            class Categoria
            {
                string nombre;
                int cantidad;
                public Categoria(string nombre, int cantidad)
                {
                    this.nombre = nombre;
                    this.cantidad = cantidad;
                }
                public int Cantidad { get { return this.cantidad; } }
                public string Nombre { get { return this.nombre; } }
            }
            class ElementosEnumerator : IEnumerator<T1>
            {
                ColaConCategoria<T1> cola;
                T1 current;
                bool seHizoMoveNext;
                public ElementosEnumerator(ColaConCategoria<T1> cola)
                {
                    this.cola = cola;
                    this.seHizoMoveNext = false;
                }
                public T1 Current
                {
                    get
                    {
                        if (!this.seHizoMoveNext) throw new InvalidOperationException();
                        return this.current;
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        return this.Current;
                    }
                }

                public void Dispose()
                {
         
                }

                public bool MoveNext()
                {
                    this.seHizoMoveNext = true;
                    if (this.cola.Count == 0) return false;
                    this.current = this.cola.Dequeue();
                    return true;
                }

                public void Reset()
                {
      
                }
            }
            List<Categoria> categorias;
            List<Queue<T1>> elementos;
            int cursor;
            int cantidadExtraida;
            public ColaConCategoria()
            {
                this.categorias = new List<Categoria>();
                this.elementos = new List<Queue<T1>>();
                this.cursor = 0;
                this.cantidadExtraida = 0;

            }
            public IEnumerator<T1> GetEnumerator()
            {
                return new ElementosEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public void AgregaCategoria(string categoria, int cantidad)
            {
                if (categoria == null) throw new ArgumentNullException();
                foreach(var el in this.categorias)
                {
                    if (el.Nombre.Equals(categoria))
                        throw new ArgumentException();
                }
                if (cantidad < 1) throw new ArgumentOutOfRangeException();

                Categoria cat = new Categoria(categoria, cantidad);
                this.categorias.Add(cat);
                this.elementos.Add(new Queue<T1>());
            }
            public IEnumerable<string> Categorias
            {
                get
                {
                    EnumerableCategorias cat = new EnumerableCategorias(this.categorias);
                    return cat;
                }
            }
            public void Enqueue(string categoria, T1 valor)
            {
                if (valor == null) return;
                if (categoria == null) throw new ArgumentNullException();
                bool esta = false;
                foreach(var el in this.categorias)
                {
                    if (el.Nombre.Equals(categoria))
                        esta = true;
                }
                if (!esta) throw new ArgumentOutOfRangeException();

                for(int indice = 0; indice < this.categorias.Count; indice++)
                {
                    if (this.categorias[indice].Nombre.Equals(categoria))
                        this.elementos[indice].Enqueue(valor);
                }
            }
            public T1 Dequeue()
            {
                if (this.Count == 0) throw new InvalidOperationException();
                this.cantidadExtraida++;
                if (this.cantidadExtraida >= this.categorias[this.cursor].Cantidad + 1)
                {
                    this.cantidadExtraida = 1;
                    this.cursor++;
                    if (this.cursor >= this.categorias.Count)
                        this.cursor = 0;
                }
                if (this.elementos[this.cursor].Count == 0)
                {
                    while(this.elementos[this.cursor].Count == 0)
                    {
                        this.cantidadExtraida = 1;
                        this.cursor++;
                        if (this.cursor == this.categorias.Count)
                            this.cursor = 0;
                       
                    }
                }
                return this.elementos[this.cursor].Dequeue();

            }
            public T1 Peek()
            {
                return default(T1);
                
            }
            public int Count
            {
                get
                {
                    int count = 0;
                    for (int indice = 0; indice < this.elementos.Count; indice++)
                        count += this.elementos[indice].Count;
                    return count;
                }
            }
        }
    }
}
