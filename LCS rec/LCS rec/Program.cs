using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LSC("thisisatest", "testing123testing"));
        }
        public static string LSC(string cadenaMenor, string cadenaMayor)
        {
            string my = "";
            Resuelve(0, my, ref my, cadenaMayor, cadenaMenor, 0);
            return my;
        }
        public static void Resuelve(int indiceActual, string cadenaActual, ref string mejorCadena, string cadenaMayor, string cadenaMenor, int indiceAContar)
        {
            if (cadenaActual.Length > mejorCadena.Length)
                mejorCadena = cadenaActual;
            for(int indice = indiceActual; indice < cadenaMenor.Length; indice++)
            {
                if(cadenaActual.Length == 0 && cadenaMayor.Contains(cadenaMenor[indice]))
                {
                    Resuelve(indice + 1, cadenaActual + cadenaMenor[indice], ref mejorCadena, cadenaMayor, cadenaMenor, cadenaMayor.IndexOf(cadenaMenor[indice]));
                }
                else if(cadenaMayor.Contains(cadenaMenor[indice]) && cadenaMayor.IndexOf(cadenaMenor[indice], indiceAContar) > cadenaMayor.IndexOf(cadenaActual[cadenaActual.Length - 1], indiceAContar))
                {
                    Resuelve(indice + 1, cadenaActual + cadenaMenor[indice], ref mejorCadena, cadenaMayor, cadenaMenor, cadenaMayor.IndexOf(cadenaMenor[indice], indiceAContar));
                }
            }
        }
    }
}
