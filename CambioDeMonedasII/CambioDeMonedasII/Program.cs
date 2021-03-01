using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();

        }
        static void IO()
        {
            int dimension = int.Parse(Console.ReadLine());

            double[,] array = new double[dimension, dimension];

            for (int veces = 0; veces < dimension; veces++)
            {
                string[] fila = Console.ReadLine().Split();

                for (int columna = 0; columna < dimension; columna++)
                {
                    array[veces, columna] = double.Parse(fila[columna].Replace(".", ","));
                }
            }

            if(!VariacionesSinRepeticion(array))
                Console.WriteLine("NO HAY GANANCIA");

        }
        static double DarCambio(double[,] tabla, int[] combinacion, int monedaBase)
        {
            if (combinacion[0] == monedaBase)
                return 1;

            double dinero = tabla[monedaBase, combinacion[0]];

            for(int indice = 0; indice < combinacion.Length; indice++)
            {
                dinero *= tabla[combinacion[indice], combinacion[indice + 1]];

                if (combinacion[indice + 1] == monedaBase)
                    break;
            }
            return dinero;
        }
        static bool VariacionesSinRepeticion(double[,] tabla)
        {
            int[] monedas = new int[tabla.GetLength(0)];

            for(int indice = 0; indice < monedas.Length; indice++)
            {
                monedas[indice] = indice;
            }

            bool seEncontro = false;
            int[] temp = new int[0];

             return VariacionesSinRepeticion(monedas, 0, monedas.Length, ref seEncontro, ref temp, tabla);

        }
        static void PrintSet(int[] ElArray)
        {

            for (int indice = 0; indice < ElArray.Length; indice++)
            {
                if (indice > 0 && ElArray[indice] == ElArray[0])
                {
                    Console.Write(ElArray[indice]);
                    break;
                }
                Console.Write(ElArray[indice] + " ");
            }
            Console.WriteLine();
        }
        static bool VariacionesSinRepeticion(int[] array, int posicion, int numeroACombinar, ref bool gananciaEncontrada, ref int[] combinacion, double[,] tablaCambiar)
        {
            if (posicion == numeroACombinar)
            {
               for(int indice = 0; indice <= 3; indice++)
               {
                   if(DarCambio(tablaCambiar, array, indice) > 1)
                   {
                       int[] combinada = new int[array.Length + 1];
                       combinada[0] = indice;
                       Array.Copy(array, 0, combinada, 1, array.Length);
                       gananciaEncontrada = true;
                       combinacion = array;
                       PrintSet(combinada);
                       return true;
                   }
               }
            }
            else
            {
                for (int indice = posicion; indice < array.Length; indice++)
                {
                    int temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;

                    if(VariacionesSinRepeticion(array, posicion + 1, numeroACombinar, ref gananciaEncontrada, ref combinacion, tablaCambiar))
                        return true;
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
            return false;
        }
    }
}
