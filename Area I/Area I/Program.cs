using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_I
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static int Area(int largo, int ancho)
        {
            return largo * ancho;
        }
        static int Perimetro(int largo, int ancho)
        {
            return 2 * largo + 2 * ancho; 
        }
        static void IO()
        {
            string largo = Console.ReadLine();
            string ancho = Console.ReadLine();

            Console.WriteLine(Perimetro(int.Parse(largo), int.Parse(ancho)));
            Console.WriteLine(Area(int.Parse(ancho), int.Parse(largo)));
        }
    }
}
