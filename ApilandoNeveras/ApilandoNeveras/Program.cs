using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApilandoNeveras
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> myNeveras = new List<List<int>>();

            List<int> cuatro = new List<int>();
            cuatro.Add(4);

            List<int> uno = new List<int>();
            uno.Add(1);

            List<int> seis = new List<int>();
            seis.Add(6);

            myNeveras.Add(cuatro);
            myNeveras.Add(uno);
            myNeveras.Add(seis);

            int myCosto = 0;

            ApilaNeveras(myNeveras, ref myCosto);

            Console.WriteLine(myCosto);
        }
        static void ApilaNeveras(List<List<int>> neveras, ref int costoMinimo)
        {
            if (neveras.Count == 1)
                return;

            int menorCosto = int.MaxValue;
            int[] indicesDeApilar = new int[2];

            int costoIzq = 0;
            int costoDerech = 0;

            for(int indice = 0; indice < neveras.Count - 1; indice++)
            {
                costoIzq = neveras[indice + 1].Count * neveras[indice].Sum();
                costoDerech = neveras[indice].Count * neveras[indice + 1].Sum();

                if(costoIzq <= costoDerech && costoIzq < menorCosto)
                {
                    menorCosto = costoIzq;
                    indicesDeApilar[0] = indice;
                    indicesDeApilar[1] = indice + 1;
                }
                else if (costoDerech < costoIzq && costoDerech < menorCosto)
                {
                    menorCosto = costoDerech;
                    indicesDeApilar[0] = indice;
                    indicesDeApilar[1] = indice + 1;
                }
            }
            neveras[indicesDeApilar[0]].AddRange(neveras[indicesDeApilar[1]]);
            neveras.RemoveAt(indicesDeApilar[1]);

            costoMinimo += menorCosto;

            ApilaNeveras(neveras, ref costoMinimo);
        }
        static void PrintList(List<List<int>> lista)
        {
            for(int primerIndice = 0; primerIndice < lista.Count; primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < lista[primerIndice].Count; segundoIndice++)
                {
                    Console.WriteLine(lista[primerIndice][segundoIndice]);
                }
                Console.WriteLine();
            }
        }
    }
}
