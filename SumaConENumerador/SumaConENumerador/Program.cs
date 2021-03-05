using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumaConENumerador
{

    class Program
    {
        static void Main(string[] args)
        {
        }
        static int Suma(IEnumerable<int> numeros)
        {
            IEnumerator<int> myEnumerator = numeros.GetEnumerator();
            int suma = 0;
            while (myEnumerator.MoveNext())
            {
                suma += myEnumerator.Current;
            }
            return suma;
        }
    }
}
