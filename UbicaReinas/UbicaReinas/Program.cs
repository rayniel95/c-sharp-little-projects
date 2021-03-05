using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicaReinas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UbicaReinas(new bool[8, 8], 8));
        }
        static bool UbicaReinas(bool [,] tablero, int reinas)
        {
            if (reinas == 0)
                return true;

            int columna = tablero.GetLength(0) - reinas;

            for(int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                if(!Amenaza(tablero, fila, columna))
                {
                    tablero[fila, columna] = true;

                    if (UbicaReinas(tablero, reinas - 1))
                        return true;
                    tablero[fila, columna] = false;

                }
            }

            return false;

        }
        static bool Amenaza(bool[,] tablero, int fila, int columna)
        {
            for (int nuevaColumna = 0; nuevaColumna < columna; nuevaColumna++)
            {
                if (tablero[fila, nuevaColumna])
                    return true;
            }

            for (int nuevaFila = fila - 1, nuevaColumna = columna - 1; nuevaFila >= 0 && nuevaColumna >= 0; nuevaColumna--, nuevaFila--)
            {
                if (tablero[nuevaFila, nuevaColumna])
                    return true;
            }

            for (int nuevaFila = fila + 1, nuevaColumna = columna - 1; nuevaColumna >= 0 && nuevaFila < tablero.GetLength(0); nuevaFila++, nuevaColumna--)
            {
                if (tablero[nuevaFila, nuevaColumna])
                    return true;
            }

            return false;
        }
    }
}
