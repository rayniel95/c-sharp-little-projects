using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IterarGrupos_class
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 2, 4, 5, 7, 9, 10, 14, 132 };
            Person[] persons = new Person[] {
                new Person ("Juan", 20),
                new Person ("Ana", 19),
                new Person ("Alberto", 23),
                new Person ("Carlos", 20),
                new Person ("Chucho", 19),
                new Person ("Maria", 18)
            };

            #region Pares e impares

            Console.WriteLine("Agrupando pares e impares...-----------------------------");
            Print<int, bool>(new GroupEnumerator<int, bool>(numbers, new ParitySelector()));
            Console.WriteLine();

            #endregion

            #region Numero de digitos

            Console.WriteLine("Agrupando por cantidad de digitos...-----------------------------");
            Print<int, int>(new GroupEnumerator<int, int>(numbers, new NumerOfDigitsSelector()));
            Console.WriteLine();

            #endregion

            #region Primera letra

            Console.WriteLine("Agrupando por primera letra...-----------------------------");
            Print<Person, char>(new GroupEnumerator<Person, char>(persons, new FirstLetterSelector()));
            Console.WriteLine();

            #endregion

            #region Por edad

            Console.WriteLine("Agrupando por edad...-----------------------------");
            Print<Person, int>(new GroupEnumerator<Person, int>(persons, new AgeSelector()));
            Console.WriteLine();

            #endregion

            Console.ReadLine();


        }

        public class GroupEnumerator<T1, K1> : IGroupEnumerator<T1, K1>
        {
            Dictionary<K1, List<T1>> elementos;
            ISelector<T1, K1> selector;
            IEnumerator<K1> llaves;
            IEnumerator<T1> datos;
            public GroupEnumerator(IEnumerable<T1> secuencia, ISelector<T1, K1> selector)
            {
                this.elementos = new Dictionary<K1, List<T1>>();
                this.selector = selector;

                foreach(var el in secuencia)
                {
                    if (this.elementos.ContainsKey(selector.Select(el)))
                        this.elementos[selector.Select(el)].Add(el);
                    else
                    {
                        this.elementos.Add(selector.Select(el), new List<T1>());
                        this.elementos[selector.Select(el)].Add(el);
                    }
                }
                this.llaves = this.elementos.Keys.GetEnumerator();
     
            }
            public T1 Current
            {
                get
                {
                    return this.datos.Current;
                }
            }

            public K1 CurrentKey
            {
                get
                {
                    return this.llaves.Current;
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
                return this.datos.MoveNext();
            }

            public bool MoveNextGroup()
            {
                if(this.llaves.MoveNext())
                {
                    this.datos = this.elementos[this.llaves.Current].GetEnumerator();
                    return true;
                }
                return false;

            }

            public void Reset()
            {
                this.datos.Reset();
            }

            public void ResetGroups()
            {
                this.llaves.Reset();
                this.datos = new List<T1>().GetEnumerator();
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

        public interface ISelector<T, K>
        {
            K Select(T obj);
        }
        ///<summary>
    /// Define funcionalidades para un iterador de grupos.
    ///</summary>
    ///<typeparamname="T">El tipo de los elementos enumerados.</typeparam>
    ///<typeparamname="K">El tipo de la característicacomún para cada grupo.</typeparam>
        public interface IGroupEnumerator<T, K>
        {
            ///<summary>
            /// Se mueve hacia el próximo elemento en el grupo actual.
            /// Si no hay más elementos en el grupo devuelve false, de lo contrario devuelve true.
            /// Lanza InvalidOperationExcepcion si se invoca antes de MoveNextGroup.
            ///</summary>
            ///<returns>Un valor booleano indicando si hubo un próximo elemento.</returns>
            bool MoveNext();
            ///<summary>
            /// Se mueve hacia el próximo grupo y devuelve true; si no hay mas grupos devuelve false.
            ///</summary>
            ///<returns>Devuelve un valor bool indicando si se pudo mover al próximo grupo.</returns>
            bool MoveNextGroup();
            ///<summary>
            /// Devuelve el valor de la característica que identifica al grupo actual.
            /// Lanza InvalidOperationExcepcion si se invoca antes de MoveNextGroup.
            ///</summary>
            K CurrentKey { get; }
            ///<summary>
            /// Devuelve el valor del elemento actual del grupo que se está iterando.
            /// Lanza InvalidOperationExcepcion si se invoca antes de MoveNext.
            ///</summary>
            T Current { get; }
            ///<summary>
            /// Reinicia la iteración de los grupos.
            ///</summary>
            void ResetGroups();
            ///<summary>
            /// Reinicia la iteración de los elementos del grupo actual.
            /// Lanza InvalidOperationExcepcion si se invoca antes de MoveNextGroup.
            ///</summary>
            void Reset();
            ///<summary>
            /// Devuelve el selector que está siendo usado para agrupar los elementos.
            ///</summary>
            ISelector<T, K> Selector { get; }
        }

        public class Person
        {
            private string _Name;

            public string Name { get { return _Name; } }

            private int _Age;

            public int Age { get { return _Age; } }

            public Person(string name, int age)
            {
                this._Name = name;
                this._Age = age;
            }

            public override string ToString()
            {
                return Name + " (" + Age + ")";
            }
        }

        #region Selectors

        public class ParitySelector : ISelector<int, bool>
        {
            public bool Select(int obj)
            {
                return obj % 2 == 0;
            }
        }

        public class NumerOfDigitsSelector : ISelector<int, int>
        {
            public int Select(int obj)
            {
                return obj.ToString().Length;
            }
        }

        public class FirstLetterSelector : ISelector<Person, char>
        {
            public char Select(Person obj)
            {
                return obj.Name[0];
            }
        }

        public class AgeSelector : ISelector<Person, int>
        {
            public int Select(Person obj)
            {
                return obj.Age;
            }
        }

        #endregion
    }
}
