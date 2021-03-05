using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArbolLevelEnumerator_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            // prueba1
            Arbol<int> myArbol = new Arbol<int>(6,
                                        new Arbol<int>(3,
                                            new Arbol<int>(5),
                                            new Arbol<int>(7,
                                                new Arbol<int>(8),
                                                new Arbol<int>(4),
                                                new Arbol<int>(12))),
                                        new Arbol<int>(9),
                                        new Arbol<int>(1,
                                            new Arbol<int>(2,
                                                new Arbol<int>(45),
                                                new Arbol<int>(23))));
            PrintArbol(myArbol, 0);
            ArbolLevelEnumerator<int> myEnumerator = new ArbolLevelEnumerator<int>(myArbol);
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine(myEnumerator.Current);
                if (myEnumerator.Current == 3)
                    myEnumerator.JumpNextLevel();
                
            }

        }

        public interface ILevelEnumerator<T>:IEnumerator<T>
        {
            bool JumpNextLevel();

        }

        public class ArbolLevelEnumerator<T> : ILevelEnumerator<T>
        {
            int altura;
            Arbol<T> arbol;
            IEnumerator<T> valores;
            IEnumerator<int> niveles;
            public ArbolLevelEnumerator(Arbol<T> arbol)
            {
                this.altura = Altura(arbol);
                this.arbol = arbol;
                List<T> valores = new List<T>();
                List<int>niveles = new List<int>();

                for(int nivel = 0; nivel <= this.altura; nivel++)
                {
                    Recorrido(this.arbol, 0, nivel, valores, niveles);
                }
                this.valores = valores.GetEnumerator();
                this.niveles = niveles.GetEnumerator();
                
            }
            public T Current
            {
                get
                {
                    return this.valores.Current;
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public bool MoveNext()
            {
                this.niveles.MoveNext();
                return this.valores.MoveNext();
            }
            public void Reset()
            {
                this.valores.Reset();
                this.niveles.Reset();
            }
            public bool JumpNextLevel()
            {
                int nivelActual = 0;
                try
                {
                    nivelActual = this.niveles.Current;
                }
                catch { return false; }
                while(nivelActual == this.niveles.Current)
                {
                    if (!this.niveles.MoveNext())
                    {
                        this.valores.MoveNext();
                        return false;
                    }
                    this.valores.MoveNext();
                }
                return true;
            }
            public void Dispose()
            {

            }
            void Recorrido(Arbol<T> arbol, int llamado, int nivel, List<T> valores, List<int> niveles)
            {
                if(llamado == nivel)
                {
                    valores.Add(arbol.Valor);
                    niveles.Add(nivel);
                    return;
                }
                foreach (var hijo in arbol.Hijos)
                    Recorrido(hijo, llamado + 1, nivel, valores, niveles);
            }
            int Altura(Arbol<T> arbol)
            {
                int altura = 0;

                foreach(var hijo in arbol.Hijos)
                {
                    if (Altura(hijo) > altura)
                        altura = Altura(hijo);

                }
                return 1 + altura;
            }
        }

        public static void PrintArbol<T5>(Arbol<T5> arbol, int llamado)
        {
            for(int indice = 0; indice <= llamado; indice++)
                Console.Write("-");
            Console.Write(arbol.Valor);
            Console.WriteLine();
            foreach (var hijo in arbol.Hijos)
                PrintArbol(hijo, llamado + 1);
        }
        public class Arbol<T2>
        {
            public Arbol(T2 valor, params Arbol<T2>[] hijos)
            {
                Valor = valor;
                Hijos = hijos;
            }
            public T2 Valor { get; private set; }
            public Arbol<T2>[] Hijos { get; private set; }
        }
    }
}
