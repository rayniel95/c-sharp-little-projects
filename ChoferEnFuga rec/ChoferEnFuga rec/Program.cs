using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoferEnFuga_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumeroCaminos(4, 3, 2));
        }
        public static int NumeroCaminos(int destinoFila, int destinoColumna, int tope)
        {
            int[] filaMov = { 0, 1 };
            int[] columnaMov = { 1, 0 };
            int myNumero = 0;
            Moverse(0, 0, tope, destinoFila, destinoColumna, filaMov, columnaMov, 1, ref myNumero);
            return myNumero;
        }
        public static bool EsValido(int fila, int columna, int dimensionFilas, int dimensionColumnas)
        {
            return fila >= 0 && columna >= 0 && fila <= dimensionFilas && columna <= dimensionColumnas;
        }
        public static void Moverse(int fila, int columna, int K, int filaDestino, int columnaDestino, int[] movFila, int[] movColumna, int KActual, ref int numero)
        {
            if(fila == filaDestino && columna == columnaDestino)
            {
                numero++;
                return;
            }
            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                int nuevaK = 1;

                if(EsValido(nuevaFila, nuevaColumna, filaDestino, columnaDestino))
                {
                    if (nuevaFila == fila)
                        nuevaK = KActual + 1;

                    if(nuevaK <= K)
                    {
                        Moverse(nuevaFila, nuevaColumna, K, filaDestino, columnaDestino, movFila, movColumna, nuevaK, ref numero);
                    }
                }
            }
        }
    }
}
