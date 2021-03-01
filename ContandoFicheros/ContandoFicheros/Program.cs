using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContandoFicheros
{
    class Program
    {
        class Directorio
        {
            Directorio[] subDirectorios;
            public Directorio[] SubDirectorios
            {
                get { return subDirectorios; }
                set { subDirectorios = value; }
            }
            string[] ficheros;
            public string[] Ficheros
            {
                get { return ficheros; }
                set { ficheros = value; }
            }
            public Directorio(Directorio[] subDirectorios, string[] ficheros)
            {
                SubDirectorios = subDirectorios;
                Ficheros = ficheros;
            }
            public Directorio()
            {
                SubDirectorios = new Directorio[0];
                Ficheros = new string[0];
            }
        }
        static void Main(string[] args)
        {
            Directorio lost = new Directorio(new Directorio[0],
            new string[]{"cap1.avi", "cap2.avi"});
            Directorio house = new Directorio(new Directorio[0],
            new string[]{"cap10.avi", "cap10.srt"});
            Directorio series = new Directorio(new Directorio[] { lost, house }, new string[0]);
            Directorio films = new Directorio(new Directorio[0],
            new string[] {"Avatar.avi", "Nine.avi", "2012.avi"});
            Directorio downloaded_media = new Directorio();
            Directorio media = new Directorio(new Directorio[] {series, films, downloaded_media}, new string[0]);


            Console.WriteLine(CuentaFicheros(media));
        }
        static int CuentaFicheros(Directorio directorio)
        {
            int cuantos = 0;

            CuentaFicheros(directorio, ref cuantos);

            return cuantos;
        }
        static void CuentaFicheros(Directorio myDirecctorio, ref int cantidad)
        {
            cantidad += myDirecctorio.Ficheros.Length;

            for(int indice = 0; indice < myDirecctorio.SubDirectorios.Length; indice++)
            {
                CuentaFicheros(myDirecctorio.SubDirectorios[indice], ref cantidad);
            }

     
        }
    }
}
