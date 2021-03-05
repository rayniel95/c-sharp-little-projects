using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplanando_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //int[] myArray = { 3, 1, 2, 2 };
            //List<Movimiento> myMejor = new List<Movimiento>();
            //for (int numero = 0; numero < 100; numero++)
            //    myMejor.Add(new Movimiento(numero, numero));
            //Resuelve(myArray, 0, new List<Movimiento>(), ref myMejor, 0);

            //PrintList(myMejor);

            #endregion
            #region Prueba2

            //int[] myArray = { 4, 1, 2, 4 };
            //List<Movimiento> myMejor = new List<Movimiento>();
            //for (int numero = 0; numero < 100; numero++)
            //    myMejor.Add(new Movimiento(numero, numero));
            //Resuelve(myArray, 0, new List<Movimiento>(), ref myMejor, 0);

            //PrintList(myMejor);
            #endregion
            #region Prueba3

            //int[] myArray = { 3, 1, 2, 7 };
            //List<Movimiento> myMejor = new List<Movimiento>();
            //for (int numero = 0; numero < 100; numero++)
            //    myMejor.Add(new Movimiento(numero, numero));
            //Resuelve(myArray, 0, new List<Movimiento>(), ref myMejor, 0);

            //PrintList(myMejor);

            #endregion
            #region Prueba4

            int[] myArray = { 3, 5, 2, 5 };
            List<Movimiento> myMejor = new List<Movimiento>();
            for (int numero = 0; numero < 100; numero++)
                myMejor.Add(new Movimiento(numero, numero));
            Resuelve(myArray, 0, new List<Movimiento>(), ref myMejor, 0);

            PrintList(myMejor);

            #endregion

        }


        public static void Resuelve(int[] array, int llamado, List<Movimiento> movimientosActuales, ref List<Movimiento> mejor, int indiceAnterior)
        {
            if (EstaAplanado(array))
            {
                if (movimientosActuales.Count < mejor.Count)
                {
                    mejor = new List<Movimiento>(movimientosActuales);
                }
                return;
            }
  
            for (int indice = indiceAnterior; indice < array.Length; indice++)
            {
                for (int cantidad = 1; cantidad <= array[indice]; cantidad++)
                {
                    int[] copia = CopiaArray(array);
                    copia[indice] -= cantidad;

                    if (indice - 1 >= 0)
                        copia[indice - 1] += cantidad;
                    if (indice + 1 < copia.Length)
                        copia[indice + 1] += cantidad;

                    movimientosActuales.Add(new Movimiento(indice, cantidad));

                    Resuelve(copia, llamado + 1, movimientosActuales, ref mejor, indice + 1);

                    movimientosActuales.RemoveAt(movimientosActuales.Count - 1);

                }
            }

        }
        public static void PrintList(List<Movimiento> lista)
        {
            foreach(var mov in lista)
            {
                Console.Write(mov.Pila + " " + mov.Cantidad);
                Console.WriteLine();
            }
        }
        public static int[] CopiaArray(int[] myArray)
        {
            int[] nuevo = new int[myArray.Length];

            for (int indice = 0; indice < nuevo.Length; indice++)
            {
                nuevo[indice] = myArray[indice];
            }
            return nuevo;
        }
        private static bool EstaAplanado(int[] array)
        {
            int temp = array[0];
            foreach(var el in array)
            {
                if (el != temp) return false;
            }
            return true;
        }

        public class Movimiento
        {
            public Movimiento(int pila, int cantidad)
            {
                Pila = pila;
                Cantidad = cantidad;
            }
            public int Pila { get; private set; }
            public int Cantidad { get; private set; }
        }



    }
}
