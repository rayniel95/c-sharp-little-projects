using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantidadDeCaminos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CantidadDeCaminos(1, 2));
        }
        static int CantidadDeCaminos(int n, int m)
        {
            if (n == 0 || m == 0)
                return 1;
            return CantidadDeCaminos(n - 1, m) + CantidadDeCaminos(n, m - 1);
        }
        static int CantidadDeCaminos(int n, int m, int i, int j)
        {
            return CantidadDeCaminos(i, j) * CantidadDeCaminos(n - i, m - j);
        }
     }
}
