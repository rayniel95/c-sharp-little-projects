using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduccionAPalindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static void IO()
        {
            string cadena = Console.ReadLine();
            int longitudMaxima = cadena.Length;
            Reduce(0, cadena.Length - 1, ref cadena);

            Console.WriteLine(longitudMaxima - cadena.Length);
            Console.WriteLine(cadena);
        }
        static void Reduce(int primerIndice, int segundoIndice, ref string cadena)
        {
            if ((cadena.Length % 2 == 0 && primerIndice == segundoIndice) || primerIndice == segundoIndice)
                return;

            else if (Math.Abs(primerIndice - segundoIndice) == 1 && cadena[primerIndice] == cadena[segundoIndice])
                return;
            

            else if (cadena[primerIndice] == cadena[segundoIndice])
                Reduce(primerIndice + 1, segundoIndice - 1, ref cadena);
            else
            {
                int cuentaIzq = 0;
                int cuentaDerech = 0;

                for (int indiceIzq = primerIndice + 1; indiceIzq < segundoIndice; indiceIzq++)
                {
                    if (cadena[indiceIzq] == cadena[segundoIndice])
                        break;
                    cuentaIzq++;
                }

                for (int indiceDerech = segundoIndice - 1; indiceDerech > primerIndice; indiceDerech--)
                {
                    if (cadena[indiceDerech] == cadena[primerIndice])
                        break;
                    cuentaDerech++;
                }

                if (cuentaIzq <= cuentaDerech)
                    cadena = cadena.Remove(primerIndice, 1);
                else
                    cadena = cadena.Remove(segundoIndice, 1);

                Reduce(primerIndice, segundoIndice - 1, ref cadena);
            }
        }
    }
}
