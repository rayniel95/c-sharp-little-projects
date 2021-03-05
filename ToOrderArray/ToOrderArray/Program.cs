using System;

namespace ToOrderArray
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int index = 0; 3 > index; index++)
            {
                Console.WriteLine(ToOrderArray(new int[] { 6, 4, 2 })[index]);
            }
        }
        static int [] ToOrderArray(int[] array)
        { 
            int[] data = new int[array.Length];
            
            Array.Copy(array, data, array.Length);
            
            int[] arrayOrdered = new int[array.Length];
            int counter = 0;
            int min = data[0];

            while (arrayOrdered.Length > counter)
            {
                for (int index = 0; data.Length > index; index++)
                {
                    min = Math.Min(min, data[index]);
                }
                arrayOrdered[counter] = min;
              
                data = Remove(data, Array.IndexOf(data, min));
                min = data[0];
                counter++;
            }
            return arrayOrdered;
        }
        static int[] Remove(int[] array, int theIndex)
        {
            int aIndex = 0;
            bool eliminated = false;

            int [] data = new int[array.Length - 1];

            for(int index = 0; array.Length > index; index++)
            {

                if (index == theIndex)
                {
                    eliminated = true;
                    continue;
                }
                if (eliminated)
                    aIndex = index - 1;
                else
                    aIndex = index;
                
                data[aIndex] = array[index];
            }
            return data;
        }
    }
}
