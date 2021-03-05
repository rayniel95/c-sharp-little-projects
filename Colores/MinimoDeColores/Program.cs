using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimoDeColores
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();            
        }
        static int MaximoDeColores(int[,] tablero)
        {
            int maximo = 0;

            foreach (int numero in tablero)
            {
                maximo = Math.Max(maximo, numero);
            }
            return maximo;
        }
  
        static void Moverse(int[,] tablero, bool [,] tabBool, int fila, int columna, List<int> comparten, int numero)
        {
           
            if(columna + 1 < tablero.GetLength(1))
            {
                if(tablero[fila, columna + 1] == numero && !tabBool[fila, columna + 1])
                {
                    tabBool[fila, columna] = true;
                 
                    Moverse(tablero, tabBool, fila, columna + 1, comparten, numero);
                }
                else if(tablero[fila, columna + 1] != numero)
                {
                    comparten.Add(tablero[fila, columna + 1]);
                }
            }
            if(columna - 1 >= 0 )
            {
                if (tablero[fila, columna - 1] == numero && !tabBool[fila, columna - 1])
                {
                    tabBool[fila, columna] = true;
                 
                    Moverse(tablero, tabBool, fila, columna - 1, comparten, numero);
                }
                else if (tablero[fila, columna - 1] != numero)
                {
                    comparten.Add(tablero[fila, columna - 1]);
                }
            }
            if(fila + 1 < tablero.GetLength(0))
            {
                if (tablero[fila + 1, columna] == numero && !tabBool[fila + 1, columna])
                {
                    tabBool[fila, columna] = true;
               
                    Moverse(tablero, tabBool, fila + 1, columna, comparten, numero);
                }
                else if (tablero[fila + 1, columna] != numero)
                {
                    comparten.Add(tablero[fila + 1, columna]);
                }
            }
            if(fila - 1 >= 0)
            {
                if (tablero[fila - 1, columna] == numero && !tabBool[fila - 1, columna])
                {
                    tabBool[fila, columna] = true;
                 
                    Moverse(tablero, tabBool, fila - 1, columna, comparten, numero);
                }
                else if (tablero[fila - 1, columna] != numero)
                {
                    comparten.Add(tablero[fila - 1, columna]);
                }
            }
        }
        static void IO()
        {
            string dimension = Console.ReadLine();

            int filas = int.Parse(dimension.Split()[0]);

            int columnas = int.Parse(dimension.Split()[1]);

            int[,] array = new int[filas, columnas];

            int columna = 0;

            for (int veces = 0; veces < filas; veces++)
            {
                string fila = Console.ReadLine();

                for(int caracter = 0; caracter < fila.Length; caracter++)
                {
                    if(fila[caracter].ToString() != " ")
                    {
                        array[veces, columna] = int.Parse(fila[caracter].ToString());
                        columna++;
                    }
                }
                columna = 0;
            }
            Console.WriteLine(Colores(array));
        }
    }
}
