using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.ApareandoPatrones
{
    public static class Examen
    {
        public static int CantidadCoincidencias(string patron, string cadena)
        {
            List<string> lista = new List<string>();
            if (cadena.Length == 0)
            {
                lista = PicaCadena(new int[0], patron);
                int cantidad = 0;
                Resuelve(patron, lista, 0, 0, ref cantidad);
                return cantidad;
            }
            string myPatron = patron.Replace(" ", "");
            string myCadena = cadena.Replace(" ", "");

            return Combinacion(myPatron, myCadena);
           
        }

        public static int Combinacion(string patron, string cadena)
        {
            List<int> indicesCadena = new List<int>();

            for (int indice = 1; indice < cadena.Length; indice++)
                indicesCadena.Add(indice);
            int cantidad = 0;
            for (int veces = 0; veces < cadena.Length; veces++)
                Combinaciones(indicesCadena.ToArray(), new int[veces], 0, 0, cadena, ref cantidad, patron);
            return cantidad;
        }
        public static void Combinaciones(int[] array, int[] combinacion, int posArray, int posCombinacion, string myCadena, ref int cant, string myPatron)
        {
            if (posCombinacion == combinacion.Length)
            {
                int cantidad = 0;
                if (Resuelve(myPatron, PicaCadena(combinacion, myCadena), 0, 0, ref cant))
                    cant += cantidad;
            }
            else if (posArray == array.Length) return;
            else
            {
                combinacion[posCombinacion] = array[posArray];

                Combinaciones(array, combinacion, posArray + 1, posCombinacion + 1, myCadena, ref cant, myPatron);
                Combinaciones(array, combinacion, posArray + 1, posCombinacion, myCadena, ref cant, myPatron);
            }
        }
        public static List<string> PicaCadena(int[] indices, string cadena)
        {
            List<int> indicesLista = indices.ToList();
            indicesLista.Insert(0, 0);
            indicesLista.Add(cadena.Length);

            List<string> picada = new List<string>();

            for(int indice = 0; indice < indicesLista.Count - 1; indice++)
            {
                string nuevaCadena = cadena.Substring(indicesLista[indice], indicesLista[indice + 1] - indicesLista[indice]);
                picada.Add(nuevaCadena);
            }

            return picada;
        }

        public static void PrintCadenaPicada(List<string> cadenaPicada)
        {
            foreach(var el in cadenaPicada)
                Console.Write(el + " ");
            Console.WriteLine();
        }

        public static bool Resuelve(string patron, List<string> cadenaPicada, int indicePatron, int indiceCadena, ref int cantidad)
        {
            if(indiceCadena >= cadenaPicada.Count)
            {
                cantidad++;
                return true;
            }
            for(int indice = indicePatron; indice < patron.Length; indice++)
            {
                if (patron[indice] == '!' && cadenaPicada[indiceCadena].Length == 1)
                {
                    if (!Resuelve(patron, cadenaPicada, indice + 1, indiceCadena + 1, ref cantidad))
                        return false;
                    
                }
                else if (patron[indice] == '+' && cadenaPicada[indiceCadena].Length >= 1)
                {
                    if (!Resuelve(patron, cadenaPicada, indice + 1, indiceCadena + 1, ref cantidad))
                        return false;
                   
                }
                else if (("qwertyuioplkjhgfdsazxcvbnmñ".Contains(patron[indice]) || "QWERTYUIOPLKJHGFDSAZXCVBNMÑ".Contains(patron[indice]))
                    && cadenaPicada[indiceCadena] == patron[indice].ToString())
                {
                    if (!Resuelve(patron, cadenaPicada, indice + 1, indiceCadena + 1, ref cantidad))
                        return false;
                    
                }
                else if (patron[indice] == '*' && cadenaPicada[indiceCadena].Length >= 0)
                {
                    if (!Resuelve(patron, cadenaPicada, indice + 1, indiceCadena + 1, ref cantidad))
                        return false;
                    continue;
                }
                else if (patron[indice] == '?' && cadenaPicada[indiceCadena].Length <= 1)
                {
                    if (!Resuelve(patron, cadenaPicada, indice + 1, indiceCadena + 1, ref cantidad))
                        return false;
                    continue;
                }
                else
                    return false;
                break;                 
            }
            return true;

        }
    }
}
