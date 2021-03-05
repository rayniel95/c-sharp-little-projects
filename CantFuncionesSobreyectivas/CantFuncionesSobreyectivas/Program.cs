using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantFuncionesSobreyectivas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CantFuncSobreyectivas(3, 10));
        }
        public static int CantFuncSobreyectivas(int m, int n)
        {
            int resultado = 0;
            for(int k = 0; k <= m; k++)
            {
                int potencia = (int) Math.Pow(m - k, n);

                int signo = (int) Math.Pow((-1), k);

                int binomio = Combinatoria(m, k);

                resultado += potencia * signo * binomio;
            }
            return resultado;
        }
        public static int Combinatoria(int m, int k)
        {
            int respuesta = 1;
            int resta = m;
            for(int indice = 0; indice < k; indice++)
            {
                resta -= indice;

                respuesta *= resta;

                resta = m;
            }

            int temp = 1;
            for(int indice = 1; indice <= k; indice++)
            {
                temp *= indice;
            }

            return respuesta / temp;
        }
    }
}
