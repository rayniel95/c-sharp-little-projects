using System;

namespace AscendentOrderInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAscendentOrder(new int[] { 1, 8, 3, 4, 5 }));
        }
        static bool IsAscendentOrder(int[] data)
        {
            for(int index = 0; (data.Length - 1) > index; index++)
            {
                if (data[index] > data[index + 1])
                    return false;
            }
            return true;
        }
    }
}
