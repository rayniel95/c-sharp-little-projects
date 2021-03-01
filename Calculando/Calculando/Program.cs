using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculando
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            string[] cadena = Console.ReadLine().Split();

            int[] datos = new int[2];

            datos[0] = int.Parse(cadena[0]);
            datos[1] = int.Parse(cadena[1]);

            int myVeces = 0;
            string myCadena = cadena[0];

            Calcula(datos[0], datos[1], ref myCadena, ref myVeces);

            Console.WriteLine(myVeces);
            Console.WriteLine(myCadena);
        }
        static void Calcula(int numero, int aObtener, ref string operaciones, ref int veces)
        {
            if (aObtener == numero)
                return;
            else if (aObtener / 2 >= numero && aObtener % 2 == 0)
            {
                Calcula(numero, aObtener / 2, ref operaciones, ref veces);
                operaciones = " ( 2 * " + operaciones + " ) ";
                veces++;
            }
            else if (aObtener - 1 >= numero)
            {
                Calcula(numero, aObtener - 1, ref operaciones, ref veces);
                operaciones = " ( " + operaciones + " + 1 ) ";
                veces++;
            }
            else
                return;
        }
    }
}
