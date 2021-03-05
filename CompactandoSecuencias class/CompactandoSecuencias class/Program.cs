using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactandoSecuencias_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Compactador myCompactador = new Compactador();
            IEnumerable<int> resultados = myCompactador.Compacta<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, Suma, 6);
            foreach (int i in resultados)
                Console.WriteLine("{0} ", i);

            Console.WriteLine();

            string[] colores = { "rojo", "verde", "amarillo", "azul", "negro", "blanco" };
            IEnumerable<string> nuevoResultados = myCompactador.Compacta<string>(colores, Min, 2);
            foreach (string r in nuevoResultados)
                Console.WriteLine(r);

            Console.WriteLine();


        }
        public static int Suma(int a, int b)
        {
            return a + b;
        }
        static T Min<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
                return b;
            return a;
        }

        public delegate T Operacion<T>(T a, T b);

        public class Compactador
        {

            public IEnumerable<T1> Compacta<T1>(IEnumerable<T1> elementos, Operacion<T1> operacion, int longitud)
            {
                if (longitud < 2) throw new ArgumentException();
                List<T1> nuevoElementos = new List<T1>();
                int veces = 0;
                T1 primero = default(T1);
                T1 segundo = default(T1);
                foreach(var el in elementos)
                {
                    if(veces == 0)
                    {
                        primero = el;
                        veces++;
                        continue;
                    }
                    if(veces < longitud)
                    {
                        segundo = el;
                        primero = operacion(primero, segundo);
                        veces++;
                    }
                    if(veces == longitud)
                    {
                        veces = 0;
                        nuevoElementos.Add(primero);
                    }
                }
                if(veces > 0 && veces < longitud)
                {
                    nuevoElementos.Add(primero);
                }
                return nuevoElementos;
            }
        }
    }
}
