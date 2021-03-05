using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MergeEnumerator_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba 1

            int[] temp1 = { 1, 3, 4, 7, 9, 13, 15, 17 };
            int[] temp2 = { 3, 6, 9, 12, 45, 78 };
            int[] temp3 = { 4, 6, 8, 13, 46, 57 };

            //foreach (var el in Merge.MergeEnumerators<int>(new ComparaEnteros(), ((IEnumerable<int>)temp1).GetEnumerator(), ((IEnumerable<int>)temp2).GetEnumerator(),
            //    ((IEnumerable<int>)temp3).GetEnumerator()))
            //    Console.WriteLine(el);
            IEnumerator<int> my = new MergeEnumerator<int>(new ComparaEnteros(), ((IEnumerable<int>)temp1).GetEnumerator(), ((IEnumerable<int>)temp2).GetEnumerator(), 
                        ((IEnumerable<int>)temp3).GetEnumerator());
            while (my.MoveNext())
                Console.WriteLine(my.Current);

            my.Reset();
            Console.WriteLine();
            while (my.MoveNext())
                Console.WriteLine(my.Current);

        }
        public class ComparaEnteros : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }

        public class Merge
        {
            public static IEnumerable<T1> MergeEnumerators<T1>(IComparer<T1> comp, params IEnumerator<T1>[] enumeradores)
            {
                bool[] marcado = new bool[enumeradores.Length];
                for(int indice = 0; indice < enumeradores.Length; indice++)
                {
                    if (!enumeradores[indice].MoveNext())
                        marcado[indice] = true;
                }
         
                while(marcado.Contains(false))
                {
                    int indiceMenor = marcado.ToList().IndexOf(false);
                    for(int indice = 0; indice < enumeradores.Length; indice++)
                    {
                        if (!marcado[indice])
                        {
                            if (comp.Compare(enumeradores[indice].Current, enumeradores[indiceMenor].Current) < 0 || 
                                    comp.Compare(enumeradores[indice].Current, enumeradores[indiceMenor].Current) == 0)
                                indiceMenor = indice;
                        }
                    }
                    yield return enumeradores[indiceMenor].Current;
                    if (!enumeradores[indiceMenor].MoveNext())
                        marcado[indiceMenor] = true;
                }
                yield break;
            }
        }


        public class MergeEnumerator<T2> : IEnumerator<T2>
        {
            T2 current;
            IComparer<T2> comp;
            bool[] marcado;
            int indiceMenor;
            IEnumerator<T2>[] enumeradores;
            public MergeEnumerator(IComparer<T2> comp, params IEnumerator<T2>[] enumeradores)
            {
                this.comp = comp;
                this.enumeradores = enumeradores;
                this.marcado = new bool[enumeradores.Length];

                for (int indice = 0; indice < enumeradores.Length; indice++)
                {
                    if (!enumeradores[indice].MoveNext())
                        marcado[indice] = true;
                }


            }
            public T2 Current
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
                if(this.marcado.Contains(false))
                {
                    this.indiceMenor = this.marcado.ToList().IndexOf(false);
                    for(int indice = 0; indice < this.enumeradores.Length; indice++)
                    {
                        if(!marcado[indice])
                        {
                            if (comp.Compare(this.enumeradores[indice].Current, this.enumeradores[this.indiceMenor].Current) < 0 ||
                                    comp.Compare(this.enumeradores[indice].Current, this.enumeradores[this.indiceMenor].Current) == 0)
                                this.indiceMenor = indice;
                        }
                    }
                    this.current = this.enumeradores[indiceMenor].Current;
                    if (!this.enumeradores[indiceMenor].MoveNext())
                        this.marcado[indiceMenor] = true;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                foreach (var el in this.enumeradores)
                    el.Reset();
                this.marcado = new bool[marcado.Length];
                for (int indice = 0; indice < enumeradores.Length; indice++)
                {
                    if (!enumeradores[indice].MoveNext())
                        marcado[indice] = true;
                }
            }
        }

    }
}
