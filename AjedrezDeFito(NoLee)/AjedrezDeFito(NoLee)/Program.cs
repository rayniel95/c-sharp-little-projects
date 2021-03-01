using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezDeFito_NoLee_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SaltoDeCaballo(20, 20));
        }
        static int SaltoDeCaballo(int myFila, int myColumna)
        {
            int[] filaMov = { -2, -1, 2, 1 };
            int[] columnaMov = { -1, -2, -1, -2 };

            int minimo = int.MaxValue;

            SaltoDeCaballo(myFila, myColumna, 0,ref minimo, filaMov, columnaMov);
            return minimo; 
        }
        static void SaltoDeCaballo(int fila, int columna, int llamado, ref int mejor, int[] movFila, int[] movColumna)
        {
            if (fila == 0 && columna == 0)
            {
                if(llamado < mejor)
                    mejor = llamado;
                //Console.WriteLine(llamado);
                return;
            }
            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if(EsValido(nuevaFila, nuevaColumna))
                {
                    SaltoDeCaballo(nuevaFila, nuevaColumna, llamado + 1, ref mejor, movFila, movColumna);
                }
            }
        }
        static bool EsValido(int fila, int columna)
        { return fila >= 0 && columna >= 0; }
    }
}
