using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuenciaIncremental_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SecuenciasCrecientes("874961"));
        }
        public static int SecuenciasCrecientes(string myCadena)
        {
            int myNumero = 0;
            int[] myArray = new int[myCadena.Length - 1];
            for (int indice = 1; indice < myCadena.Length; indice++)
                myArray[indice - 1] = indice;
            for (int indice = 0; indice < myCadena.Length; indice++)
                Combinaciones(myArray, new int[indice + 1], 0, 0, myCadena, ref myNumero);
            myNumero++;
            return myNumero;
        }
        public static void Combinaciones(int[] array, int[] combinacion, int posicionArray, int posicionCombinacion, string cadena, ref int numero)
        {
            if (posicionCombinacion == combinacion.Length)
            {
                List<int> indices = new List<int>();

                indices.Add(0);
                foreach(var el in combinacion)
                {
                    indices.Add(el);
                }
                indices.Add(cadena.Length);
                int maximo = 0; int anterior = int.MinValue; bool nuevaSecuencia = true;
                List<int> visual = new List<int>();
                for(int indice = 0; indice < indices.Count - 1; indice++)
                {
                    maximo = int.Parse(cadena.Substring(indices[indice], indices[indice + 1] - indices[indice]));

                    if(anterior > maximo) { nuevaSecuencia = false; break; }
                    visual.Add(maximo);
                    anterior = maximo;
                }
                if (nuevaSecuencia)
                {
                    Console.WriteLine();
                    PrintLista(visual);
                    numero++;
                }
                    
            }
            else if (posicionArray == array.Length)
                return;
            else
            {
                combinacion[posicionCombinacion] = array[posicionArray];

                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion + 1, cadena, ref numero);
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion, cadena, ref numero);
            }
        }
        public static void PrintLista(List<int> myLista)
        {
            foreach(var el in myLista)
                Console.Write(el+",");
        }
    }
}
