using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantidadDeCaminosPosibles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Moverse(new int[3, 3], 2, 2));
        }
        static int Moverse(int[,] matriz, int destinoFila, int destinoColumna)
        {
            int formas = 0;

            int[] movFila = { 0, 1, 0, -1 };
            int[] movColumna = { 1, 0, -1, 0 };

            Moverse(matriz, 0, 0, destinoFila, destinoColumna, ref formas, movFila, movColumna);

            return formas;
        }
        static void Moverse(int[,] tablero, int fila, int columna, int filaDestino, int columnaDestino, ref int contador, int[] arrayFila, int[] arrayColumna)
        {
            if (fila == filaDestino && columna == columnaDestino)
            {
                contador++;
                return;
            }

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValido(tablero, nuevaFila, nuevaFila))
                {
                    Moverse(tablero, nuevaFila, nuevaFila, filaDestino, columnaDestino, ref contador, arrayFila, arrayColumna);
                }
            }
        }
        static bool EsValido(int[,] tabla, int fila, int columna)
        {
            return columna >= 0 && columna < tabla.GetLength(1) && fila >= 0 && fila < tabla.GetLength(0);
        }
    }
}
