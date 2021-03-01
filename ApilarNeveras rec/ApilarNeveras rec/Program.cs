using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApilarNeveras_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //Console.WriteLine(CostoMinimo(new int[] { 4, 1, 6 }));

            #endregion
            #region Prueba2

            //Console.WriteLine(CostoMinimo(new int[] { 2, 4, 6, 7, 1, 8, 2 }));

            #endregion


        }

        public static int CostoMinimo(int[] neveras)
        {
            int menor = int.MaxValue;

            List<PilaNevera> myNeveras = new List<PilaNevera>();

            foreach (var el in neveras)
                myNeveras.Add(new PilaNevera(el, 1));

            Resuelve(myNeveras, 0, ref menor);

            if (menor == int.MaxValue) return -1;

            return menor;
        }

        public static void Resuelve(List<PilaNevera> secuenciaNeveras, int costoActual, ref int mejor)
        {
            if(secuenciaNeveras.Count == 1)
            {
                if (costoActual < mejor)
                    mejor = costoActual;
                return;
            }

            for(int indice = 0; indice < secuenciaNeveras.Count; indice++)
            {
                int costoIzq = 0;

                List<PilaNevera> apiladaIzq = ApilaIzq(secuenciaNeveras, indice, out costoIzq);
                if(apiladaIzq != null)
                    Resuelve(apiladaIzq, costoActual + costoIzq, ref mejor);

                int costoDer = 0;

                List<PilaNevera> apiladaDer = ApilaDer(secuenciaNeveras, indice, out costoDer);
                if(apiladaDer != null)
                    Resuelve(apiladaDer, costoActual + costoDer, ref mejor);
            }
        }
        public static List<PilaNevera> ApilaDer(List<PilaNevera> pilas, int indice, out int costo)
        {
            costo = 0;

            if (indice < pilas.Count - 1)
            {
                List<PilaNevera> nueva = CopiaLista(pilas);
                costo = nueva[indice].Altura * nueva[indice + 1].Peso;

                nueva[indice] = new PilaNevera(nueva[indice].Peso + nueva[indice + 1].Peso, nueva[indice].Altura + nueva[indice + 1].Altura);
                nueva.RemoveAt(indice + 1);
                return nueva;
            }
            return null;
        }
        public static List<PilaNevera> ApilaIzq(List<PilaNevera> pilas, int indice, out int costo)
        {
            costo = 0;

            if(indice > 0)
            {
                List<PilaNevera> nueva = CopiaLista(pilas);
                costo = nueva[indice].Altura * nueva[indice - 1].Peso;

                nueva[indice] = new PilaNevera(nueva[indice].Peso + nueva[indice - 1].Peso, nueva[indice].Altura + nueva[indice - 1].Altura);
                nueva.RemoveAt(indice - 1);
                return nueva;
            }
            return null;
        }
        public static List<PilaNevera> CopiaLista(List<PilaNevera> lista)
        {
            List<PilaNevera> nueva = new List<PilaNevera>();

            foreach (var pila in lista)
                nueva.Add(new PilaNevera(pila.Peso, pila.Altura));
            return nueva;
        }
        public class PilaNevera
        {
            public PilaNevera(int peso, int altura)
            {
                Peso = peso;
                Altura = altura;
            }
            public int Peso { get; set; }
            public int Altura { get; set; }
        }



    }
}
