using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantidadSumandos_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //Console.WriteLine(CantidadDescomposiciones(5));
            #endregion
            #region Prueba2
            //Console.WriteLine(CantidadDescomposiciones(3));
            #endregion
            #region Prueba3

            //Console.WriteLine(CantidadDescomposiciones(22));

            #endregion
            #region Prueba4

            //Console.WriteLine(CantidadDescomposiciones(100));

            #endregion

        }
        public static int CantidadDescomposiciones(int myNumero)
        {
            int cant = 0;

            int[] numeros = new int[myNumero];
            for (int indice = 0; indice < myNumero; indice++)
                numeros[indice] = indice + 1;

            Resuelve(numeros, 0, 0, myNumero, ref cant);

            return cant;
        }
        public static void Resuelve(int[] array, int indiceAnterior, int cantidad, int numero, ref int veces)
        {
            if(cantidad == numero)
            {
                veces++;
                return;
            }

            for(int indice = indiceAnterior; indice < array.Length; indice++)
            {
                if (cantidad + array[indice] > numero) return;

                Resuelve(array, indice, cantidad + array[indice], numero, ref veces);
            }
        }
    }
}
