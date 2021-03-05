using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace DistanciaDosCadenas_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int cuantos = int.MaxValue;
            Stopwatch crono = new Stopwatch();
            crono.Start();
            ResuelveMenor("guafaa", "ava", ref cuantos, 0, 0);
            crono.Stop();
            Console.WriteLine(cuantos + " " + crono.Elapsed);



        }


        public static void ResuelveMenor(string cadena1, string cadena2, ref int mejor, int llamado, int indiceAnterior)
        {
            if (cadena1.CompareTo(cadena2) == 0)
            {
                if (llamado < mejor)
                    mejor = llamado;
                return;
            }
            else if (cadena1.Length == 0) return;

            for (int indice = indiceAnterior; indice < cadena1.Length; indice++)
            {

                if (cadena1.Length > cadena2.Length)
                {
                    string nueva = cadena1.Remove(indice, 1);
                    ResuelveMenor(nueva, cadena2, ref mejor, llamado + 1, indice);
                }

                foreach (var caracter in "abcdefghijklmnopqrstuvwxyz")
                {
                    string nueva = cadena1.Remove(indice, 1);
                    nueva = nueva.Insert(indice, caracter.ToString());
                    ResuelveMenor(nueva, cadena2, ref mejor, llamado + 1, indice + 1);

                }

                if (cadena1.Length < cadena2.Length)
                {
                    foreach (var caracter in "abcdefghijklmnopqrstuvwxyz")
                    {
                        string nueva = cadena1.Insert(indice, caracter.ToString());
                        ResuelveMenor(nueva, cadena2, ref mejor, llamado + 1, indice);
                    }
                }

            }


        }
    }
}
