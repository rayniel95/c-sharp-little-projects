using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colores
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            string dimension = Console.ReadLine();

            int filas = int.Parse(dimension.Split()[0]);

            int columnas = int.Parse(dimension.Split()[1]);

            int[,] array = new int[filas, columnas];

            int columna = 0;

            for (int veces = 0; veces < filas; veces++)
            {
                string fila = Console.ReadLine();

                for (int caracter = 0; caracter < fila.Length; caracter++)
                {
                    if (fila[caracter].ToString() != " ")
                    {
                        array[veces, columna] = int.Parse(fila[caracter].ToString());
                        columna++;
                    }
                }
                columna = 0;
            }
            Console.WriteLine(CantidadMinima(array));
        }
        static int CantidadMinima(int[,] tablero)
        {
            int[] filaMov = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] columnaMov = {0, 1, 1, 1, 0, -1, -1, -1};

            int maximo = 0;

            for (int primerIndice = 0; primerIndice < tablero.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < tablero.GetLength(1); segundoIndice++)
                {
                    if (tablero[primerIndice, segundoIndice] > maximo)
                        maximo = tablero[primerIndice, segundoIndice];
                }
            }

            int[] numeros = new int[maximo];

            for (int indice = 0; indice < numeros.Length; indice++)
            {
                numeros[indice] = indice + 1;
            }
            int comparten = 0;

            Combinaciones(numeros, new int[2], 0, 0, tablero, filaMov, columnaMov, ref comparten);

            return maximo - comparten;
        }
        static void Combinaciones(int[] array, int[] combinacion, int posicionArray, int posicionCombinacion, int[,] barrios, int[] movFila, int[] movColumna, ref int contador)
        {
            if (posicionCombinacion == combinacion.Length)
            {
                if(!Comparten(barrios, combinacion[0], combinacion[1], movFila, movColumna))
                {
                    contador++;
                }

            }
            else if (posicionArray == array.Length)
            {
                return;
            }
            else
            {
                combinacion[posicionCombinacion] = array[posicionArray];
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion + 1, barrios, movFila, movColumna, ref contador);
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion, barrios, movFila, movColumna, ref contador);
            }
        }
        static bool Comparten(int[,] tablero, int primerNumero, int segundoNumero, int[] arrayFila, int[] arrayColumna)
        {
            for (int primerIndice = 0; primerIndice < tablero.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < tablero.GetLength(1); segundoIndice++)
                {
                    if (tablero[primerIndice, segundoIndice] == primerNumero || tablero[primerIndice, segundoIndice] == segundoNumero)
                    {
                        for (int indice = 0; indice < arrayFila.Length; indice++)
                        {
                            int nuevaFila = primerIndice + arrayFila[indice];
                            int nuevaColumna = segundoIndice + arrayColumna[indice];

                            if (EsValido(tablero, nuevaFila, nuevaColumna) && ((tablero[primerIndice, segundoIndice] == primerNumero && tablero[nuevaFila, nuevaColumna] == segundoNumero) || (tablero[primerIndice, segundoIndice] == segundoNumero && tablero[nuevaFila, nuevaColumna] == primerNumero)))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        static bool EsValido(int[,] tabla, int fila, int columna)
        {
            return fila >= 0 && columna >= 0 && fila < tabla.GetLength(0) && columna < tabla.GetLength(1);
        }
    }
}
