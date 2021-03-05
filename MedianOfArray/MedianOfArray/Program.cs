using System;

namespace MedianOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MedianOfArray(new int [] {1, 4, 6, 2, 6, 8}));
        }
        static int MedianOfArray(int[] data)
        {
            int median = -1;
            int counterMax = 0;
            int counterMin = 0;

            for(int index = 0; data.Length > index; index++)
            {
                for(int anIndex = 0; data.Length > anIndex; anIndex++)
                {
                    if (data[anIndex] > data[index])
                        counterMax++;
                    else if (data[index] > data[anIndex])
                        counterMin++;
                }
                if (counterMax == counterMin)
                {
                    median = data[index];
                    return median;
                }
                counterMax = 0;
                counterMin = 0;
            }
            return median;
        }
    }
}
