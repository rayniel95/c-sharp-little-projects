using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candados_rec
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach(var el in MinimoLLaves(6, new Enlace(0, 1), new Enlace(0, 2), new Enlace(1, 2), new Enlace(1, 4), new Enlace(3, 1), new Enlace(2, 5)))
                Console.Write(el);
            Console.WriteLine();
        }

        public struct Enlace
        {
            public Enlace(int primero, int segundo)
            {
                Primero = primero;
                Segundo = segundo;
            }
            public int Primero { get; private set; }
            public int Segundo { get; private set; }
        }
        public static int[] MinimoLLaves(int numeroCandados, params Enlace[] enlaces)
        {
            int[] temp = new int[numeroCandados];

            for (int indice = 0; indice < temp.Length; indice++)
                temp[indice] = indice;

            int[,] matrizEnlaces = new int[numeroCandados, numeroCandados];

            foreach(var enlace in enlaces)
            {
                matrizEnlaces[enlace.Primero, enlace.Segundo] = 1;
                matrizEnlaces[enlace.Segundo, enlace.Primero] = 1;
            }
            List<int> candadosnecesarios = temp.ToList();

            for (int indice = 1; indice <= numeroCandados; indice++)
                Combinaciones(temp, new int[indice], 0, 0, matrizEnlaces, ref candadosnecesarios);

            return candadosnecesarios.ToArray();
        }
        public static void Combinaciones(int[] array, int[] combinacion, int posArray, int posCombinacion, int[,] enlacesMatrix, ref List<int> candados)
        {
            if (posCombinacion == combinacion.Length)
            {
                int[,] copiaMatrix = CopiaMatrix(enlacesMatrix);

                foreach (int indice in combinacion)
                {
                    for (int fila = 0; fila < copiaMatrix.GetLength(0); fila++)
                        copiaMatrix[fila, indice] = 0;
                    for (int columna = 0; columna < copiaMatrix.GetLength(1); columna++)
                        copiaMatrix[indice, columna] = 0;
                }

                if (EstanDesenlazados(copiaMatrix) && combinacion.Length < candados.Count)
                {
                    candados = combinacion.ToList();
                }
            }
            else if (posArray == array.Length)
                return;
            else
            {
                combinacion[posCombinacion] = array[posArray];
                Combinaciones(array, combinacion, posArray + 1, posCombinacion + 1, enlacesMatrix, ref candados);
                Combinaciones(array, combinacion, posArray + 1, posCombinacion, enlacesMatrix, ref candados);
            }
        }

        private static bool EstanDesenlazados(int[,] matriz)
        {
            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for (int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                    if (matriz[primerIndice, segundoIndice] != 0)
                        return false;
            }
            return true;
        }

        public static int[,] CopiaMatrix(int[,] matriz)
        {
            int[,] copia = new int[matriz.GetLength(0), matriz.GetLength(1)];

            for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                {
                    copia[primerIndice, segundoIndice] = matriz[primerIndice, segundoIndice];
                }
            }
            return copia;
        }
    }
}
