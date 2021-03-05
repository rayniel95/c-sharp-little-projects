using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongitudDeLaCircunferencia
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static double Longitud(float diametro)
        {
            return Math.Round((Math.PI * diametro), 3);
        }
        static void IO()
        {
            string diametro = Console.ReadLine();

            if (diametro.Contains("."))
                diametro = diametro.Replace(".", ",");

            string longitud = Longitud(float.Parse(diametro)).ToString();

            if (longitud.Contains(","))
                longitud = longitud.Replace(",", ".");

            Console.WriteLine(longitud);
        }
    }
}
