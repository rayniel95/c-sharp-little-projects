using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaDeEspacio
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static int MayorUtilidad(int[] arrayPesos, int[] arrayValores, int pesoMaximo)
        {
            int valorMayor = 0;
            
            Subsets(new bool[arrayPesos.Length], 0, pesoMaximo, ref valorMayor, arrayPesos, arrayValores);

            return valorMayor;
        }
        static void Subsets(bool[] items, int from, int pesoMax, ref int mayorValor, int[] pesos, int[] valores)
        {
            if (from >= items.Length)
            {
                int[] subconjuntoPeso = Determina(items, pesos);
                int[] subconjuntoValores = Determina(items, valores);

                if (subconjuntoValores.Sum() > mayorValor && subconjuntoPeso.Sum() <= pesoMax)
                    mayorValor = subconjuntoValores.Sum();

            }
            else
            {
                items[from] = true;
                Subsets(items, from + 1, pesoMax, ref mayorValor, pesos, valores);
                items[from] = false;
                Subsets(items, from + 1, pesoMax, ref mayorValor, pesos, valores);
            }
        }
        static int[] Determina(bool[] indices, int[] aDeterminar)
        {
            int longitud = 0;

            foreach(bool elemento in indices)
            {
                if (elemento)
                    longitud++;
            }

            int[] determinado = new int[longitud];
            int suIndice = 0;
        
            for(int indice = 0; indice < indices.Length; indice++)
            {
                if(indices[indice])
                {
                    determinado[suIndice] = aDeterminar[indice];
                    suIndice++;
                }
            }
            return determinado;
        }
        static void IO()
        {
            string primeraLinea = Console.ReadLine();

            string[] linea = primeraLinea.Split();

            int dimension = int.Parse(linea[1]);
            int pesoMax = int.Parse(linea[0]);

            int[] valores = new int[dimension];
            int[] pesos = new int[dimension];

            for(int veces = 0; veces < dimension; veces++)
            {
                string fila = Console.ReadLine();

                string[] filaSplit = fila.Split();

                valores[veces] = int.Parse(filaSplit[1]);
                pesos[veces] = int.Parse(filaSplit[0]);
            }
            Console.WriteLine(MayorUtilidad(pesos, valores, pesoMax)); 
        }
    }
}
