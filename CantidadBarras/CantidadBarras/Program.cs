using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantidadBarras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CantidadBarras(5, 7, 7));

        }
        static int CantidadBarras(int numero, int tamano, int sumatoria)
        {
            if (numero * tamano == sumatoria)
                return 1;
            else if (numero * tamano < sumatoria) return 0;

            return CantidadBarras(numero, tamano - 1, sumatoria) + CantidadBarras(numero, tamano - 2, sumatoria);
        }
    }
}
