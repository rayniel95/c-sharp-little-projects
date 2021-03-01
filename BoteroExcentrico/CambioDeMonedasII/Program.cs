using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDeMonedasII
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static int Botero(int[,] tabPersonas, int[,] tabTalleres)
        {
            List<int> cantidadDeRecogidas = new List<int>();

            Moverse(tabPersonas, tabTalleres, 0, 0, 0, 5, cantidadDeRecogidas);

            if(cantidadDeRecogidas.Count > 0)
                return cantidadDeRecogidas.Max();

            return 0;
        }
        static void Moverse(int[,] tableroPersonas, int[,] tableroTalleres, int fila, int columna, int personas, int condicionesAuto, List<int> personasRecogidas)
        {
            if (tableroPersonas[fila, columna] > 0)
                personas += tableroPersonas[fila, columna];
            
            if (tableroTalleres[fila, columna] == -1)
                condicionesAuto = 5;
            
            if (fila == (tableroPersonas.GetLength(0) - 1) && columna == (tableroPersonas.GetLength(1) - 1))
                personasRecogidas.Add(personas);

            if(fila + 1 < tableroPersonas.GetLength(0))
            {
                if(condicionesAuto > 0)
                {    
                    Moverse(tableroPersonas, tableroTalleres, fila + 1, columna, personas, condicionesAuto - 1, personasRecogidas);
                }
            }
            if(columna + 1 < tableroPersonas.GetLength(1))
            {
                if (condicionesAuto > 0)
                { 
                    Moverse(tableroPersonas, tableroTalleres, fila, columna + 1, personas, condicionesAuto - 1, personasRecogidas);
                }
            }
        }
        static void IO()
        {
            string dimension = Console.ReadLine();

            int dimensionTablero = int.Parse(dimension.Split()[0]);

            int[,] tableroPersonas = new int[dimensionTablero, dimensionTablero];
            int[,] tableroTalleres = new int[dimensionTablero, dimensionTablero];

            int veces = int.Parse(dimension.Split()[1]) + int.Parse(dimension.Split()[2]);

            for(int indice = 0; indice < veces; indice++)
            {
                string fila = Console.ReadLine();
                string[] filaArray = fila.Split();
                 
                for(int elemento = 0; elemento < filaArray.Length; elemento++)
                {
                    if (filaArray.Length == 3)
                        tableroPersonas[int.Parse(filaArray[0]), int.Parse(filaArray[1])] = int.Parse(filaArray[2]);
                    else
                        tableroTalleres[int.Parse(filaArray[0]), int.Parse(filaArray[1])] = -1;
                }
            }
            Console.WriteLine(Botero(tableroPersonas, tableroTalleres));
        }
    }
}
