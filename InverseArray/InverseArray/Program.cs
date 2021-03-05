using System;

namespace ToInverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int index = 0; 5 > index; index++)
                Console.WriteLine(InverseArray(new int[] { 1, 2, 3, 4, 5 })[index]);
        }
        static int[] InverseArray(int[] data)
        {
            int[] inverse = new int[data.Length];

            for(int index = (data.Length - 1); index >= 0; index--)
            {
                inverse[((data.Length - 1) - index)] = data[index];
            }
            return inverse;
        }        
    }
}
