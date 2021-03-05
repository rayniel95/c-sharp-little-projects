using System;

namespace IsMatrixMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[, ] matrix = {{4, 9, 2}, {3, 10, 7}, {8, 1, 6}};

            Console.WriteLine(IsMagic(matrix));
        }
        static bool IsMagic(int[,] data)
        {
            if (data.GetLength(0) != data.GetLength(1))
                throw new Exception("The matrix dimension must be equals");

            int [] sumaColumna = SumaColumna(data);
            int[] sumaFila = SumaFila(data);
            int[] sumaDiagonal = SumaDiagonal(data);

            for(int index = 0; data.GetLength(0) > index; index++)
            {
                if (sumaFila[index] != sumaColumna[index])
                    return false;
            }

            if ((sumaDiagonal[0] != sumaDiagonal[1]) || sumaDiagonal[0] != sumaFila[0])
                return false;
            return true;


        }
        static int[] SumaColumna(int[, ] data)
        {
            int suma = 0;
            int[] sumaArray = new int[data.GetLength(1)];

            for(int secondIndex = 0; data.GetLength(0) > secondIndex; secondIndex++)
            {
                for(int firstIndex = 0; data.GetLength(1) > firstIndex; firstIndex++)
                {
                    suma += data[firstIndex, secondIndex];
                }
                sumaArray[secondIndex] = suma;
                suma = 0;
            }
            return sumaArray;
        }
        static int[] SumaFila(int[, ] data)
        {
            int suma = 0;
            int[] sumaArray = new int[data.GetLength(0)];

            for (int firstIndex = 0; data.GetLength(0) > firstIndex; firstIndex++)
            {
                for (int secondIndex = 0; data.GetLength(1) > secondIndex; secondIndex++)
                {
                    suma += data[firstIndex, secondIndex];
                }
                sumaArray[firstIndex] = suma;
                suma = 0;
            }
            return sumaArray;
        }
        static int[] SumaDiagonal(int[, ] data)
        {
            int sumaIzq = 0;
            int sumaDer = 0;

            int[] sumaArray = new int[2];

            for(int index = 0; Math.Min(data.GetLength(0), data.GetLength(1)) > index; index++)
            {
                sumaIzq += data[index, index];
                sumaDer += data[index, (data.GetLength(1) - (index + 1))];
            }
            sumaArray[0] = sumaIzq;
            sumaArray[1] = sumaDer;

            return sumaArray;
        }
    }
}
