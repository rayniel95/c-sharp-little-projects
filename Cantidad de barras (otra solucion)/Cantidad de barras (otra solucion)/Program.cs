using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantidad_de_barras__otra_solucion_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BarCode(4, 4, 4));
        }
        static int BarCode(int numeroDeBarras, int longitudMaxima, int sumatoria)
        {
            if(numeroDeBarras == 0)
            {
                return sumatoria <= longitudMaxima ? 2 : 0;
            }
            int sum = 0;

            for(int indice = 1; indice < Math.Min(longitudMaxima, sumatoria - numeroDeBarras + 1); indice++)
            {
                sum += BarCode(numeroDeBarras - 1, longitudMaxima, sumatoria - indice);
            }
            return sum;
        }
    }
}
