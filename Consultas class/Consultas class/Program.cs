using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas_class
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int x in new Consulta<int>(new int[] { 1, 2, 3, 4, 5 }))
                Console.WriteLine(x);

            Console.WriteLine();

            Consulta<int> numeros = new Consulta<int>(new int[] { 1, 2, 3, 4, 5 });
            Consulta<int> pares = numeros.Filtra(e => e % 2 == 0);
            foreach (int x in pares)
                Console.WriteLine(x);

            Console.WriteLine();

            string[] palabras = new string[] { "Hola", "Mundo", "Programación" };
            Consulta<int> longitudes =
            new Consulta<string>(palabras).Transforma<int>(p => p.Length);
            foreach (int n in longitudes)
                Console.WriteLine(n);

            Console.WriteLine();

            Console.WriteLine(new Consulta<string>(new string[] { "A", "B", "C" }).Existe(x => x.ToLower() == "c"));

            Console.WriteLine();

            string[] colores = new string[] { "azul", "blanco", "rojo", "amarillo" };
            foreach(var el in new Consulta<string>(colores).Filtra(s => s.Length > 5))
                Console.WriteLine("Cantidad de cadenas de longitud mayor de 5 {0}", el);

            Console.WriteLine();


        }

        public class Consulta<T1> : IEnumerable<T1>
        {
            IEnumerable<T1> elementos;
            public Consulta(IEnumerable<T1> elementos)
            {
                this.elementos = elementos;
            }
            public Consulta<T1> Salta(int n)
            {
                if (n >= this.elementos.Count())
                    return null;

                List<T1> nuevoElementos = new List<T1>();

                for(int indice = 0; indice < this.elementos.Count(); indice++)
                {
                    if(indice > n)
                    {
                        nuevoElementos.Add(this.elementos.ElementAt(indice));
                    }
                }
                return new Consulta<T1>(nuevoElementos);
         

            }
            public int Cantidad
            {
                get
                {

                    return this.elementos.Count();
                }
            }
            public bool ParaTodos(Func<T1, bool> predicado)
            {
                foreach(var el in this.elementos)
                {
                    if (!predicado(el))
                        return false;
                }
                return true;
            }
            public bool Existe(Func<T1, bool> predicado)
            {
                foreach(var el in this.elementos)
                {
                    if (predicado(el))
                        return true;
                }
                return false;
            }
            public Consulta<R> Transforma<R>(Func<T1, R> transformacion)
            {
                List<R> nuevoElementos = new List<R>();
                foreach(var el in this.elementos)
                {
                    nuevoElementos.Add(transformacion(el));
                }
                return new Consulta<R>(nuevoElementos);

            }
            public Consulta<T1> Filtra(Func<T1, bool> predicado)
            {
                List<T1> nuevoElementos = new List<T1>();

                foreach(var el in this.elementos)
                {
                    if (predicado(el))
                        nuevoElementos.Add(el);
                }
                return new Consulta<T1>(nuevoElementos);
            }

            public IEnumerator<T1> GetEnumerator()
            {
                return this.elementos.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
