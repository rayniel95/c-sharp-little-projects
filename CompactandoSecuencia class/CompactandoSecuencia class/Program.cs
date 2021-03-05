using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactandoSecuencia_class
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //PrintEnumerable(Compacta(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, Suma, 3));


            #endregion


        }

        public static IEnumerable<T1> Compacta<T1>(IEnumerable<T1> secuencia, Operacion<T1> operacion, int longitud)
        {
            List<T1> compactado = new List<T1>();

            for(int veces = 0; veces < secuencia.Count(); veces += longitud)
            {
                T1 primero = secuencia.ElementAt(veces);

                if (veces < secuencia.Count() - 1)
                    primero = operacion(secuencia.ElementAt(veces), secuencia.ElementAt(veces + 1));

                for (int indice = veces + 2; indice < longitud + veces && indice < secuencia.Count(); indice++)
                    primero = operacion(primero, secuencia.ElementAt(indice));
                compactado.Add(primero);
            }
            return compactado;

        }
        public static int Suma(int primero, int segundo) { return primero + segundo; }
        public delegate T2 Operacion<T2>(T2 primero, T2 segundo);
        public static void PrintEnumerable<T3>(IEnumerable<T3> enumerable)
        {
            foreach(var el in enumerable)
                Console.Write(el);
            Console.WriteLine();
        }
    }
}
