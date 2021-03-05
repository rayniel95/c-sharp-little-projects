using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple
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

            ulong numero = ulong.Parse(largo);

            Console.WriteLine(3 * numero);
        }
    }
}
