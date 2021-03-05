using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IENumerableDeStringLength
{
    class Program
    {
       // hazlo con un filtrador
        public class CadenasLongitud : IEnumerable<string>
        {
            int numero;
            IEnumerator<string> cadenas;
            public class Cadenas : IEnumerator<string>
            {
                int numero;
                int cursor;
                IEnumerator<string> elementos;
                public Cadenas(string[] elementos, int numero)
                {
                    this.numero = numero;
                    this.elementos = elementos;
                    Reset();
                }
                public bool MoveNext()
                {
                    while(this.elementos)
                }
                public void Reset()
                {
                    this.cursor = -1;
                }
                public void Dispose() { }
            }
            public CadenasLongitud(IEnumerable<string> cadenas, int numero)
            {
                this.numero = numero;
                this.cadenas = cadenas.GetEnumerator();
            }
            //public IEnumerator<string> GetEnumerator()
            //{
            //    return new Cadenas(this.cadenas, this.numero);
            //}
        }
        static void Main(string[] args)
        {
        }
        
    }
}
