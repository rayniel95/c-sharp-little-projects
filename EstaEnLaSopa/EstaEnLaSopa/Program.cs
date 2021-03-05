using System;

namespace EstaEnLaSopa
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] soup = {{'a', 'a', 'f', 't', 'j', 'q', 'w', 'e', 'r', 'o', 'p'},
                            {'g', 'j', 'p', 'b', 'j', 'e', 'r', 'o', 'a', 's', 'k'},
                            {'l', 'x', 'c', 'e', 't', 'y', 'e', 'r', 'a', 'o', 'n'},
                            {'b', 'g', 'j', 'f', 'l', 'd', 'e', 'r', 's', 't', 'o'},
                            {'q', 'u', 'e', 'r', 't', 'o', 'g', 's', 'e', 'm', 't'}};

            Console.WriteLine(IsInSoup(soup, "pelo"));
   
        }
        static bool IsValid(char[, ] table, int row, int column)
        {
            if ((row < 0) || (row >= table.GetLength(0)) || (column < 0) || (column >= table.GetLength(1)))
                return false;
            return true;
        }
        static bool IsInSoup(char[, ] sopa, string palabra)
        {
            // Norte, Sur, Este, Oeste, NorEste, NorOeste, SurEste, SurOeste.

            int[] movFila = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] movColumna = { 0, 0, -1, 1, -1, 1, -1, 1 };
            
            int nuevaFila = 0;
            int nuevaColumna = 0;
            int caracter = 0;

            for(int primerIndice = 0; sopa.GetLength(0) > primerIndice; primerIndice++)
            {
                for(int segundoIndice = 0; sopa.GetLength(1) > segundoIndice; segundoIndice++)
                {
                    for (int indice = 0; movFila.Length > indice; indice++)
                    {
                        nuevaFila = primerIndice;
                        nuevaColumna = segundoIndice;
                        caracter = 0;

                        while(IsValid(sopa, nuevaFila, nuevaColumna))
                        {
                            if (sopa[nuevaFila, nuevaColumna].ToString() == palabra.Substring(caracter, 1))
                            {
                                nuevaFila += movFila[indice];
                                nuevaColumna += movColumna[indice];

                                caracter++;

                                if (caracter == (palabra.Length - 1))
                                    return true;
                            }
                            else 
                                break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
