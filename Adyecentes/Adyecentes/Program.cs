using System;

namespace Adyecentes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] array = { {true,true, false, false, false, true }, 
                              {false, true, false, true, true, true},
                              {true, false, true,true, false, false},
                              {true, false, false, false,true, true}, 
                              {true, false, false, false, true, false}, 
                              {true, true, true,false,false, false}};
            

            Console.WriteLine(HayKAdyacentes(array, 5));
        }
        static bool IsValid(bool [, ] Tablero, int  fila, int columna)
        {
            if((0 <= fila) && (fila < Tablero.GetLength(0)) && (0 <= columna) && (columna < Tablero.GetLength(1)))
                return true;
            return false;
        }
        static bool HayKAdyacentes(bool [, ] Tablero, int number)
        {   // Este, Oeste, Norte, Sur, NorEste, NorOeste, SurEste, SurOeste
            int[] movFila = { 0, 0, -1, 1, -1, -1, 1, 1 };
            int[] movColumna = { -1, 1, 0, 0, -1, 1, -1, 1 };

            int counter = 0;

            int nuevaFila = 0;
            int nuevaColumna = 0;

            for (int firstIndex = 0; Tablero.GetLength(0) > firstIndex; firstIndex++)
            {
                for (int secondIndex = 0; Tablero.GetLength(1) > secondIndex; secondIndex++)
                {
                    for (int index = 0; movFila.GetLength(0) > index; index++)
                    {
                        nuevaFila = firstIndex;
                        nuevaColumna = secondIndex;
                        counter = 0;

                        while(IsValid(Tablero, nuevaFila, nuevaColumna) && (counter < (number + 1)))
                        {
                            if (Tablero[nuevaFila, nuevaColumna] == Tablero[firstIndex, secondIndex])
                            {
                                nuevaFila += movFila[index];
                                nuevaColumna += movColumna[index];
                                counter++;

                                if (counter == number)
                                    return true;
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
