using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doble
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            string largo = Console.ReadLine();

            long numero = long.Parse(largo);

            Console.WriteLine(2 * numero);
        }
    }
}
