using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costo_Minimo_de_Multiplicar_Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> myList = new List<int[]>();
            
            int[] temp1 = {2, 3};
            int[] temp2 = {3, 2};
            int[] temp3 = {2, 4};
            
            myList.Add(temp1);
            myList.Add(temp2);
            myList.Add(temp3);

            Console.WriteLine(MinimoDeMultiplicaciones(myList));
        }
        static int MinimoDeMultiplicaciones(List<int[]> lista)
        {
            int some = int.MaxValue;

            Combinaciones(lista, 0, lista.Count, ref some);

            return some;
        }
        static void Combinaciones(List<int[]> array, int posicion, int numeroACombinar, ref int minimoAnterior)
        {
            if (array.Count == 0 || array.Count == 1)
            {
                minimoAnterior = -1;
                return;
            }
            else if (posicion == numeroACombinar)
            {
                List<int[]> myList = new List<int[]>();

                myList.AddRange(array);

                int minimo = CostoDeMultiplicar(myList);

                if (minimo != -1 && minimo < minimoAnterior)
                    minimoAnterior = minimo;
            }
            else
            {
                for (int indice = posicion; indice < array.Count; indice++)
                {
                    int[] temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                    Combinaciones(array, posicion + 1, numeroACombinar, ref minimoAnterior);
                    temp = array[indice];
                    array[indice] = array[posicion];
                    array[posicion] = temp;
                }
            }
        }
        static bool EsPosibleMultiplicar(List<int[]> matrices)
        {
            if (matrices.Count == 1)
                return false;
            else if (matrices.ElementAt(0)[1] == matrices.ElementAt(1)[0])
                return true;
            return false;
        }
        static void CostoDeMultiplicar(List<int[]> matrices, ref int sumaCosto)
        {
            if (EsPosibleMultiplicar(matrices))
            {
                int[] temp = new int[2];

                int filaTemp = matrices[0][0];
                int columnaTemp = matrices[1][1];

                int costo = filaTemp * matrices[0][1] * columnaTemp;
                sumaCosto += costo;

                temp[0] = filaTemp;
                temp[1] = columnaTemp;

                matrices.RemoveAt(0);
                matrices.RemoveAt(0);

                matrices.Insert(0, temp);

                CostoDeMultiplicar(matrices, ref sumaCosto);
            }
            else if (matrices.Count >= 2)
            {
                sumaCosto = -1;
                return;
            }
            else
                return;
                
        }
        static int CostoDeMultiplicar(List<int[]> matriz)
        {
            int zero = 0;

            CostoDeMultiplicar(matriz, ref zero);
            return zero;
        }
    }
}
