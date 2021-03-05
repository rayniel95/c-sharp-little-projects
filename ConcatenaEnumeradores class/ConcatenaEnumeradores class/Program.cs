using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatenaEnumeradores_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba1
            int[] temp1 = { 4, 5, 3, 8 };
            int[] temp2 = { 6, 7, 9, 3 };
            int[] temp3 = { 4, 7, 9, 3, 1, 34, 50 };
            int[] temp4 = { 3, 2, 1 };

            //foreach(var el in Concatena.ConcatenaEnumerator(temp4.GetEnumerator(), temp2.GetEnumerator(), temp3.GetEnumerator(), temp1.GetEnumerator()))
            //    Console.WriteLine(el);

            foreach(var el in new Concatenados(temp4.GetEnumerator(), temp2.GetEnumerator(), temp3.GetEnumerator(), temp1.GetEnumerator()))
                Console.WriteLine(el);

        }
        public class Concatena
        {

            public static IEnumerable ConcatenaEnumerator(params IEnumerator[] enumeradores)
            { 
                foreach(var el in enumeradores)
                {
                    while (el.MoveNext())
                        yield return el.Current;
                }
                foreach (var el in enumeradores)
                    el.Reset();
            }

        }

        public class Concatenados : IEnumerable
        {
            IEnumerator[] enumeradores;
            public Concatenados(params IEnumerator[] enumeradores)
            {
                this.enumeradores = enumeradores;
            }
            public IEnumerator GetEnumerator()
            {
                return new ConcatenaEnumeradores(this.enumeradores);
            }
        }

        public class ConcatenaEnumeradores : IEnumerator
        {
            int cursor;
            IEnumerator[] enumeradores;
            public ConcatenaEnumeradores(params IEnumerator[] enumeradores)
            {
                this.enumeradores = enumeradores;
                this.cursor = 0;
            }
            public object Current
            {
                get
                {
                    if (cursor < 0 || this.cursor >= this.enumeradores.Length) throw new InvalidOperationException();
                    return this.enumeradores[this.cursor].Current;
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
                if (this.cursor >= this.enumeradores.Length)
                    return false;

                if (this.enumeradores[this.cursor].MoveNext())
                    return true;
                while(!this.enumeradores[this.cursor].MoveNext())
                {
                    this.cursor++;
                    if (this.cursor >= this.enumeradores.Length)
                        return false;
                }
                return true;


            }

            public void Reset()
            {
                this.cursor = 0;
                foreach (var el in this.enumeradores)
                    el.Reset();
            }
        }
    }
}
