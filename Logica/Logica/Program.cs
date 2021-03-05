using System;


namespace Logica
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] oneArray = {1, 2, 3, 4, 5};
            int [] twoArray = {3, 5, 6};
           
            for(int index = 0; twoArray.Length > index; index++)
            {
                Console.Write(Interseccion(oneArray, twoArray)[index]);
            }
        }
        static int[] Interseccion(int[] firstArray, int[] secondArray)
        {

            if (Math.Min(firstArray.Length, secondArray.Length) == firstArray.Length)
            {
                int [] minArray = firstArray;
                int [] maxArray = secondArray;
            }
            else
            {
                int [] minArray = secondArray;
                int [] maxArray = firstArray;
            }

            int[] interseccion = new int[minArray.Length];

            for(int firstIndex = 0; minArray.Length > firstIndex; firstIndex++)
            {
                for(int secondIndex = 0; maxArray.Length > secondIndex; secondIndex++)
                {
                    if (minArray[firstIndex] == maxArray[secondIndex])
                        interseccion[firstIndex] = minArray[firstIndex];
                }
            }
            return interseccion;
        }
    }
}
