using System;

namespace ArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static int[] ArrayAdd(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
                throw new Exception("Array must be equal dimension");

            int[] arrayAdd = new int[firstArray.Length];

            for(int index = 0; arrayAdd.Length > index; index++)
                arrayAdd[index] = firstArray[index] + secondArray[index];
            
            return arrayAdd;
        }
    }
}
