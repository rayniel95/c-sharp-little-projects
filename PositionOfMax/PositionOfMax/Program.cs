using System;

namespace PositionOfMax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PositionOfMax(new int[] { 1, 4, 5, 9, 2, 4, 1 })); 
        }
        static int PositionOfMax(int[] data)
        {
            int max = data[0];
            int position = 0;

            for(int index = 1; data.Length > index; index++)
            {
                if (data[index] > max)
                {
                    max = data[index];
                    position = index;
                }
            }
            return position;
        }
    }
}
