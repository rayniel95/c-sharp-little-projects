using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDelExito_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //int[,] myMatriz = 
            //{
            //    { 27, 21, 21},
            //    { 34, 24, 27},
            //    { 40, 30, 33}
            //};

            //Console.WriteLine(Formula(myMatriz, 69));


            #endregion

            #region Prueba2

            //int[,] myMatriz =
            //{
            //    {13, 15, 12 },
            //    {16, 16, 14 },
            //    {19, 17, 15 }
            //};

            //Console.WriteLine(Formula(myMatriz, 47));
            #endregion



        }

        public static double Formula(int[,] matriz, int tiempo)
        {
            List<int[]> datos = new List<int[]>();
            double max = int.MinValue;
            for(int primerIndice = 0; primerIndice < matriz.GetLength(1); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < 3; segundoIndice++)
                {
                    int[] nuevo = new int[2];
                    nuevo[0] = segundoIndice;
                    nuevo[1] = primerIndice;
                    datos.Add(nuevo);
                }

            }
            Combinaciones(datos.ToArray(), new int[matriz.GetLength(1)][], 0, 0, ref max, matriz, tiempo);

            if (max > int.MinValue)
                return max;
            return -1;

        }
        public static void Combinaciones(int[][] array, int[][] combinacion, int posArray, int posCombinacion, ref double mejor, int[,] matriz, int tiempo)
        {
            if (posCombinacion == combinacion.Length)
            {
                if(EstanTodas(combinacion) && CalculaTiempo(matriz, combinacion) <= tiempo)
                {
                    if (CalculaPromedio(combinacion) > mejor)
                        mejor = CalculaPromedio(combinacion);
                }
            
            }
            else if (posArray == array.Length)
                return;
            else
            {
                combinacion[posCombinacion] = array[posArray];
                Combinaciones(array, combinacion, posArray + 1, posCombinacion + 1, ref mejor, matriz, tiempo);
                Combinaciones(array, combinacion, posArray + 1, posCombinacion, ref mejor, matriz, tiempo);
            }
        }
        public static double CalculaPromedio(int[][] arrays)
        {
            double promedio = 0;
            foreach(var array in arrays)
            {
                promedio += (array[0] + 3); 
            }
            return promedio / arrays.Length;
        }
        public static int CalculaTiempo(int[,] matrix, int[][] arrays)
        {
            int tiempoMax = 0;

            foreach(var array in arrays)
            {
                tiempoMax += matrix[array[0], array[1]];
            }
            return tiempoMax;
        }
        public static bool EstanTodas(int[][] myArray)
        {
            bool[] verifica = new bool[myArray.Length];

            foreach(var array in myArray)
            {
                if (!verifica[array[1]])
                    verifica[array[1]] = true;
                else
                    return false;
            }
            return true;
        }
    }
}
