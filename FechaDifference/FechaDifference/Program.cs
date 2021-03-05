using System;

namespace FechaDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DaysDifference(new int[] { 4, 5, 7 }, new int[] { 5, 7, 9 }));
        }
        static bool IsData(int[] data)
        {
            bool ok = false;

            for (int index = 0; 3 > index; index++)
            {
                if (index == 0 && (data[index] < 0 || 31 < data[index]))
                    break;

                if (index == 1 && (data[index] < 0 || 12 < data[index]))
                {
                    ok = false;
                    break;
                }

                if (index == 2 && (data[index] < 0))
                {
                    ok = false;
                    break;
                }
                ok = true;
            }
            return ok;
        }
        static int DaysDifference(int[] firstData, int[] secondData)
        {
            if (!IsData(firstData) || !IsData(secondData))
                throw new Exception("Datas are invalid");

            int daysDifference = firstData[0] - secondData[0];

            return daysDifference;
        }
    }
}
