using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterandoPorGrupos_class
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myLista = new List<int>() { 1, 3, 2, 5, 2, 1, 6 };
            IEnumerator<int> myEnumerator = myLista.GetEnumerator();

            Console.WriteLine(myEnumerator.Current);
            Agrupador<int, bool> myAgrupador = new Agrupador<int, bool>();

            int[] numbers = new int[] { 2, 4, 5, 7, 9, 10, 14, 132 };
            Person[] persons = new Person[] {
                new Person ("Juan", 20),
                new Person ("Ana", 19),
                new Person ("Alberto", 23),
                new Person ("Carlos", 20),
                new Person ("Chucho", 19),
                new Person ("Maria", 18)
            };

 

            Console.WriteLine("Agrupando pares e impares...-----------------------------");
            Print<int, bool>(myAgrupador.Agrupa(numbers, new ParitySelector()));
            Console.WriteLine();



            Agrupador<int, int> otroAgrupador = new Agrupador<int, int>();

            Console.WriteLine("Agrupando por cantidad de digitos...-----------------------------");
            Print<int, int>(otroAgrupador.Agrupa(numbers, new NumerOfDigitsSelector()));
            Console.WriteLine();



            Agrupador<Person, char> myOtro = new Agrupador<Person, char>();

            Console.WriteLine("Agrupando por primera letra...-----------------------------");
            Print<Person, char>(myOtro.Agrupa(persons, new FirstLetterSelector()));
            Console.WriteLine();



            Agrupador<Person, int> otroMas = new Agrupador<Person, int>();

            Console.WriteLine("Agrupando por edad...-----------------------------");
            Print<Person, int>(otroMas.Agrupa(persons, new AgeSelector()));
            Console.WriteLine();

    

            Console.ReadLine();
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
        public class Agrupador<T2, K2>
        {
            public IGroupEnumerator<T2, K2> Agrupa(IEnumerable<T2> coleccion, ISelector<T2, K2> selector)
            {
                return new GrupoEnumerador<T2, K2>(coleccion, selector);
            }
            class GrupoEnumerador<T1, K1> : IGroupEnumerator<T1, K1>
            {
                class Grupo
                {
                    List<T1> elementos;
                    K1 llave;
                    public Grupo(K1 llave)
                    {
                        this.llave = llave;
                        this.elementos = new List<T1>();
                    }
                    public K1 Llave { get { return this.llave; } }
                    public List<T1> Elementos { get { return this.elementos; } }

                }
                List<Grupo> grupos;
                IEnumerator<Grupo> enumeradorGrupos;
                IEnumerator<T1> enumeradorElementos;
                ISelector<T1, K1> selector;
                bool seHizoMoveNextGroup;
                bool seHizoMoveNext;
                public GrupoEnumerador(IEnumerable<T1> elementos, ISelector<T1, K1> mySelector)
                {
                    this.grupos = new List<Grupo>();
                    this.selector = mySelector;

                    foreach(var el in elementos)
                    {
                        K1 llave = this.selector.Select(el);
                        int indiceGrupo = ExisteGrupo(llave);
                        if(indiceGrupo == -1)
                        {
                            Grupo nuevoGrupo = new Grupo(llave);
                            nuevoGrupo.Elementos.Add(el);
                            this.grupos.Add(nuevoGrupo);
                        }
                        else
                        {
                            this.grupos[indiceGrupo].Elementos.Add(el);
                        }
                    }

                    this.enumeradorGrupos = this.grupos.GetEnumerator();
                    this.seHizoMoveNext = false;
                    this.seHizoMoveNextGroup = false;

                }
                int ExisteGrupo(K1 llave)
                {
                    for(int indice = 0; indice < this.grupos.Count; indice++)
                    {
                        if (this.grupos[indice].Llave.Equals(llave))
                            return indice;
                    }
                    return -1;
                }
                public T1 Current
                {
                    get
                    {
                        if (!this.seHizoMoveNextGroup || !this.seHizoMoveNext) throw new InvalidOperationException();
                        return this.enumeradorElementos.Current;
                    }
                }

                public K1 CurrentKey
                {
                    get
                    {
                        return this.enumeradorGrupos.Current.Llave;
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
                    return this.enumeradorElementos.MoveNext();
                }

                public bool MoveNextGroup()
                {
                    if(this.enumeradorGrupos.MoveNext())
                    {
                        this.seHizoMoveNextGroup = true;
                        this.enumeradorElementos = this.enumeradorGrupos.Current.Elementos.GetEnumerator();
                        this.seHizoMoveNext = false;
                        return true;
                    }
                    return false;
                }

                public void Reset()
                {
                    if (!this.seHizoMoveNextGroup) throw new InvalidOperationException();
                    this.enumeradorElementos.Reset();
                }

                public void ResetGroups()
                {
                    this.enumeradorGrupos.Reset();
                }
            }
        }
        public static void Print<T, K>(IGroupEnumerator<T, K> e)
        {
            while (e.MoveNextGroup())
            {
                Console.WriteLine(e.CurrentKey);
                Console.WriteLine("-----------");
                while (e.MoveNext())
                    Console.WriteLine("  " + e.Current);
            }
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
