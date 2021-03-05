using System;

namespace Fecha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fecha());
        }
        static bool Fecha()
        {
            bool ok = false;

            for(int index = 0; 3 > index; index++)
            {
                int number = int.Parse(Console.ReadLine());

                if (index == 0 && (31 < number || 0 >= number))
                    break;
                if (index == 1 && (12 < number || 0 > number))
                    break;
                if (index == 3 && (0 > number))
                    break;

                ok = true;
            }
            return ok;
        }
    }
}
