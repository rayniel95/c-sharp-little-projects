using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Arboles;

namespace CaminoPosterior_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1
            //    #region Arbol
            //Arbol<int> myArbol = new Arbol<int>(2,
            //                            new Arbol<int>(23,
            //                                new Arbol<int>(3,
            //                                    new Arbol<int>(31,
            //                                        new Arbol<int>(40,
            //                                            new Arbol<int>(48,
            //                                                new Arbol<int>[0]),
            //                                            new Arbol<int>(41,
            //                                                new Arbol<int>[0]))),
            //                                    new Arbol<int>(32,
            //                                        new Arbol<int>[0])),
            //                                new Arbol<int>(6,
            //                                    new Arbol<int>(61,
            //                                        new Arbol<int>(77,
            //                                            new Arbol<int>[0]),
            //                                        new Arbol<int>(67,
            //                                            new Arbol<int>(15,
            //                                                new Arbol<int>(23,
            //                                                    new Arbol<int>[0])),
            //                                            new Arbol<int>(39,
            //                                                new Arbol<int>[0]))))),
            //                            new Arbol<int>(22,
            //                                new Arbol<int>(4,
            //                                    new Arbol<int>[0]),
            //                                new Arbol<int>(8,
            //                                    new Arbol<int>(82,
            //                                        new Arbol<int>[0]),
            //                                    new Arbol<int>(84,
            //                                        new Arbol<int>(99,
            //                                            new Arbol<int>[0]),
            //                                        new Arbol<int>(42,
            //                                            new Arbol<int>(52,
            //                                                new Arbol<int>[0]),
            //                                            new Arbol<int>(57,
            //                                                new Arbol<int>[0])))),
            //                                new Arbol<int>(5,
            //                                    new Arbol<int>(55,
            //                                        new Arbol<int>(88,
            //                                            new Arbol<int>[0]),
            //                                        new Arbol<int>(100,
            //                                            new Arbol<int>(43,
            //                                                new Arbol<int>[0]),
            //                                            new Arbol<int>(18,
            //                                                new Arbol<int>(28,
            //                                                    new Arbol<int>[0]))),
            //                                        new Arbol<int>(66,
            //                                            new Arbol<int>[0])),
            //                                    new Arbol<int>(59,
            //                                        new Arbol<int>(102,
            //                                            new Arbol<int>(0,
            //                                                new Arbol<int>[0]),
            //                                            new Arbol<int>(50,
            //                                                new Arbol<int>[0]))))),
            //                            new Arbol<int>(21,
            //                                new Arbol<int>(1,
            //                                    new Arbol<int>[0]),
            //                                new Arbol<int>(9,
            //                                    new Arbol<int>(90,
            //                                        new Arbol<int>(33,
            //                                            new Arbol<int>[0])))),
            //                            new Arbol<int>(24,
            //                                new Arbol<int>(7,
            //                                    new Arbol<int>[0]),
            //                                new Arbol<int>(3,
            //                                    new Arbol<int>(30,
            //                                        new Arbol<int>[0])),
            //                                new Arbol<int>(10,
            //                                    new Arbol<int>(11,
            //                                        new Arbol<int>(22,
            //                                            new Arbol<int>[0]),
            //                                        new Arbol<int>(44,
            //                                            new Arbol<int>[0])))));
            //#endregion
            //List<Arbol<int>> myCamino = new List<Arbol<int>>();
            //List<Arbol<int>> myPosteriores = new List<Arbol<int>>();
            //bool encont = false;

            //HazCamino(myArbol, new List<Arbol<int>>(), 100, ref encont, ref myCamino, ref myPosteriores);

            //foreach (var arbol in myCamino)
            //{
            //    Console.Write(arbol.Valor + "\t");
            //}
            //Console.WriteLine();
            //foreach(var arbol in myPosteriores)
            //    Console.Write(arbol.Valor + "\t");
            //Console.WriteLine();
            #endregion

        }


        public static void HazCamino<T1>(Arbol<T1> arbolActual, List<Arbol<T1>> caminoActual, T1 buscado, ref bool encontrado, ref List<Arbol<T1>> camino, 
            ref List<Arbol<T1>> posteriores)
        {
            caminoActual.Add(arbolActual);

            if(arbolActual.Valor.Equals(buscado))
            {
                camino = new List<Arbol<T1>>(caminoActual);
                encontrado = true;
                return;
            }
            if (encontrado) posteriores.Add(arbolActual);

            foreach(var hijo in arbolActual.Hijos)
            {
                HazCamino(hijo, caminoActual, buscado, ref encontrado, ref camino, ref posteriores);
            }
            caminoActual.RemoveAt(caminoActual.Count - 1);
        }
    }
}
