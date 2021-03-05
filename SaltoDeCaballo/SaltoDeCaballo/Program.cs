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
        static void IO()
        {
            string[] datos = Console.ReadLine().Split();

            int[] myDatos = new int[datos.Length];

            for (int indice = 0; indice < myDatos.Length; indice++)
            {
                myDatos[indice] = int.Parse(datos[indice]);
            }

            int[,] tablero = new int[myDatos[0], myDatos[0]];
            
            for (int indice = 0; indice < tablero.GetLength(0); indice++)
            {
                for (int element = 0; element < tablero.GetLength(1); element++)
                    tablero[indice, element] = -1;
            }

            if(!Moverse(tablero, myDatos[1], myDatos[2]))
            {
                Console.WriteLine("NO ES POSIBLE");
                return;
            }


            for (int indice = 0; indice < tablero.GetLength(0); indice++)
            {
                for (int element = 0; element < tablero.GetLength(1); element++)
                    Console.Write(tablero[indice, element] + " ");
                Console.WriteLine();
            }
        }
        static bool Moverse(int[,] myTablero, int myFila, int myColumna)
        {
            int[] filaMov = { 2, 1, -1, -2, -2, -1, 1, 2};
            int[] columnaMov = {1, 2, 2, 1, -1, -2, -2, -1};

            myTablero[myFila, myColumna] = 0;
            return Moverse(myFila, myColumna, filaMov, columnaMov, 1, myTablero);
        }
        static bool Moverse(int fila, int columna, int[] arrayFila, int[] arrayColumna, int contador, int[,] tableroEntero)
        {
            if(contador == tableroEntero.GetLength(0) * tableroEntero.GetLength(1))
                return true;

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValida(tableroEntero.GetLength(0), tableroEntero.GetLength(1), nuevaFila, nuevaColumna) && tableroEntero[nuevaFila, nuevaColumna] == -1)
                {
                    tableroEntero[nuevaFila, nuevaColumna] = contador;
                    if(Moverse(nuevaFila, nuevaColumna, arrayFila, arrayColumna, contador + 1, tableroEntero))
                        return true;
                    tableroEntero[nuevaFila, nuevaColumna] = -1;
                }
            }
            return false;
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
