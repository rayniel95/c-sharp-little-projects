using System;

namespace Interseccion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] primerArray = { 1, 4, 5, 3, 8 };
            int[] segundoArray = { 1, 5, 6, 8, 9 };

            Console.WriteLine(EqualsElements(primerArray, segundoArray));

            for(int indice = 0; EqualsElements(primerArray, segundoArray) > indice; indice++)
            {
                Console.WriteLine(Inter(primerArray, segundoArray)[indice]);
            }
            
        }
        static int [] Inter(int [] primerArray, int[] segundoArray)
        {
            int[] inter = new int[EqualsElements(primerArray, segundoArray)];
            int [] minimo = new int[0];
            int[] maximo = new int[0];
            int contador = 0;

            if(Math.Min(primerArray.Length, segundoArray.Length) == primerArray.Length)
            {
                minimo = primerArray;
                maximo = segundoArray;
            }
            else
            {
                minimo = segundoArray;
                maximo = primerArray;
            }

            for (int indice = 0; minimo.Length > indice; indice++)
            {
                for (int indiceDos = 0; maximo.Length > indiceDos; indiceDos++)
                {
                    if (minimo[indice] == maximo[indiceDos])
                    {
                        inter[contador] = minimo[indice];
                        contador++;
                    }
                }
            }
            return inter;
        }
        static int EqualsElements(int[] primerArray, int[] segundoArray)
        {
            int[] minimo = new int[0];
            int[] maximo = new int[0];

            if (Math.Min(primerArray.Length, segundoArray.Length) == primerArray.Length)
            {
                minimo = primerArray;
                maximo = segundoArray;
            }
            else
            {
                minimo = segundoArray;
                maximo = primerArray;
            }

            int contador = 0;

            for(int index = 0; minimo.Length > index; index++)
            {
                for (int indiceDos = 0; maximo.Length > indiceDos; indiceDos++)
                {
                    if (minimo[index] == maximo[indiceDos])
                        contador++;
                }
            }
            return contador;
        }
    }
}
