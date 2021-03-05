using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminosEnergia_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrizEnunciado = new int[,]
         {
                { 4, 4, -5, 9},
                {3, 0, 15, 1},
                {7, -1, 8, 10},
                {4, 1, 0, 14}
         };

            Console.WriteLine(Camino(matrizEnunciado, 0, 0, 3, 2, 7));
        }
        public static bool Camino(int[,] matriz, int filaInicial, int columnaInicial, int filaDestino, int columnaDestino, int energia)
        {
            int[] movFila = { -1, 0, 1, 0 };
            int[] movColumna = { 0, 1, 0, -1 };
            List<int[]> mov = new List<int[]>();
            return Moverse(filaInicial, columnaInicial, filaDestino, columnaDestino, 0, energia, movFila, movColumna, matriz, mov, new bool[matriz.GetLength(0), matriz.GetLength(1)]);
        }
        public static bool EsValido(int fila, int columna, int[,] matriz)
        {
            return fila >= 0 && columna >= 0 && fila < matriz.GetLength(0) && columna < matriz.GetLength(1);
        }
        public static bool Moverse(int fila, int columna, int filaDestino, int columnaDestino, int energiaActual, int energiaBuscada, int[] arrayFila, int[] arrayColumna, int[,] matrix, List<int[]> movimiento, bool[,] marcado)
        {
            if(fila == filaDestino && columna == columnaDestino && energiaActual <= energiaBuscada)
            {
                PrintCaminos(movimiento);
                Console.WriteLine(energiaActual);
                return true;
            }
            for(int indice = 0; indice<arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];
                int nuevaEnergiaActual = 0;
                if(EsValido(nuevaFila, nuevaColumna, matrix) && !marcado[nuevaFila, nuevaColumna])
                {
                    if (matrix[nuevaFila, nuevaColumna] <= matrix[fila, columna])
                        nuevaEnergiaActual = energiaActual+1;
                    else
                    {
                        nuevaEnergiaActual = energiaActual + 1 + (matrix[nuevaFila, nuevaColumna] - matrix[fila, columna]);
                    }
                    if (nuevaEnergiaActual <= energiaBuscada)
                    {
                        int[] temp = { nuevaFila, nuevaColumna };
                        List<int[]> copia = CopiaCaminos(movimiento);
                        copia.Add(temp);
                        marcado[nuevaFila, nuevaColumna] = true;
                        if (Moverse(nuevaFila, nuevaColumna, filaDestino, columnaDestino, nuevaEnergiaActual, energiaBuscada, arrayFila, arrayColumna, matrix, copia, marcado))
                            return true;
                        marcado[nuevaFila, nuevaColumna] = false;
                    }
                }
            }
            return false;
        }
        public static List<int[]> CopiaCaminos(List<int[]> caminos)
        {
            List<int[]> copia = new List<int[]>();
            foreach(var el in caminos)
            {
                int[] temp = new int[el.Length];
                for(int indice = 0; indice < el.Length; indice++)
                {
                    temp[indice] = el[indice];
                }
                copia.Add(temp);
            }
            return copia;
        }
        public static void PrintCaminos(List<int[]> caminos)
        {
            foreach(var el in caminos)
            {
                foreach(var cam in el)
                {
                    Console.Write(cam);
                }
                Console.WriteLine();
            }
        }
    }
   
}
