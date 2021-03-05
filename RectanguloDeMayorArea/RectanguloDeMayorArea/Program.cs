using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanguloDeMayorArea
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

            int[] array = new int[cadena.Length];

            for (int indice = 0; indice < array.Length; indice++)
            {
                array[indice] = int.Parse(cadena[indice]);
            }

            Console.WriteLine(Rectangulo(array));

        }
        static int Rectangulo(int[] histograma)
        {
            int mayor = 0;

            for(int indice = 0; indice < histograma.Length; indice++)
            {
                int cuentaDerech = 0;
                int cuentaIzq = 0;

                for(int indiceDerech = indice; indiceDerech < histograma.Length; indiceDerech++)
                {
                    if (histograma[indiceDerech] >= histograma[indice])
                        cuentaDerech++;
                    else
                        break;
                }

                for(int indiceIzq = indice - 1; indiceIzq >= 0; indiceIzq--)
                {
                    if (histograma[indiceIzq] >= histograma[indice])
                        cuentaIzq++;
                    else
                        break;
                }

                if (((cuentaIzq + cuentaDerech) * histograma[indice]) > mayor)
                    mayor = (cuentaIzq + cuentaDerech) * histograma[indice];
            }
            return mayor;
        }
    }
}
