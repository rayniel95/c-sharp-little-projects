using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TQuery_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //Tree<int> root = new Tree<int>(26, 
            //                    new Tree<int>(97, 
            //                        new Tree<int>(42), 
            //                        new Tree<int>(56, 
            //                            new Tree<int>(17), 
            //                            new Tree<int>(71)), 
            //                        new Tree<int>(63)), 
            //                    new Tree<int>(11, 
            //                        new Tree<int>(7), 
            //                        new Tree<int>(14, 
            //                            new Tree<int>(13), 
            //                            new Tree<int>(92))), 
            //                    new Tree<int>(18, 
            //                        new Tree<int>(21), 
            //                        new Tree<int>(45), 
            //                        new Tree<int>(32, 
            //                            new Tree<int>(15)), 
            //                        new Tree<int>(86)));

            //MyQuery<int> myQuery = new MyQuery<int>(root);
            //foreach(var raiz in myQuery)
            //    Console.WriteLine(raiz);

            //TQuery<int> query2 = myQuery.Find(EsPar);

            //foreach(var el in query2)
            //    Console.WriteLine(el);
            #endregion

            #region Prueba2
            //Tree<int> tree1 = new Tree<int>(97, new Tree<int>(42), new Tree<int>(56, new Tree<int>(17), new Tree<int>(71)), new Tree<int>(63));
            //Tree<int> tree2 = new Tree<int>(11, new Tree<int>(7), new Tree<int>(14, new Tree<int>(13), new Tree<int>(92)));
            //Tree<int> tree3 = new Tree<int>(18, new Tree<int>(21), new Tree<int>(45), new Tree<int>(32, new Tree<int>(15)), new Tree<int>(86));

            ////PrintArbol(tree1, 0);
            ////Console.WriteLine();
            ////PrintArbol(tree2, 0);
            ////Console.WriteLine();
            ////PrintArbol(tree3, 0);
            ////Console.WriteLine();

            //TQuery<int> query = new MyQuery<int>(tree1, tree2, tree3);

            //foreach(var el in query)
            //    Console.WriteLine(el);

            //query = query.Find(EsPar);
            //Console.WriteLine();
            //foreach (var el in query)
            //    Console.WriteLine(el);

            #endregion

            #region Prueba3

            //Tree<int> root = new Tree<int>(26,
            //                    new Tree<int>(97,
            //                        new Tree<int>(42),
            //                        new Tree<int>(56,
            //                            new Tree<int>(17),
            //                            new Tree<int>(71)),
            //                        new Tree<int>(63)),
            //                    new Tree<int>(11,
            //                        new Tree<int>(7),
            //                        new Tree<int>(14,
            //                            new Tree<int>(13),
            //                            new Tree<int>(92))),
            //                    new Tree<int>(18,
            //                        new Tree<int>(21),
            //                        new Tree<int>(45),
            //                        new Tree<int>(32,
            //                            new Tree<int>(15)),
            //                        new Tree<int>(86)));

            //TQuery<int> query = new MyQuery<int>(root);

            //query = query.Find(EsPar);

            //foreach(var el in query)
            //    Console.WriteLine(el);
            //Console.WriteLine();
            //query = query.Find(EsImpar);

            //foreach(var el in query)
            //    Console.WriteLine(el);
            //Console.WriteLine();


            //query = query.Find(EsImpar);

            //foreach(var el in query)
            //    Console.WriteLine(el);
            //Console.WriteLine();

            #endregion
        }
        public class MyQuery<T1> : TQuery<T1>
        {
            List<Tree<T1>> raices;
            public MyQuery(params Tree<T1>[] roots)
            {
                this.raices = roots.ToList();
            }
            public override int Count
            {
                get
                {
                    return this.raices.Count;
                }
            }

            public override TQuery<T1> Find(Func<T1, bool> predicate)
            {
                List<Tree<T1>> nuevasRaices = new List<Tree<T1>>();

                foreach(var raiz in this.raices)
                {
                    foreach(var arbol in PreOrden(raiz))
                    {
                        if (predicate(arbol.Value))
                            nuevasRaices.Add(arbol);
                    }
                }
                List<int> aEliminar = new List<int>();
                foreach(var raiz in this.raices)
                {
                    for(int indice = 0; indice < nuevasRaices.Count; indice++)
                    {
                        if (raiz == nuevasRaices[indice])
                            aEliminar.Add(indice);
                    }
                }
                foreach (var indice in aEliminar)
                    nuevasRaices[indice] = null;

                while (nuevasRaices.Contains(null))
                    nuevasRaices.Remove(null);



                return new MyQuery<T1>(nuevasRaices.ToArray());
            }

            public override IEnumerator<T1> GetEnumerator()
            {
                foreach (var arbol in this.raices)
                    yield return arbol.Value;
            }
            IEnumerable<Tree<T1>> PreOrden(Tree<T1> arbolActual)
            {
                yield return arbolActual;
                foreach (var hijo in arbolActual.Children)
                    foreach (var hijoArbol in PreOrden(hijo))
                        yield return hijoArbol;
            }
        }
        public static void PrintArbol<T7>(Tree<T7> arbol, int llamado)
        {
            for(int nivel = 0; nivel <= llamado; nivel++)
                Console.Write("-");
            Console.Write(arbol.Value);
            Console.WriteLine();
            foreach (var hijo in arbol.Children)
                PrintArbol(hijo, llamado + 1);
        }
        public static bool EsPar(int numero)
        { return numero % 2 == 0; }
        public class Tree<T>
        {
            public Tree(T value, params Tree<T>[] children)
            {
                Value = value;
                Children = children;
            }
            public T Value { get; private set; }
            public IEnumerable<Tree<T>> Children { get; private set; }
        }
        public abstract class TQuery<T> : IEnumerable<T>
        {
            protected TQuery(params Tree<T>[] roots) { }
            public abstract int Count { get; }
            public abstract TQuery<T> Find(Func<T, bool> predicate);
            public abstract IEnumerator<T> GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
        public static bool EsImpar(int numero)
        { return numero % 2 != 0; }
    }
}
