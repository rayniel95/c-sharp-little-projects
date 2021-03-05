using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicaEstaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] distancias = new int[,]{
                                            {0,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,0,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,0,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,0,-1,2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,0,2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {2,2,2,2,2,0,-1,-1,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,2,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,2,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,2,-1,-1,-1,-1,-1,-1,-1,2},
                                            {-1,-1,-1,-1,-1,2,2,2,2,2,2,2,0,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,-1,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,-1,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,-1,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,2},
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,2,-1,2,2,2,2,2,2,2,0}
                                            };
            
            // si el numero de poblaciones no es divisible entre 3 inmediato no tiene solucion
            
            int[] array = new int[21];

            for(int indice = 0; indice < array.GetLength(0); indice++)
            {
                array[indice] = indice;
            }

            VariacionesSinRepeticion(array, 3, distancias);
        }
        static void VariacionesSinRepeticion(int[] myArray, int maximo, int[,] matriz)
        {
            int bueno = 0;

            VariacionesSinRepeticion(myArray, 0, 3, maximo, new int[myArray.Length], matriz, ref bueno);
        }
        static void PrintSet(int[] ElArray)
        {
            for (int indice = 0; indice < ElArray.Length; indice++)
                Console.Write(ElArray[indice]);
            Console.WriteLine();
        }
        static void VariacionesSinRepeticion(int[] array, int posicion, int numeroACombinar, int tope, int[] mejorCombinacion, int[,] matrizDistancia, ref int mejor)
        {
            if (posicion == numeroACombinar)
            {
                int[] poblacionesAlcanzables = new int[array.Length];

                for (int estacion = 0; estacion < 3; estacion++)
                {
                    for(int poblacion = 0; poblacion < array.Length; poblacion++)
                    {
                        if (matrizDistancia[array[poblacion], array[estacion]] != -1 && matrizDistancia[array[poblacion], array[estacion]] != 0 && matrizDistancia[array[poblacion], array[estacion]] <= tope)
                            poblacionesAlcanzables[array[poblacion]] = 1;
                    }
                }

                if (poblacionesAlcanzables.Sum() > mejor)
                {
                    mejor = poblacionesAlcanzables.Sum();
                    Array.Copy(array, mejorCombinacion, array.Length);
                    PrintSet(mejorCombinacion);
                }    
            }
            else
            {
                for (int indice = posicion; indice < array.Length; indice++)
                {
                    int temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                    VariacionesSinRepeticion(array, posicion + 1, numeroACombinar, tope, mejorCombinacion,  matrizDistancia,  ref  mejor);
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
        }
    }
}
