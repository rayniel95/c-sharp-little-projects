using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Utils;

namespace SimplificandoArbol_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<int> arbol = new Arbol<int>(1,
               new Arbol<int>(20,
                   new Arbol<int>(3),
                   new Arbol<int>(17)
               ),
               new Arbol<int>(5),
               new Arbol<int>(6,
                   new Arbol<int>(7,
                       new Arbol<int>(22,
                           new Arbol<int>(21)
                       )
                   ),
                   new Arbol<int>(8),
                   new Arbol<int>(16,
                       new Arbol<int>(9),
                       new Arbol<int>(15)
                   )
               ),
               new Arbol<int>(12)
           );

            arbol.ImprimeArbol();

            Console.WriteLine();
            foreach(var el in arbol.Preorden)
                Console.Write(el);
            Console.WriteLine();

            Resuelve<int>(arbol, arbol, delegate (int ar) { return ar % 2 == 1; });

            arbol.ImprimeArbol();

            foreach(var el in arbol.Preorden)
                Console.Write(el);
        }

        public static void Resuelve<T1>(Arbol<T1> arbolActual, Arbol<T1> padre, Condicion<T1> condicion)
        {
            if(arbolActual.Hijos.Count() > 0)
            {
                foreach (var hijo in arbolActual.Hijos)
                    Resuelve(hijo, arbolActual, condicion);
            }
            if(arbolActual.Hijos.Count() == 0 && !condicion(arbolActual.Valor))
            {
                padre.EliminaHijo(arbolActual);
            }
            else if (arbolActual.Hijos.Count() > 0 && !condicion(arbolActual.Valor))
            {
                foreach (var hijo in arbolActual.Hijos)
                    padre.InsertaHijo(hijo, arbolActual);
                padre.EliminaHijo(arbolActual);
            }
        }
        public delegate bool Condicion<T>(T elemento);

    }
}
