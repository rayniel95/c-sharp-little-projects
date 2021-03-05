using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstruyendoArbol_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            string myCadena = "(A(BC)(DE(FGH))I)";
            PrintArbol(HazArbol(myCadena), 0);




        }
        public static Arbol HazArbol(string cadena)
        {
            Arbol nuevo = null;
            for(int indice = 0; indice < cadena.Length; indice++)
            {
                if (cadena[indice] == '(')
                {
                    nuevo = new Arbol(cadena[indice + 1].ToString());
                    Resuelve(nuevo, cadena, indice + 2);
                    break;
                }
            }

            return nuevo;
        }
        public static void Resuelve(Arbol arbolActual, string cadena, int myIndice)
        {
            // ponle un array boleano a esto y terminalo
            for (int indice = myIndice; indice < cadena.Length; indice++)
            {
                Arbol nuevo;
                if (cadena[indice] == '(')
                {
                    nuevo = new Arbol(cadena[indice + 1].ToString());
                    arbolActual.Hijos.Add(nuevo);
                    Resuelve(nuevo, cadena, indice + 2);
                }
                else if(char.IsLetter(cadena[indice]))
                {
                    nuevo = new Arbol(cadena[indice].ToString());
                    continue;
                }
                else if(cadena[indice] == ')')
                {
                    return;
                }
            }
        }
        public static void PrintArbol(Arbol arbolActual, int llamado)
        {
            for(int indice = 0; indice < llamado; indice++)
            {
                Console.Write("-");
            }
            Console.Write(arbolActual.Valor);
            Console.WriteLine();
            foreach (var hijo in arbolActual.Hijos)
                PrintArbol(hijo, llamado + 1);
        }
        public class Arbol
        {
            public Arbol (string valor, params Arbol[] hijos)
            {
                Valor = valor;
                Hijos = hijos.ToList();
            }
            public string Valor { get; private set; }
            public List<Arbol> Hijos { get; private set; }
        }
    }
}
