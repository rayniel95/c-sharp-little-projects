using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeQuery_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba1

            NodoDocumento myArbol = new NodoDocumento("div", null, null,
                                            new NodoDocumento("span", null, "resaltado",
                                                new NodoDocumento("a", "link1", null)),
                                            new NodoDocumento("a", "link2", null),
                                            new NodoDocumento("div", "contenedor", "resaltado",
                                                new NodoDocumento("span"),
                                                new NodoDocumento("span", null, "atenuado")));


            //PrintArbol(myArbol, 0);


            foreach(var el in EjecutarConsulta(myArbol, ".resaltado"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }

            Console.WriteLine();
            foreach (var el in EjecutarConsulta(myArbol, "div"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine();
            foreach (var el in EjecutarConsulta(myArbol, ".resaltado a"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (var el in EjecutarConsulta(myArbol, "div span"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (var el in EjecutarConsulta(myArbol, "#contenedor span"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (var el in EjecutarConsulta(myArbol, "div .resaltado .atenuado"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }


            Console.WriteLine("-----");

            foreach (var el in EjecutarConsulta(myArbol, "#inexistente"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }

            Console.WriteLine("-----");

            foreach (var el in EjecutarConsulta(myArbol, "div div div"))
            {
                Console.Write(el.TipoNodo + " " + el.Id + " " + el.Clase);
                Console.WriteLine();
            }

            #endregion



        }


        public static IEnumerable<NodoDocumento> EjecutarConsulta(NodoDocumento arbol, string consulta)
        {
            string[] myConsulta = consulta.Split();

            List<NodoDocumento> consultado = new List<NodoDocumento>();
            consultado.Add(arbol);
            
            for(int indice = 0; indice < myConsulta.Length; indice++)
            {
                List<NodoDocumento> nuevoConsultado = new List<NodoDocumento>();
                foreach(var myArbol in consultado)
                {
                    List<NodoDocumento> preOrden = new List<NodoDocumento>();
                    HazPreOrden(myArbol, preOrden);
                    foreach(var el in preOrden)
                    {
                        if(myConsulta[indice][0] == '.')
                        {
                            string copiaConsulta = myConsulta[indice].Remove(0, 1);

                            if (el.Clase != null && el.Clase.CompareTo(copiaConsulta) == 0)
                                nuevoConsultado.Add(el);
                        }
                        else if(myConsulta[indice][0] == '#')
                        {
                            string copiaConsulta = myConsulta[indice].Remove(0, 1);

                            if (el.Id != null && el.Id.CompareTo(copiaConsulta) == 0)
                                nuevoConsultado.Add(el);
                        }
                        else if(el.TipoNodo.CompareTo(myConsulta[indice]) == 0)
                        {
                            nuevoConsultado.Add(el);
                        }

                    }

                }
                consultado = nuevoConsultado;
            }
            return consultado;

        }

        public static void HazPreOrden(NodoDocumento arbolActual, List<NodoDocumento> lista)
        {
            lista.Add(arbolActual);
            foreach (var hijo in arbolActual.Hijos)
                HazPreOrden(hijo, lista);
        }

        public class NodoDocumento
        {
            public NodoDocumento(string tipoNodo, string id=null, string clase=null, params NodoDocumento[] hijos)
            {
                TipoNodo = tipoNodo;
                Clase = clase;
                Id = id;
                Hijos = hijos;
            }
            public string TipoNodo { get; private set; }
            public string Id { get; private set; }
            public string Clase { get; private set; }
            public NodoDocumento[] Hijos { get; private set; }
        }
        public static void PrintArbol(NodoDocumento arbolActual, int llamado)
        {
            for(int veces = 0; veces < llamado; veces++)
            {
                Console.Write("-");
            }
            Console.Write(arbolActual.TipoNodo + " " + arbolActual.Id + " " + arbolActual.Clase);
            Console.WriteLine();

            foreach (var hijo in arbolActual.Hijos)
                PrintArbol(hijo, llamado + 1);
        }
    }
}
