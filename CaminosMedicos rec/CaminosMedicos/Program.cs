using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programacion.Examen.RecorridoMedico
{
    public class Examen
    {
        static void Main(string[] args)
        {

            int[,] Area = { 
                            {0, 2, 0},
                            {0, 2, 2},
                            {2, 0, 1}
                           };

            Console.WriteLine(CantidadMinimaDeMedicos(Area, 2));
        }
        public static int CantidadMinimaDeMedicos(int[,] area, int radio)
        {
            return MinimoMedicos(area, radio);

        }
        static int MinimoMedicos(int[,] matriz, int radio)
        {
            bool seEncontro = false;
            int[] numeros = ModificaTablero(ref matriz);

            if (numeros[1] == 0)
                return 0;

            int myMinimo = -1;

            int[] arrayMedicos = new int[numeros[0]];

            for (int indice = 0; indice < arrayMedicos.Length; indice++)
            {
                arrayMedicos[indice] = indice + 1;
            }

            for (int indice = 1; indice <= Math.Pow(2, numeros[0]); indice++)
            {
                Combinaciones(arrayMedicos, new int[indice], 0, 0, matriz, radio, numeros[1], ref myMinimo, ref seEncontro);
            }

            return myMinimo;
        }
        static int[] ModificaTablero(ref int[,] tabla)
        {
            int numeroPacientes = 0;
            int numeroMedicos = 0;

            int[] numeros = new int[2];

            for (int primerIndice = 0; primerIndice < tabla.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < tabla.GetLength(1); segundoIndice++)
                {
                    if (tabla[primerIndice, segundoIndice] == 2)
                    {
                        tabla[primerIndice, segundoIndice] = -1 - numeroPacientes;
                        numeroPacientes++;
                    }
                    else if (tabla[primerIndice, segundoIndice] == 1)
                    {
                        tabla[primerIndice, segundoIndice] += numeroMedicos;
                        numeroMedicos++;
                    }
                }
            }

            numeros[0] = numeroMedicos;
            numeros[1] = numeroPacientes;

            return numeros;
        }
        static void Combinaciones(int[] array, int[] combinacion, int posicionArray, int posicionCombinacion, int[,] myMatriz, int myRadio, int numeroPacientes, ref int minimo, ref bool encontrado)
        {
            if (posicionCombinacion == combinacion.Length)
            {
                List<int> visitados = new List<int>();

                for (int indice = 0; indice < combinacion.Length; indice++)
                {
                    for (int primerIndice = 0; primerIndice < myMatriz.GetLength(0); primerIndice++)
                    {
                        for (int segundoIndice = 0; segundoIndice < myMatriz.GetLength(1); segundoIndice++)
                        {
                            if (myMatriz[primerIndice, segundoIndice] == combinacion[indice])
                            {
                                visitados = visitados.Union(PuedeVisistar(primerIndice, segundoIndice, myRadio, myMatriz)).ToList();
                            }
                        }
                    }
                }
                if (visitados.Count == numeroPacientes && !encontrado)
                {
                    minimo = combinacion.Length;
                    encontrado = true;
                }
            }
            else if (posicionArray == array.Length)
                return;
            else
            {
                combinacion[posicionCombinacion] = array[posicionArray];

                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion + 1, myMatriz, myRadio, numeroPacientes, ref minimo, ref encontrado);
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion, myMatriz, myRadio, numeroPacientes, ref minimo, ref encontrado);
            }
        }
        static List<int> PuedeVisistar(int fila, int columna, int radio, int[,] matriz)
        {
            int inicioFila = fila - radio;
            int inicioColumna = columna - radio;

            int terminaFila = fila + radio;
            int terminaColumna = columna + radio;

            List<int> lista = new List<int>();

            for (int primerIndice = inicioFila; primerIndice <= terminaFila; primerIndice++)
            {
                for (int segundoIndice = inicioColumna; segundoIndice <= terminaColumna; segundoIndice++)
                {
                    if (EsValido(matriz, primerIndice, segundoIndice) && matriz[primerIndice, segundoIndice] < 0)
                    {
                        lista.Add(matriz[primerIndice, segundoIndice]);
                    }
                }
            }
            return lista;
        }
        static bool EsValido(int[,] matrix, int fila, int columna)
        {
            return fila >= 0 && columna >= 0 && fila < matrix.GetLength(0) && columna < matrix.GetLength(1);
        }
        static void PrintArray(int[] myArray)
        {
            foreach (int element in myArray)
                Console.Write(element);
            Console.WriteLine();
        }
    }
}

