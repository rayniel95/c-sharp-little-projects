using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterandoGrupos_class
{
    class Program
    {
        static void Main(string[] args)
        {

            IGroupEnumerator<int, bool> myEnumerador = Grouper.GroupBy<int, bool>(new int[] { 2, 4, 5, 7, 9, 10, 14, 132 }, new ParitySelector());
            Print<int, bool>(myEnumerador);
        }

        public interface ISelector<T, K>
        {
            K Select(T obj);
        }

        public interface IGroupEnumerator<T, K>
        {
            bool MoveNext();
            bool MoveNextGroup();
            K CurrentKey { get; }
            T Current { get; }
            void ResetGroups();
            void Reset();
            ISelector<T, K> Selector { get; }
        }

        public class ParitySelector : ISelector<int, bool>
        {
            public bool Select(int obj)
            {
                return obj % 2 == 0;
            }
        }   

        public class Grouper
        {
            public static IGroupEnumerator<T, K> GroupBy<T, K>(IEnumerable<T> elements, ISelector<T, K> selector)
            {
                return new GrupoNumerator<T, K>(elements, selector);
            }
        }

        public class GrupoNumerator<T1, K1> : IGroupEnumerator<T1, K1>
        {
            ISelector<T1, K1> selector;
            Dictionary<K1, List<T1>> grupos;
            IEnumerator<K1> enumerableLLaves;
            IEnumerator<T1> enumerableGrupoActual;
            bool seHizoMoveNextGroup;
            bool seHizoMoveNext;
            public GrupoNumerator(IEnumerable<T1> elementos, ISelector<T1, K1> selector)
            {
                this.grupos = new Dictionary<K1, List<T1>>();
                this.selector = selector;
                foreach(var elemento in elementos)
                {
                    if(this.grupos.ContainsKey(this.selector.Select(elemento)))
                    {
                        this.grupos[this.selector.Select(elemento)].Add(elemento);
                    }
                    else
                    {
                        List<T1> temp = new List<T1>();
                        temp.Add(elemento);
                        this.grupos.Add(this.selector.Select(elemento), temp);
                    }
                }
                this.seHizoMoveNext = false;
                this.seHizoMoveNextGroup = false;
                this.enumerableLLaves = this.grupos.Keys.GetEnumerator();

            }
            public T1 Current
            {
                get
                {
                    if (!this.seHizoMoveNext) throw new InvalidOperationException();
                    return this.enumerableGrupoActual.Current;
                }
            }

            public K1 CurrentKey
            {
                get
                {
                    if (!this.seHizoMoveNextGroup) throw new InvalidOperationException();
                    return this.enumerableLLaves.Current;
                }
            }

            public ISelector<T1, K1> Selector
            {
                get
                {
                    return this.selector;
                }
            }

            public bool MoveNext()
            {
                
                if (!this.seHizoMoveNextGroup) throw new InvalidOperationException();
                this.seHizoMoveNext = true;
                if (this.enumerableGrupoActual.MoveNext())
                    return true;
                return false;
            }

            public bool MoveNextGroup()
            {
                this.seHizoMoveNextGroup = true;
                if(this.enumerableLLaves.MoveNext())
                {
                    this.enumerableGrupoActual = this.grupos[this.enumerableLLaves.Current].GetEnumerator();
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                if (!this.seHizoMoveNextGroup) throw new InvalidOperationException();
                this.enumerableGrupoActual.Reset();
            }

            public void ResetGroups()
            {
                this.enumerableLLaves.Reset();
                this.enumerableGrupoActual.Reset();
            }
        }
        public static void Print<T, K>(IGroupEnumerator<T, K> e)
        {
            while (e.MoveNextGroup())
            {
                Console.WriteLine(e.CurrentKey);
                Console.WriteLine("-----------");
                while (e.MoveNext())
                    Console.WriteLine(" " + e.Current);
            }
        }
    }
}
