using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valores = {3, 5,  1, 10};
            int[] pesos = {10, 6, 15, 1};

            PrintSet(Mochila(pesos, valores, 7));
        }
        static int[] Mochila(int [] peso, int [] valor, int pesoMaximo)
        {
            int[] ganancia = new int[0];
            int some = 0;

            Subsets(new bool[valor.Length], 0, peso, valor, pesoMaximo, ref some, ref ganancia);

            return ganancia;
        }
        static void Subsets(bool[] items, int from, int[] pesos,int[] valores, int pesoMax, ref int valorAnteriorMax, ref int[] llevo)
        {
            if (from >= items.Length)
            {
                int peso = ValorTotal(Determina(items, pesos));
                int valor = ValorTotal(Determina(items, valores));

                if (peso <= pesoMax && peso != 0 && valor > valorAnteriorMax)
                {
                    int[] aLLevar = Determina(items, valores);
                    llevo = aLLevar;
                    valorAnteriorMax = valor;
                }
            }
            else
            {
                items[from] = true;
                Subsets(items, from + 1, pesos, valores, pesoMax, ref valorAnteriorMax, ref llevo);
                items[from] = false;
                Subsets(items, from + 1, pesos, valores, pesoMax, ref valorAnteriorMax, ref llevo);
            }
        }
        static int ValorTotal(int[] valoresADeterminar)
        {
            int valor = 0;

            foreach (int valores in valoresADeterminar)
                valor += valores;

            return valor;
        }
        static int[] Determina(bool[] indices, int[] array)
        {
            int longitud = 0;

            foreach (bool indice in indices)
            {
                if (indice)
                    longitud++;
            }

            int[] determinado = new int[longitud];

            int contador = 0;

            for (int indice = 0; indice < indices.Length; indice++)
            {
                if (indices[indice])
                {
                    determinado[contador] = array[indice];
                    contador++;
                }
            }
            return determinado;
        }
        static void PrintSet(int[] set)
        {
            foreach (int item in set)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        static void PrintSet(bool[] set)
        {
            foreach (bool item in set)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
