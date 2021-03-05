using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EulerMetodoConsolaRayniel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba separado por espacios: c1, c2, c3, cantidadPuntos, paso, x1, x2, x3, x4, x5, x6 y el tiempo");
            string[] temp = Console.ReadLine().Split();

            List<double[]> vectores = Calculador(double.Parse(temp[0]), double.Parse(temp[1]), double.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]), double.Parse(temp[5]),
                double.Parse(temp[6]), double.Parse(temp[6]), double.Parse(temp[7]), double.Parse(temp[8]), double.Parse(temp[9]), double.Parse(temp[10]));

            Console.SetBufferSize(Console.BufferWidth, Int16.MaxValue - 1);

            Console.WriteLine("Tiempo:");
            
            foreach(var vector in vectores)
                Console.WriteLine(vector[0]);

            Console.WriteLine("---------------------------------|");
            
            for (int indice = 1; indice < 7; indice++)
            {
                Console.WriteLine("Puntos de X{0}", indice);
                foreach (var vector in vectores)
                {
                    Console.WriteLine(vector[indice]);
                }
            }
        }
        public static List<double[]> Calculador(double c1, double c2, double c3, int cantidadPuntos, int paso, double x1, double x2, double x3, double x4, double x5, double x6, double T)
        {
            double[] xn = { T, x1, x2, x3, x4, x5, x6 };
            double[] xn1 = new double[7];

            double[,] matriz = {
                                  {0, 0, 0, 1, 0, 0},
                                  {0, 0, 0, 0, 1, 0},
                                  {0, 0, 0, 0, 0, 1},
                                  {-1 * c1, c1, 0, 0, 0, 0},
                                  {c2, -2 * c2, c2, 0, 0, 0},
                                  {0, c3, -1 * c3, 0, 0, 0}
                              };

            List<double[]> puntos = new List<double[]>(cantidadPuntos + 1);

            puntos.Add(xn);

            for (int veces = 1; veces <= cantidadPuntos; veces++)
            {
                double tiempo = T + veces * paso;

                for (int primerIndice = 0; primerIndice < 6; primerIndice++)
                {
                    double numero = 0;

                    for (int segundoIndice = 0; segundoIndice < 6; segundoIndice++)
                    {
                        numero += matriz[primerIndice, segundoIndice] * xn[segundoIndice + 1];
                    }
                    xn1[primerIndice + 1] = numero;
                }

                for (int indice = 1; indice < 7; indice++)
                {
                    xn1[indice] = paso * xn1[indice];
                    xn1[indice] += xn[indice];
                }

                xn1[0] = tiempo;

                puntos.Add(xn1);

                xn = xn1;
                xn1 = new double[7];
            }
            return puntos;
        }
    }
}
