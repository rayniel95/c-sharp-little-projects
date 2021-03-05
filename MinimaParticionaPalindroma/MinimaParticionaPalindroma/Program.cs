using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimaParticionaPalindroma
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "csharp";
            int[] myArray = {0, 3, 4, 7};
            
            BuscaPalindromo(cadena);
        }
        static void BuscaPalindromo(string cadena)
        {
            int[] aCombinar = new int[cadena.Length - 1];

            for (int indice = 0; indice < aCombinar.Length; indice++)
                aCombinar[indice] = indice + 1;

            bool encontrada = false;
      
            for (int indice = 0; indice < Math.Pow(2, cadena.Length); indice++)
            {
                if (!encontrada)
                {
                    int[] palindromoIndice = new int[indice + 2];
                    Combinaciones(aCombinar, new int[indice], 0, 0, ref encontrada, ref palindromoIndice, cadena);
                }
            }
        }
        static void Combinaciones(int[] array, int[] combinacion, int posicionArray, int posicionCombinacion, ref bool seEncontro, ref int[] indicePalindromo, string myCadena)
        {
            if (posicionCombinacion == combinacion.Length)
            {
                if (!seEncontro)
                {
                    List<int> insertaCombinacion = combinacion.ToList();

                    insertaCombinacion.Insert(0, 0);
                    insertaCombinacion.Add(myCadena.Length);

                    int[] myCombinacion = insertaCombinacion.ToArray();

                    if(VerificaPalidromo(myCadena, 0, 1, myCombinacion))
                    {
                        seEncontro = true;
                        Array.Copy(myCombinacion, indicePalindromo, myCombinacion.Length);
                    }
                }

            }
            else if (posicionArray == array.Length)
                return;
            else
            {
                combinacion[posicionCombinacion] = array[posicionArray];
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion + 1, ref seEncontro, ref indicePalindromo, myCadena);
                Combinaciones(array, combinacion, posicionArray + 1, posicionCombinacion, ref seEncontro, ref indicePalindromo, myCadena);
            }
        }
        static void PrintArray(int[] myArray)
        {
            for (int indice = 0; indice < myArray.Length; indice++)
                Console.Write(myArray[indice]);
            Console.WriteLine();
        }
        static bool VerificaPalidromo(string cadena, int pos1, int pos2, int[] array)
        {
            if (pos2 == array.Length)
                return true;

            else if (!EsPalindromo(Hazcadena(cadena, array[pos1], array[pos2])))
                return false;

            if (VerificaPalidromo(cadena, pos2, pos2 + 1, array))
                return true;

            return false;
        }
        static bool EsPalindromo(string myCadena)
        {
            for (int indice = 0; indice < myCadena.Length; indice++)
            {
                if (myCadena[indice] != myCadena[myCadena.Length - 1 - indice])
                    return false;
            }
            return true;
        }
        static string Hazcadena(string cadena, int indice1, int indice2)
        {
            string myCadena = "";
            for (int indice = indice1; indice < indice2; indice++)
                myCadena += cadena[indice];
            return myCadena;
        }
    }
}
