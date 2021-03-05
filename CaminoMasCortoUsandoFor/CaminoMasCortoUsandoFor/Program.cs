using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoMasCortoUsandoFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] myMatrix = new int[4, 4];

            int[] moverseFila = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] moverseColumna = { 0, 0, -1, 1, -1, 1, 1, -1 };

            Moverse(myMatrix, 2, 1, 1, moverseFila, moverseColumna);
            PrintMatrix(myMatrix);
        }
        static void Moverse(int[,] tablero, int fila, int columna, int numero, int[] arrayFila, int[] arrayColumna)
        {
            tablero[fila, columna] = numero;

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValido(tablero, nuevaFila, nuevaColumna) && (tablero[nuevaFila, nuevaColumna] == 0 || tablero[nuevaFila, nuevaColumna] > numero + 1))
                {
                    Moverse(tablero, nuevaFila, nuevaColumna, numero + 1, arrayFila, arrayColumna);
                }
            }
        }
        static bool EsValido(int[,] tablero, int fila, int columna)
        {
            if (fila >= tablero.GetLength(0))
                return false;
            if (fila < 0)
                return false;
            if (columna >= tablero.GetLength(1))
                return false;
            if (columna < 0)
                return false;
            return true;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    Console.Write(matrix[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }
    }
}
