using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrices;

namespace EnvolviendoMatrices_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Pruebas Metodos Auxiliares
            //int[,] myMatrix =
            //{
            //    {5, 1, 1, 5, 22, 6 },
            //    {3, 0, 5, 3, 1, 8 },
            //    {6, 4, 4, 6, 4, 8 }
            //};

            //PrintMatrix(myMatrix);

            //PrintMatrix(DoblaMatrizVertical(myMatrix, 1));

            //int[,] myMatrix =
            //{
            //    {5, 3, 6 },
            //    {1, 5, 4 },
            //    {1, 5, 4 },
            //    {5, 0, 6 },
            //    {22, 1, 4 },
            //    {6, 8, 8 }
            //};
            //PrintMatrix(DoblaMatrizHorizontal(myMatrix, 1));

            #endregion

            #region Prueba1

            //int[,] myMatriz =
            //{
            //    {5, 1, 1, 5, 2, 2 },
            //    {5, 1, 1, 5, 2, 2 },
            //    {2, 1, 1, 2, 1, 5 },
            //    {5, 2, 2, 5, 8, 1 },
            //    {5, 2, 2, 5, 8, 1 },
            //};

            //int[,] myMejor = myMatriz;

            //Resuelve(ref myMejor, myMatriz);

            //PrintMatrix(myMejor);


            #endregion
            #region Prueba2

            //int[,] myMatrix =
            //{
            //    {2, 2, 2, 2, 2, 2, 2 },
            //    {2, 2, 2, 2, 2, 2, 2 }
            //};

            //int[,] myMejor = myMatrix;

            //Resuelve(ref myMejor, myMatrix);

            //PrintMatrix(myMejor);



            #endregion
            #region Prueba3

            //int[,] myMatrix =
            //{
            //    {2, 2, 2, 2, 2, 2, 2 },
            //    {2, 2, 2, 2, 2, 2, 2 }
            //};

            //int[,] myMejor = myMatrix;

            //Resuelve(ref myMejor, myMatrix);

            //PrintMatrix(myMejor);

            #endregion


        }


        public static void Resuelve(ref int[,] mejor, int[,] matriz)
        {
            if (matriz.GetLength(0) <= mejor.GetLength(0) && matriz.GetLength(1) <= mejor.GetLength(1))
            {
                PrintMatrix(matriz);
                mejor = matriz;
                Console.WriteLine();
            }
            for(int indice = 0; indice < Math.Max(matriz.GetLength(0), matriz.GetLength(1)); indice++)
            {
                int[,] dobladaVertical = DoblaMatrizVertical(matriz, indice);

                if (dobladaVertical != null)
                    Resuelve(ref mejor, dobladaVertical);

                int[,] dobladaHorizontal = DoblaMatrizHorizontal(matriz, indice);

                if (dobladaHorizontal != null)
                    Resuelve(ref mejor, dobladaHorizontal);

                int[,] invertidaDobladaVertical = DoblaMatrizVertical(Matriz.InvierteHorizontal(matriz), indice);

                if (invertidaDobladaVertical != null)
                {
                    invertidaDobladaVertical = Matriz.InvierteHorizontal(invertidaDobladaVertical);
                    Resuelve(ref mejor, invertidaDobladaVertical);
                }

                int[,] invertidaDobladaHorizontal = DoblaMatrizHorizontal(Matriz.InvierteVertical(matriz), indice);

                if (invertidaDobladaHorizontal != null)
                {
                    invertidaDobladaHorizontal = Matriz.InvierteVertical(invertidaDobladaHorizontal);
                    Resuelve(ref mejor, invertidaDobladaHorizontal);
                }
            }


        }

        public static int[,] DoblaMatrizHorizontal(int[,] matrix, int indice)
        {
            if ((indice + 1) * 2 > matrix.GetLength(0)) return null;

            int[,] copia = new int[matrix.GetLength(0) - (indice + 1), matrix.GetLength(1)];

            int contador = indice + 1;

            for (int indiceFila = indice; indiceFila >= 0; indiceFila--)
            {
                for (int indiceColumna = 0; indiceColumna < matrix.GetLength(1); indiceColumna++)
                {
                    if (matrix[indiceFila, indiceColumna] != matrix[contador, indiceColumna])
                        return null;
                    copia[contador - indice - 1, indiceColumna] = matrix[contador, indiceColumna];

                }
                contador++;
            }
            if ((indice + 1) == copia.GetLength(0)) return copia;
            contador = 0;
            for (int indiceFila = indice + 1; indiceFila < copia.GetLength(0); indiceFila++)
            {
                for (int indiceColumna = 0; indiceColumna < matrix.GetLength(1); indiceColumna++)
                {
                    copia[indiceFila, indiceColumna] = matrix[(indice + 1) * 2 + contador, indiceColumna];

                }
                contador++;
            }
            return copia;
        }

        public static int[,] DoblaMatrizVertical(int[,] matrix, int indice)
        {
            if ((indice + 1) * 2 > matrix.GetLength(1)) return null;

            int[,] copia = new int[matrix.GetLength(0), matrix.GetLength(1) - (indice + 1)];

            int contador = indice + 1;

            for(int indiceColumna = indice; indiceColumna >= 0; indiceColumna--)
            {
                for(int indiceFila = 0; indiceFila < matrix.GetLength(0); indiceFila++)
                {
                    if (matrix[indiceFila, indiceColumna] != matrix[indiceFila, contador])
                        return null;
                    copia[indiceFila, contador - indice - 1] = matrix[indiceFila, contador];
                    
                }
                contador++;
            }
            if ((indice + 1) == copia.GetLength(1)) return copia;
            contador = 0;
            for(int indiceColumna = indice + 1; indiceColumna < copia.GetLength(1); indiceColumna++)
            {
                for(int indiceFila = 0; indiceFila < matrix.GetLength(0); indiceFila++)
                {
                    copia[indiceFila, indiceColumna] = matrix[indiceFila, (indice + 1) * 2 + contador];
                    
                }
                contador++;
            }
            return copia;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for(int primerIndice = 0; primerIndice < matrix.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < matrix.GetLength(1); segundoIndice++)
                {
                    Console.Write(matrix[primerIndice, segundoIndice]);
                }
                Console.WriteLine();
            }
        }

    }
}
