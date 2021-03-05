using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiritasDeCuero
{
    class Program
    {
        static void Main(string[] args)
        {

            bool[,] patron = new bool[,]
{
    {false, false,  true, false, false, },
    {false,  true,  true, false, false, },
    {false, false, true, false, false, },
    {false, false, false, false, true, },
    {false, false, false, false, false, },
};

            Console.WriteLine(Minimo(patron));
        }
        static int Minimo(bool[,] tablero)
        {
            int minimo = int.MaxValue;

            Minimo(tablero, new bool[tablero.GetLength(0), tablero.GetLength(1)], 0, 0, 0, ref minimo);

            return minimo;
        }
        static void Minimo(bool[,] tableroOriginal, bool[,] tableroActual, int myFila, int myColumna, int llamado, ref int mejor)
        {
            if(Compara(tableroOriginal, tableroActual))
            {
                if (llamado < mejor)
                    mejor = llamado;
                return;
            }

            for (int primerIndice = myFila; primerIndice < tableroOriginal.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = myColumna; segundoIndice < tableroOriginal.GetLength(1); segundoIndice++)
                {
                    if(tableroOriginal[primerIndice, segundoIndice])
                    {
                        Minimo(tableroOriginal, PonHorizontal(tableroOriginal, tableroActual, primerIndice, segundoIndice), primerIndice, segundoIndice + 1, llamado + 1, ref mejor);

                        Minimo(tableroOriginal, PonVertical(tableroOriginal, tableroActual, primerIndice, segundoIndice), primerIndice, segundoIndice + 1, llamado + 1, ref mejor);
                    }
                }
                myColumna = 0;
            }
        }
        static bool Compara(bool[,] original, bool[,] actual)
        {
            for (int primerIndice = 0; primerIndice < original.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < original.GetLength(1); segundoIndice++)
                {
                    if (original[primerIndice, segundoIndice] != actual[primerIndice, segundoIndice])
                        return false;
                }
            }
            return true;
        }
        static bool[,] PonHorizontal(bool[,] original, bool[,] actual, int fila, int columna)
        {
            bool[,] copia = HazCopia(actual);

            for (int indice = columna; indice < original.GetLength(0) && original[fila, indice]; indice++)
            {
                copia[fila, indice] = true;
            }
            return copia;
        }
        static bool[,] PonVertical(bool[,] original, bool[,] actual, int fila, int columna)
        {
            bool[,] copia = HazCopia(actual);

            for(int indice = fila; indice < original.GetLength(1) && original[indice, columna]; indice++)
            {
                copia[indice, columna] = true;
            }
            return copia;
        }
        static bool[,] HazCopia(bool[,] tablero)
        {
            bool[,] copia = new bool[tablero.GetLength(0), tablero.GetLength(1)];

            for(int primerIndice = 0; primerIndice<tablero.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice< tablero.GetLength(1); segundoIndice++)
                {
                    if (tablero[primerIndice, segundoIndice])
                        copia[primerIndice, segundoIndice] = true;
                }
            }
            return copia;
        }
    }
}
