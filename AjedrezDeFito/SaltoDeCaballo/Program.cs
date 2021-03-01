using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltoDeCaballo
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        //esto da overflow
        static void IO()
        {
            int cantidadPruebas = int.Parse(Console.ReadLine());
            int[,] destinos = new int[cantidadPruebas, 2];

            for (int veces = 0; veces < cantidadPruebas; veces++)
            {
                string[] casos = Console.ReadLine().Split();

                destinos[veces, 0] = int.Parse(casos[0]);
                destinos[veces, 1] = int.Parse(casos[1]);
            }

            int[] cantidad = new int[cantidadPruebas];

            for (int indice = 0; indice < destinos.GetLength(0); indice++)
            {
                int[,] tablero = new int[destinos[indice, 0] + 50, destinos[indice, 1] + 50];
                Moverse(tablero, 0, 0);
                cantidad[indice] = tablero[destinos[indice, 0], destinos[indice, 1]];
            }

            for (int indice = 0; indice < cantidad.Length; indice++)
            {
                Console.WriteLine(cantidad[indice]);
            }
        }
        static void Moverse(int[,] myTablero, int myFila, int myColumna)
        {
            int[] filaMov = { 2, 1, -1, -2, -2, -1, 1, 2};
            int[] columnaMov = {1, 2, 2, 1, -1, -2, -2, -1};

            Moverse(myFila, myColumna, filaMov, columnaMov, 0, myTablero);
        }
        static void Moverse(int fila, int columna, int[] arrayFila, int[] arrayColumna, int contador, int[,] tableroEntero)
        {
            tableroEntero[fila, columna] = contador;

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValida(tableroEntero.GetLength(0), tableroEntero.GetLength(1), nuevaFila, nuevaColumna) && (tableroEntero[nuevaFila, nuevaColumna] == 0 || (tableroEntero[nuevaFila, nuevaColumna] > contador + 1)))
                {
                    Moverse(nuevaFila, nuevaColumna, arrayFila, arrayColumna, contador + 1, tableroEntero);
                }
            }
        }
        static bool EsValida(int filaDimension, int columnaDimension, int fila, int columna)
        {
            if (columna >= columnaDimension)
                return false;
            if (columna < 0)
                return false;
            if (fila >= filaDimension)
                return false;
            if (fila < 0)
                return false;
            return true;
        }
    }
}
