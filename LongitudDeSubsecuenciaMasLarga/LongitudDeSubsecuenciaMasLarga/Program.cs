using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongitudDeSubsecuenciaMasLarga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Subcadena("abbcde", "bdfce"));
        }
        static int Subcadena(string string1, string string2)
        {
            int[,] matrix = new int[string1.Length, string2.Length];

            if (string1[0] == string2[0])
                matrix[0, 0] = 1;
            else
                matrix[0, 0] = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (string2[0] == string1[i])
                    matrix[i, 0] = 1;
                else
                    matrix[i, 0] = matrix[i - 1, 0];
            }
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (string1[0] == string2[i])
                    matrix[0, i] = 1;
                else
                    matrix[0, i] = matrix[0, i - 1];
            }

                Subcadena(string1, string2, matrix, 1, 1);

                return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
        static void Subcadena(string stringUno, string stringDos, int[,] matriz, int fil, int column)
        {
            if (fil < matriz.GetLength(0) && column < matriz.GetLength(1))
            {
                if (stringUno[fil] == stringDos[column])
                    matriz[fil, column] = matriz[fil - 1, column - 1] + 1;
                else
                    matriz[fil, column] = Math.Max(matriz[fil - 1, column], matriz[fil, column - 1]);

                Subcadena(stringUno, stringDos, matriz, fil + 1, column);

                Subcadena(stringUno, stringDos, matriz, fil, column + 1);
            }             

        }
    }
}
