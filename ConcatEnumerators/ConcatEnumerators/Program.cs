using System.Collections;
using System.Collections.Generic;

namespace ConcatEnumerators
{
    class Program
    {
        public class ConcatEnumerators<T> : IEnumerator<T>
        {
            IEnumerator<T>[] enumeradores;
            int cursor;
            public ConcatEnumerators(params IEnumerator<T>[] enumeradores)
            { 
                this.enumeradores = enumeradores;
                Reset();
            }
            public T Current
            {
                get
                {
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
                if(enumeradores[cursor].MoveNext())
                { return true; }

                if (cursor < enumeradores.Length)
                {
                    cursor++;
                    return true;
                }
                return false;

            }

            public void Reset()
            {
                foreach (IEnumerator<T> myi in this.enumeradores)
                    myi.Reset();
                this.cursor = 0;
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
