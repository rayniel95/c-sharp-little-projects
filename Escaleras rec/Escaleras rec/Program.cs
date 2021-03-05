using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escaleras_rec
{

    class Program
    {
        static void Main(string[] args)
        {
            int myNumber = 0;
            //Console.WriteLine(NumeroEscaleras(3));
            Console.WriteLine(Resuelve(0, false, 3, ref myNumber));
        }
        public static int NumeroEscaleras(int numeroMaximo)
        {
            int myNumero = 0;
            Resuelve(0, false, numeroMaximo, ref myNumero);
            return myNumero;
        }
        public static int Resuelve(int llamado, bool ultimaVertical, int maximo, ref int numero)
        {
            if(llamado > 0)
            {
                numero++;
                return llamado;
            }
            if( llamado < maximo)
            {

                bool vertical = false;
                return Resuelve(llamado + 1, vertical, maximo, ref numero);
                if(!ultimaVertical)
                {
                    vertical = true;
                    return Resuelve(llamado + 1, vertical, maximo, ref numero);
                }
            }
            return 0;
        }
    }
}
