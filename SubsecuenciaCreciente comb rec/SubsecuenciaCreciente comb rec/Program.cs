using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsecuenciaCreciente_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //PrintSecuencia(MayorSubSecuencia(new int[] { 2, 4, 1, 3, 4, 5, 1, 6, 3 }));

            #endregion
            #region Prueba2
            //PrintSecuencia(MayorSubSecuencia(new int[] { 3, 4, 1, 2, 5, 7, 8, 3, 9 }));

            #endregion

        }
        public static int[] MayorSubSecuencia(int[] secuencia)
        {
            int[] subSecuencia = new int[0];

            for(int veces = secuencia.Length; veces > 0; veces--)
            {
                subSecuencia = Combina(secuencia, new int[veces], 0, 0);
                if (subSecuencia.Length > 0) return subSecuencia;
            }
            return subSecuencia;
        }
        public static int[] Combina(int[] secuencia, int[] subSecuencia, int posSecuencia, int posSubSecuencia)
        {
            if (subSecuencia.Length == posSubSecuencia)
            {
                if (EsCreciente(subSecuencia))
                    return subSecuencia;
            }
            else if (posSecuencia == secuencia.Length) return new int[0];
            else
            {
                subSecuencia[posSubSecuencia] = secuencia[posSecuencia];

                int[] primero = Combina(secuencia, subSecuencia, posSecuencia + 1, posSubSecuencia + 1);

                if (primero.Length > 0) return primero;

                int[] segundo = Combina(secuencia, subSecuencia, posSecuencia + 1, posSubSecuencia);

                if (segundo.Length > 0) return segundo;
            }
            return new int[0];
        }
        public static bool EsCreciente(int[] subsecuencia)
        {
            int anterior = subsecuencia[0];

            for(int indice = 1; indice < subsecuencia.Length; indice++)
            {
                if (subsecuencia[indice] <= anterior) return false;
                anterior = subsecuencia[indice];
            }
            return true;
        }
        public static void PrintSecuencia(int[] secuencia)
        {
            foreach(var el in secuencia)
                Console.Write(el + " ");
            Console.WriteLine();
        }

    }
}
