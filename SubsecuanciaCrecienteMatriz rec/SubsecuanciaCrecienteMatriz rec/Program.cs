using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsecuanciaCrecienteMatriz_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            
        }


        public static int[] MayorSubsecuancia(int[,] matriz)
        {
            List<int> myLista = new List<int>();

            int[] movFila = { -1, 0, 1, 0 };
            int[] movColumna = { 0, 1, 0, -1 };

            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    Moverse(matriz, primerIndice, segundoIndice, movFila, movColumna, ref myLista, new List<int>());
                }
            }
            return myLista.ToArray();
        }
        public static void Moverse(int[,] matrix, int fila, int columna, int[] arrayFila, int[] arrayColumna, ref List<int> mejor, List<int> actual)
        {
            if(actual.Count > mejor.Count)
            {
                mejor = new List<int>(actual);
            }

            for(int indice = 0; indice < arrayFila.Length; indice++)
            {
                int nuevaFila = fila + arrayFila[indice];
                int nuevaColumna = columna + arrayColumna[indice];

                if(EsValido(nuevaFila, nuevaFila, matrix) && matrix[nuevaFila, nuevaFila] > matrix[fila, columna])
                {
                    actual.Add(matrix[nuevaFila, nuevaColumna]);
                    Moverse(matrix, nuevaFila, nuevaColumna, arrayFila, arrayColumna, ref mejor, actual);
                    actual.RemoveAt(actual.Count - 1);
                }
            }
        }

        public static bool EsValido(int fila, int columna, int[,] matriz)
        {
            return fila >= 0 && columna >= 0 && fila < matriz.GetLength(0) && columna < matriz.GetLength(1);
        }
    }
}
