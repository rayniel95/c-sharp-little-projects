using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoSeguroDelRey
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] tabla = new int[8, 8];

            tabla[0, 3] = -1;
            tabla[1, 0] = -1;
            tabla[3, 0] = -1;
            tabla[2, 2] = -1;
            tabla[3, 2] = -1;
            tabla[4, 2] = -1;
            tabla[5, 2] = -1;
            tabla[6, 2] = -1;

            Console.WriteLine(Moverse(tabla));

            PrintMatrix(tabla);
            
        }
        static int Moverse(int[,] myTablero)
        {
            int[] movFila = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] movColumna = { 0, 1, 1, 1, 0, -1, -1, -1 };

            Moverse(myTablero, 7, 0, movFila, movColumna, 1);

            return myTablero[0, 7];
        }
        static void Moverse(int[,] tablero,  int fila, int columna, int[] arrayFila, int[] arrayColumna, int numero)
        {
            tablero[fila, columna] = numero;

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValido(tablero, nuevaFila, nuevaColumna) && (tablero[nuevaFila, nuevaColumna] == 0 || tablero[nuevaFila, nuevaColumna] > numero + 1 || (tablero[nuevaFila, nuevaColumna] == -1 && !EstaAmenazada(tablero, nuevaFila, nuevaColumna))) && !EstaAmenazada(tablero, nuevaFila, nuevaColumna))
                {
                    // en que se diferencia que declare la variable principio del metodo a que la declare aca?
                    bool vomita = false;

                    if (tablero[nuevaFila, nuevaColumna] == -1)
                    {
                        PrintMatrix(tablero);
                        Console.WriteLine();
                        vomita = true;
                    }
                    Moverse(tablero, nuevaFila, nuevaColumna, arrayFila, arrayColumna, numero + 1);

                    if (vomita)
                        tablero[nuevaFila, nuevaColumna] = -1;
                }
            }

        }
        static bool EstaAmenazada(int[,] tabla, int fila, int columna)
        {
            int[] movFila = { -1, 1, 1, -1 };
            int[] movColumna = { 1, 1, -1, -1 };

            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if (EsValido(tabla, nuevaFila, nuevaColumna) && tabla[nuevaFila, nuevaColumna] == -1)
                    return true;
            }
            return false;
        }
        static bool  EsValido(int[,] tabla, int fila, int columna)
        {
            return fila >= 0 && columna >= 0 && fila < tabla.GetLength(0) && columna < tabla.GetLength(1);
        }
        static void PrintMatrix(int[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    Console.Write(matrix[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }
    }
}
