using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecladoTelefonico_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var el in Cadenas("128#"))
                Console.WriteLine(el);

        }

        public static IEnumerable<string> Cadenas(string secuencia)
        {
            string[] numeros = { "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] secuenciasAsociadas = { "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };

            List<string> secuanciasActual = new List<string>();

            foreach(var letra in secuencia)
            {
                if(numeros.Contains(letra.ToString()))
                {
                    secuanciasActual.Add(secuenciasAsociadas[numeros.ToList().IndexOf(letra.ToString())]);
                }

            }
            List<string> mySecuancia = new List<string>();
            Resuelve(secuanciasActual.ToArray(), 0, "", mySecuancia);
            return mySecuancia;
           
        }
        public static void Resuelve(string[] secuanciasArray, int indiceSecuencia, string cadena, List<string> secuencias)
        {
            if(indiceSecuencia >= secuanciasArray.Length)
            {
                secuencias.Add(cadena);
            }
            else
            {
                foreach(var letra in secuanciasArray[indiceSecuencia])
                {
                    string nuevaCadena = cadena + letra;
                    Resuelve(secuanciasArray, indiceSecuencia + 1, nuevaCadena, secuencias);
                }

            }
        }

    }
}
