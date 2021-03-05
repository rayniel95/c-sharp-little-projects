using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subconjuntos
{
    class Program
    {
        static void Main(string[] args)
        {
            Subsets(7);
        }
        static void Subsets(int numero)
        {
            Subsets(new bool[numero], 0);
        }
        static void Subsets(bool[] items, int from)
        {
            if (from >= items.Length)
                PrintSet(items);
            else
            {
                items[from] = true;
                Subsets(items, from + 1);
                items[from] = false;
                Subsets(items, from + 1);
            }
        }
        static void PrintSet(bool[] elementos)
        {
            for(int indice = 0; indice < elementos.Length; indice++)
            {
                if (elementos[indice])
                    Console.Write(indice);
            }
            Console.WriteLine();
        }
    }
}
