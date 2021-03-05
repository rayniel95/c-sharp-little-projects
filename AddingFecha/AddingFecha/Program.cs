using System;

namespace AddingFecha
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int index = 0; 3 > index; index++)
            {
                Console.Write(AddingFecha(new int[] { 3, 4, 7 }, 7)[index]);
            }
        }
        static int[] AddingFecha(int[] myFecha, int days)
        {
            bool ok = false;
            int[] result = { -1, -1, -1 };

            for(int index = 0; 3 > index; index++)
            {
                if (index == 0 && (myFecha[index] > 0 && 31 > myFecha[index]))
                    myFecha[index] = myFecha[index] + days;
                else
                    break;

                if (index == 1 && (myFecha[index] < 0 || 12 < myFecha[index]))
                {
                    ok = false;
                    break;
                }

                if (index == 2 && (myFecha[index] < 0))
                {
                    ok = false;
                    break;
                }
                ok = true;
            }
            if (ok)
                return myFecha;
            else
                return result;
        }
    }
}
