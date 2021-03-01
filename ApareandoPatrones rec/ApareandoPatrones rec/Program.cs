using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApareandoPatrones_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //Console.WriteLine(Coincidencias("?a?", "aa"));

            #endregion
            #region Prueba2

            //Console.WriteLine(Coincidencias("!+*", "abaa"));

            #endregion
            #region Prueba3
            //Console.WriteLine(Coincidencias("Hola Mundo", "Hola Mundo"));        // 1
            #endregion
            #region Prueba4
            //Console.WriteLine(Coincidencias("Hola Mundo", "Hola Mundo!"));       // 0
            #endregion
            #region Prueba5
            //Console.WriteLine(Coincidencias("?a?", "aa"));                       // 2
            #endregion
            #region Prueba6
            //Console.WriteLine(Coincidencias("!+*", "abaa"));                     // 3
            #endregion
            #region Prueba7

            //Console.WriteLine(Coincidencias("*?", ""));                          // 1
            #endregion
            #region Prueba8
            //Console.WriteLine(Coincidencias("*?", "Otra cadena cualquiera"));    // 2
            #endregion



        }


        public static int Coincidencias(string patron, string cadena)
        {
            string myPatron = patron.Replace(" ", "");
            string myCadena = cadena.Replace(" ", "");

            List<int> indicesPicar = new List<int>();

            for (int indice = 1; indice < myCadena.Length; indice++)
                indicesPicar.Add(indice);

            int coincidencias = 0;

            for (int veces = 0; veces < cadena.Length; veces++)
                IndicesPicar(indicesPicar.ToArray(), new int[veces], 0, 0, ref coincidencias, myCadena, myPatron);

            return coincidencias;
        }
        public static void IndicesPicar(int[] indices, int[] aPicar, int posIndices, int posPicar, ref int cant, string myCadena, string myPatron)
        {
            if (posPicar == aPicar.Length)
            {
                List<string> picada = PicaCadena(myCadena, aPicar);

                List<int> indicesPatron = new List<int>();

                for (int indice = 0; indice < myPatron.Length; indice++)
                    indicesPatron.Add(indice);

                cant += HazCoincidir(indicesPatron.ToArray(), new int[picada.Count], 0, 0, picada, myPatron);
            }
            else if (posIndices == indices.Length) return;
            else
            {
                aPicar[posPicar] = indices[posIndices];

                IndicesPicar(indices, aPicar, posIndices + 1, posPicar + 1, ref cant, myCadena, myPatron);
                IndicesPicar(indices, aPicar, posIndices + 1, posPicar, ref cant, myCadena, myPatron);
            }
        }
        public static int HazCoincidir(int[] indicesConjunto, int[] indicesCoincidir, int posConjunto, 
            int posCoincidir, List<string> cadenaPicada, string patron)
        {
            if (posCoincidir == indicesCoincidir.Length)
            {
                if (Aparea(patron, cadenaPicada, indicesCoincidir))
                    return 1;
                return 0;

            }
            else if (posConjunto == indicesConjunto.Length) return 0;

            indicesCoincidir[posCoincidir] = indicesConjunto[posConjunto];

            return HazCoincidir(indicesConjunto, indicesCoincidir, posConjunto + 1, posCoincidir + 1, cadenaPicada, patron) +
                HazCoincidir(indicesConjunto, indicesCoincidir, posConjunto + 1, posCoincidir, cadenaPicada, patron);

        }
        public static bool Aparea(string patron, List<string> picada, int[] indices)
        {
            for(int indice = 0; indice < indices.Length; indice++)
            {
                if (patron[indices[indice]] == '!' && picada[indice].Length != 1)
                    return false;
                else if (patron[indices[indice]] == '?' && picada[indice].Length > 1)
                    return false;
                else if (("qwertyuioplkjhgfdsazxcvbnmñ".Contains(patron[indices[indice]]) || "QWERTYUIOPLKJHGFDSAZXCVBNMÑ".Contains(patron[indices[indice]]))
                    && picada[indice] != patron[indices[indice]].ToString())
                    return false;
            }
            for(int indice = 0; indice < patron.Length; indice++)
            {
                if(!indices.Contains(indice) && (patron[indice] != '?' && patron[indice] != '*'))
                    return false;
            }
            return true;
        }
        public static List<string> PicaCadena(string cadena, int[] indices)
        {
            List<int> indicesPicada = indices.ToList();
            indicesPicada.Add(cadena.Length);
            indicesPicada.Insert(0, 0);

            List<string> cadenaPicada = new List<string>();

            for(int indice = 0; indice < indicesPicada.Count - 1; indice++)
            {
                string nueva = cadena.Substring(indicesPicada[indice], indicesPicada[indice + 1] - indicesPicada[indice]);
                cadenaPicada.Add(nueva);
            }
            return cadenaPicada;

        }

    }
}
