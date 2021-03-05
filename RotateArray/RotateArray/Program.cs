using System;

namespace RotateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int index = 0; 4 > index; index++)
                Console.WriteLine(Rotate(new int[] { 1, 2, 3, 4 })[index]);
        }
        static int[] Rotate(int[] data)
        {
            int[] rotatedArray = new int[data.Length];
            int sum = 0;

            for(int number = 1; data.Length > number; number++)
            {
                sum = sum + number;
            }
            int promedie = sum / data.Length;

            for(int index = 0; (promedie + 2) >= index; index++)
            {
                rotatedArray[index] = data[(data.Length - 1) - index];
            }
            return rotatedArray;
        }
    }
}
