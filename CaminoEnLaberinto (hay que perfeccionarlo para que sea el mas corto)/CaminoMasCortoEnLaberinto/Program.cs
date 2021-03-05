using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoMasCortoEnLaberinto
{
    class Program
    {
        public enum Celda { libre, paso, obstaculo, camino };
        static void Main(string[] args)
        {
            Celda[,] lab1 = { 
          /*0*/ {Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre},
          /*1*/ {Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*2*/ {Celda.libre, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*3*/ {Celda.libre, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*4*/ {Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.libre},
          /*5*/ {Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*6*/ {Celda.libre, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.libre},
          /*7*/ {Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*8*/ {Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*9*/ {Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo},
          /*10*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre},
          /*11*/{Celda.libre, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo,  Celda.obstaculo},
          /*12*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*13*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*14*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.libre},
          /*15*/{Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*16*/{Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.obstaculo, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre}};
         
            int[,] laberinto = new int[lab1.GetLength(0), lab1.GetLength(1)];

            for(int primerIndice = 0; primerIndice < lab1.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice <  lab1.GetLength(1); segundoIndice++)
                {
                    if (lab1[primerIndice, segundoIndice] == Celda.libre)
                        laberinto[primerIndice, segundoIndice] = 0;
                    else if(lab1[primerIndice, segundoIndice] == Celda.obstaculo)
                        laberinto[primerIndice, segundoIndice] = - 1;
                }
            }
            Moverse(laberinto, 0, 0);
            
            PrintMatrix(laberinto);
            Console.WriteLine();
            
            CaminoCorto(laberinto, 0, 0, 16, 16);

            PrintMatrix(laberinto);
        }
        static void CaminoCorto(int[,] laberinto, int myFila, int myColumna, int destinoFila, int destinoColumna)
        {
            int[] movFila = { -1, 0, 1, 0 };
            int[] movColumna = { 0, 1, 0, -1 };

            CaminoCorto(laberinto, myFila, myColumna, destinoFila, destinoColumna, movFila, movColumna);
        }
        static bool CaminoCorto(int[,] tablero, int fila, int columna, int filaDestino, int columnaDestino, int[] arrayFila, int[] arrayColumna)
        {
            if (fila == filaDestino && columna == columnaDestino)
                return true;

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValido(tablero, nuevaFila, nuevaColumna) && tablero[nuevaFila, nuevaColumna] - tablero[fila, columna] == 1)
                {
                    if (CaminoCorto(tablero, nuevaFila, nuevaColumna, filaDestino, columnaDestino, arrayFila, arrayColumna))
                        return true;
                    tablero[nuevaFila, nuevaColumna] = 0;
                }
            }
            return false;
        }
        static void Moverse(int[,] myLaberinto, int myFila, int myColumna)
        {
            int[] movFila = { -1, 0, 1, 0 };
            int[] movColumna = { 0, 1, 0, -1 };

            Moverse(myLaberinto, myFila, myColumna, 1, movFila, movColumna);
        }
        static void Moverse(int[,] tablero, int fila, int columna, int numero, int[]arrayFila, int[] arrayColumna)
        {
            tablero[fila, columna] = numero;

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if (EsValido(tablero, nuevaFila, nuevaColumna) && (tablero[nuevaFila, nuevaColumna] == 0 || tablero[nuevaFila, nuevaColumna] > numero + 1))
                    Moverse(tablero, nuevaFila, nuevaColumna, numero + 1, arrayFila, arrayColumna);
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
