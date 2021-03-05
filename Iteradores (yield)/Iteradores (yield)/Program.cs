using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteradores__yield_
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba1

            int[] temp1 = { 2, 3, 4, 6, 87, 1, 3, 1 };
            int[] temp2 = { 1, 3, 5, 7, 1, 7, 9 };

            IEnumerator<int> my = Diferencia.Resta<int>(((IEnumerable<int>)temp1).GetEnumerator(), ((IEnumerable<int>)temp2).GetEnumerator());

            while (my.MoveNext())
            {
                Console.WriteLine(my.Current);
            }
            Console.WriteLine();
            DiferenciaEnumerator<int> mo = new DiferenciaEnumerator<int>(((IEnumerable<int>)temp1).GetEnumerator(), ((IEnumerable<int>)temp2).GetEnumerator());

            while(mo.MoveNext())
                Console.WriteLine(mo.Current);

        }

        public class Diferencia
        {
            public static IEnumerator<T1> Resta<T1>(IEnumerator<T1> items1, IEnumerator<T1> items2)
            {
                while(items1.MoveNext())
                {
                    bool esta = false;
                    while(items2.MoveNext())
                    {
                        if (items2.Current.Equals(items1.Current))
                        {
                            esta = true;
                            break;
                        }
                    }
                    items2.Reset();
                    if (!esta)
                        yield return items1.Current;
                }
                yield break;
            }
        }
        public class DiferenciaEnumerator<T1> : IEnumerator<T1>
        {
            T1 current;
            IEnumerator<T1> items1;
            IEnumerator<T1> items2;
            public DiferenciaEnumerator(IEnumerator<T1> items1, IEnumerator<T1> items2)
            {
                this.items1 = items1;
                this.items2 = items2;
            }
            public T1 Current
            {
                get
                {
                    try
                    {
                        return this.current;
                    }
                    catch { throw new InvalidOperationException(); }
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
                while(this.items1.MoveNext())
                {
                    bool esta = false;
                    while(this.items2.MoveNext())
                    {
                        if(this.items2.Current.Equals(this.items1.Current))
                        {
                            esta = true;
                            break;
                        }
                    }
                    this.items2.Reset();
                    if(!esta)
                    {
                        this.current = this.items1.Current;
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                items1.Reset();
                items2.Reset();
            }
        }
    }
}
