﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amplificacion
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            Console.ReadLine();
            string[] cadenas = Console.ReadLine().Split();

            int[] array = new int[cadenas.Length];

            for (int indice = 0; indice < array.Length; indice++)
            {
                array[indice] = int.Parse(cadenas[indice]);
            }

            Console.WriteLine(Nivelando(array));
        }
        static int Nivelando(int[] myArray)
        {
            int myMaximo = myArray.Max();
            int veces = 0;

            while (myArray.Min() < myArray.Max())
            {
                bool nivelo = false;
                Nivela(myArray, myMaximo, ref nivelo);
                veces++;
            }
            return veces;
        }
        static void Nivela(int[] array, int maximo, ref bool seNivelo)
        {
            int indiceMin = array.ToList().IndexOf(array.Min());
            int myContador = 0;
            int longitud = Longitud(array, maximo, indiceMin);
            int temp = array[indiceMin];

            for (int indice = indiceMin; myContador < longitud; indice++)
            {
                if (array[indice] == temp && array[indice] < maximo)
                {
                    array[indice] += 1;
                    seNivelo = true;
                }
                myContador++;
            }

        }
        static int Longitud(int[] myArray, int myMaximo, int posicion)
        {
            int contador = 0;

            for (int indice = posicion; indice < myArray.Length; indice++)
            {
                if (myArray[indice] < myMaximo && myArray[indice] == myArray[posicion])
                    contador++;
                else
                    break;
            }
            return contador;
        }
    }
}

