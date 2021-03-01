using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayReducidos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = {2, 2, 2, 3, 4, 4, 4, 3, 3, 2, 2, 1};
            int menorLongitud = int.MaxValue;

            //Console.WriteLine(Elimina(ref myArray, 5)); 

            int[] menos = new int[0];

            Console.WriteLine(Reduce(myArray, 0, 1, ref menorLongitud, ref menos));
            Console.WriteLine(menorLongitud);
            PrintArray(menos);
        }
        static bool Reduce(int[] array, int comienzo, int llamado, ref int longitudMenor, ref int[] menor)
        {
            if (EstaReducido(array))
                return true;

           
            for (int indice = comienzo; indice < array.Length; indice++)
            {
                int[] copiaArray = new int[array.Length];

                Array.Copy(array, copiaArray, array.Length);

                if (!Elimina(ref copiaArray, indice))
                    continue;

                if (Reduce(copiaArray, indice, llamado + 1, ref longitudMenor, ref menor))
                {
                    if (copiaArray.Length < longitudMenor)
                    {
                        int[] elArray = new int[copiaArray.Length];

                        Array.Copy(copiaArray, elArray, copiaArray.Length);

                        menor = elArray;

                        longitudMenor = copiaArray.Length;
                    }

                    if (llamado == 1 && indice < array.Length - 1)
                        continue;

                    else if (llamado == 1 && indice == array.Length - 1)
                        return true;

                    return true;
                }
            }
           
            return false;
        }
        static bool EstaReducido(int[] myArray)
        {
            try
            {
                for(int indice = 0; indice < myArray.Length; indice++)
                {
                    if(myArray[indice] == myArray[indice + 1] && myArray[indice] == myArray[indice + 2])
                        return false;
                }
            }
            catch
            {
                return true;
            }
            return true;
        }
        static void PrintArray(int[] myArray)
        {
            foreach (int element in myArray)
                Console.Write(element);

            Console.WriteLine();
        }
        static bool Elimina(ref int[] myArray, int elIndice)
        {
            List<int> array = myArray.ToList();

            int eliminadas = 0;

            try
            {
                if (array[elIndice + 1] == array[elIndice] && array[elIndice + 2] == array[elIndice])
                {
                    EliminaDerecha(array, elIndice + 1, array[elIndice]);
                }
            }
            catch
            { }

            try
            {
                if (array[elIndice - 1] == array[elIndice] && array[elIndice - 2] == array[elIndice])
                {
                    EliminaIzquierda(array, elIndice - 1, array[elIndice], ref eliminadas);
                }
            }
            catch
            { }
            
            if (array.Count != myArray.Length)
            {
                array.RemoveAt(elIndice - eliminadas);
                elIndice -= eliminadas;
                myArray = array.ToArray();

                return true;
            }
            else
                return false;
        }
        static void EliminaIzquierda(List<int> myArray, int myIndice, int numero, ref int eliminaciones)
        {
            if (myArray[myIndice] != numero || myIndice < 0)
                return;

            myArray.RemoveAt(myIndice);
            eliminaciones++;
            EliminaIzquierda(myArray, myIndice - 1, numero, ref eliminaciones);
        }
        static void EliminaDerecha(List<int> myArray, int myIndice, int numero)
        {
            if (myArray[myIndice] != numero || myIndice >= myArray.Count)
                return;

            myArray.RemoveAt(myIndice);

            EliminaDerecha(myArray, myIndice, numero);
        }
    }
}
