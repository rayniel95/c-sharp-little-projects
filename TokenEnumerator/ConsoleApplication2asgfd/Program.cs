using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2asgfd
{
    public class Token<T> : IEnumerable<T>
    {
        class Enumerator<T> : IEnumerator<T>
        {
            int cursor;
            IEnumerator<T> enumerador;
            int tope;
            public Enumerator(IEnumerator<T> enumerador, int cuantos)
            {
                this.enumerador = enumerador;
                this.tope = cuantos;
                Reset();
            }
            public bool MoveNext()
            {
                if (this.enumerador.MoveNext() && this.cursor < this.tope)
                {
                    this.cursor++;
                    return true;
                }
                return false;
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public T Current
            {
                get
                {
                    if (this.cursor < 0)
                        throw new InvalidOperationException();
                    return this.enumerador.Current;
                }
            }
            public void Reset()
            {
                this.cursor = -1;
            }
            public void Dispose() { }
        }// adopto el protocolo de que no se puede hacer current sin antes haber hecho un move next
        IEnumerable<T> enumerable;
        int numero;
        public Token(IEnumerable<T> enumerable, int numero)
        {
            this.numero = numero;
            this.enumerable = enumerable;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this.enumerable.GetEnumerator(), this.numero);
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
