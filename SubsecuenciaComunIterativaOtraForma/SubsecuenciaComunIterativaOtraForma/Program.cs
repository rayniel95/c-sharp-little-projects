using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsecuenciaComunIterativaOtraForma
{
    class Program
    {
        static void Main(string[] args)
        {
            SubsecuenciaComun("acaz", "aguabctea"); // hay que otra condicion para que funcione para las palabras que tengan 
                                                    // las letras repetidas
        }
        static List<char> SubsecuenciaComun(string string1, string string2)
        {
            List<char> mayor = new List<char>();

            for(int pivote = 0; pivote < string1.Length; pivote++)
            {
                List<char> subsecuencia = new List<char>();

                if (!EstaEnString(string1[pivote], string2))
                    continue;
                subsecuencia.Add(string1[pivote]);

                for(int indice = pivote + 1; indice <  string1.Length; indice++)
                {
                    if (EstaEnString(string1[indice], string2) && EstaDespues(string2, string1[pivote], string1[indice]))
                        subsecuencia.Add(string1[indice]);
                }
                if (subsecuencia.Count > mayor.Count)
                    mayor = subsecuencia;
            }
            return mayor;
        }
        static bool EstaEnString(char caracter, string cadena)
        {
            for(int indice = 0; indice < cadena.Length; indice++)
            {
                if (caracter == cadena[indice])
                    return true;
            }
            return false;
        }
        static bool EstaDespues(string palabra, char charPrimero, char charSegundo)
        {            
            int lugarPrimero = 0;
            int lugarSegundo = 0;

            for(int indice = 0; indice < palabra.Length; indice++)
            {
                if (palabra[indice] == charPrimero)
                {
                    lugarPrimero = indice;
                    break;
                }
            }
            for (int indice = palabra.Length; indice >= 0; indice--)
            {
                if (palabra[indice] == charSegundo)
                {
                    lugarSegundo = indice;
                    break;
                }
            }
            if (lugarSegundo > lugarPrimero)
                return true;
            return false;
        }
    }
}
