using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongitudDeSubsecuenciaMasLargaIterativo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Subsecuencia("abbcde", "bdfce"));
            // tanto en este como en el recursivo hay que garantizar que string1 sea de length mayor o igual que string2
        }
        static int Subsecuencia(string string1, string string2)
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

            for(int primerIndice = 1; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 1; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    if (string1[primerIndice] == string2[segundoIndice])
                        matrix[primerIndice, segundoIndice] = matrix[primerIndice - 1, segundoIndice - 1] + 1;
                    else
                        matrix[primerIndice, segundoIndice] = Math.Max(matrix[primerIndice - 1, segundoIndice], matrix[primerIndice, segundoIndice - 1]);
                }
            }
            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
    }
}
