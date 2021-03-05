using System;

namespace CasillaAmenazada
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] Tablero = new bool[4, 4];
            Tablero[0, 0] = true;

            Console.WriteLine(EstaAmenazada(Tablero, 3, 0));

        }
        static bool EstaAmenazada(bool [, ] Tablero, int fila, int columna)
        {   // Este, Oeste, Norte, Sur, NorEste, NorOeste, SurOeste, SurEste
            int[] movFila =    { 0, 0, -1, 1, -1, -1, 1, 1 };
            int[] movColumna = { -1, 1, 0, 0, -1, 1, 1, -1 };
            
            int nuevaFila = 0;
            int nuevaColumna = 0;

            for(int index = 0; movFila.Length > index; index++)
            {
                nuevaFila = fila + movFila[index];
                nuevaColumna = columna + movColumna[index];

                while(IsValid(Tablero, nuevaFila, nuevaColumna))
                {
                    if (Tablero[nuevaFila, nuevaColumna])
                        return true;
                    else
                    {
                        nuevaFila += movFila[index];
                        nuevaColumna += movColumna[index];
                    }
                }
            }
            return false;
        }
        static bool IsValid(bool [, ] Tablero, int fila, int columna)
        {
            if ((0 <= fila) && (fila < Tablero.GetLength(0)) && (0 <= columna) && (columna < Tablero.GetLength(1)))
                return true;
            return false;
        }
    }
}
