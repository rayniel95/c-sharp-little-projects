using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //Console.WriteLine(SubCadenaComun("cambiamos", "comienzos"));

            #endregion
            #region Prueba2

            //Console.WriteLine(SubCadenaComun("abalondoowjnmanqwhf", "dalljiierbodjdjjhhhhhlhf9eijjffncodjdeiidndoooed"));

            #endregion
            #region Prueba3

            //Console.WriteLine(SubCadenaComun("cosa", "zqwetyp"));

            #endregion


        }

        public static string SubCadenaComun(string primera, string segunda)
        {
            string pequena = "";
            string grande = "";

            if(primera.Length > segunda.Length)
            {
                grande = primera;
                pequena = segunda;
            }
            else if(segunda.Length > primera.Length)
            {
                grande = segunda;
                pequena = primera;
            }
            else
            {
                pequena = primera;
                grande = segunda;
            }

            for(int veces = pequena.Length; veces >= 1; veces--)
            {
                string comun = Combina(pequena, new string[veces], 0, 0, grande);
                if (comun != "") return comun;
            }
            return "";
        }
        public static string Combina(string cadenaPeque, string[] subCadena, int posCadenaPeque, int posSubCadena, string cadenaGrande)
        {
            if (subCadena.Length == posSubCadena)
            {
                string cadena = "";
                foreach (var car in subCadena)
                    cadena += car;

                if (EsSubcadena(cadena, cadenaGrande))
                    return cadena;

            }
            else if (posCadenaPeque == cadenaPeque.Length) return "";
            else
            {
                subCadena[posSubCadena] = cadenaPeque[posCadenaPeque].ToString();

                string nueva = Combina(cadenaPeque, subCadena, posCadenaPeque + 1, posSubCadena + 1, cadenaGrande);

                if (nueva != "") return nueva;

                string otra = Combina(cadenaPeque, subCadena, posCadenaPeque + 1, posSubCadena, cadenaGrande);

                if (otra != "") return otra;
            }
            return "";
        }
        public static bool EsSubcadena(string cadenaPeque, string cadenaGrande)
        {
            int ultimoIndice = -1;
            foreach (var car in cadenaPeque)
            {
                ultimoIndice = cadenaGrande.IndexOf(car, ultimoIndice + 1);
                if (ultimoIndice == -1) return false;
            }
            return true;
        }


    }
}
