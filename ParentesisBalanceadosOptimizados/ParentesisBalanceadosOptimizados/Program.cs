using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentesisBalanceadosOptimizados
{
    class Program
    {
        static void Main(string[] args)
        {

            IO();
        }
        static void IO()
        {
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine(Parentesis(numero));
        }
        static int Parentesis(int n)
        {
            int[] array = new int [n];

            return Parent(n);
           
        }
        static int Parent(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            int result = 0;

            for (int i = 0; i < n; i++)
                result += Parent(i) * Parent(n - i - 1);
            return result;
        }
    }
}
