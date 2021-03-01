using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CercandoIslas_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //bool[,] mapa =
            //{
            //    {false, false, false, false, false, false, false, false, false },
            //    {false, true, false, false, false, false, false, false, false },
            //    {false, true, true, false, false, true, true, false, false },
            //    {false, false, false, false, false, false, false, false, false },
            //    {false, false, false, false, false, false, true, true, true },
            //    {false, false, true, false, false, false, false, true, false },
            //    {false, false, false, false, false, false, false, false, false },
            //};

            //Rectangulo mejor = CercoMinimo(mapa);
            //if (mejor == null)
            //{
            //    Console.WriteLine("null");
            //}
            //else
            //{
            //    Console.WriteLine("x " + mejor.Punto.CoorX);
            //    Console.WriteLine("y " + mejor.Punto.CoorY);
            //    Console.WriteLine("ancho " + mejor.Ancho);
            //    Console.WriteLine("largo " + mejor.Largo);
            //}

            #endregion
            #region Prueba2
            //bool[,] mapa =
            //{
            //    {false, false, false, false, false, false },
            //    {false, false, false, false, false, false },
            //    {false, false, false, false, false, false },
            //    {false, false, true, false, false, false },
            //    {false, false, false, false, false, false },
            //};

            //Rectangulo mejor = CercoMinimo(mapa);
            //if (mejor == null)
            //{
            //    Console.WriteLine("null");
            //}
            //else
            //{
            //    Console.WriteLine("x " + mejor.Punto.CoorX);
            //    Console.WriteLine("y " + mejor.Punto.CoorY);
            //    Console.WriteLine("ancho " + mejor.Ancho);
            //    Console.WriteLine("largo " + mejor.Largo);
            //}

            #endregion
            #region Prueba3
            //bool[,] mapa =
            //{
            //    {false, false, false, false, false, false },
            //    {false, true, true, false, true, true },
            //    {false, true, false, false, false, true },
            //    {false, true, true, false, true, true },
            //    {false, false, false, false, false, false }
            //};

            //Rectangulo mejor = CercoMinimo(mapa);
            //if (mejor == null)
            //{
            //    Console.WriteLine("null");
            //}
            //else
            //{
            //    Console.WriteLine("x " + mejor.Punto.CoorX);
            //    Console.WriteLine("y " + mejor.Punto.CoorY);
            //    Console.WriteLine("ancho " + mejor.Ancho);
            //    Console.WriteLine("largo " + mejor.Largo);
            //}

            #endregion


        }
        public static Rectangulo CercoMinimo(bool[,] tablero)
        {
            int cantidadIslas = 0;
            int[,] mapa = ModificaMapa(tablero, out cantidadIslas);

            Rectangulo mejor = new Rectangulo(new Punto(0, 0), 5000, int.MaxValue / 5000);

            for(int primerIndice = 0; primerIndice < mapa.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < mapa.GetLength(1); segundoIndice++)
                {
                    Comprueba(mapa, new Rectangulo(new Punto(0, 0), 0, 0), ref mejor, cantidadIslas, primerIndice, segundoIndice);
                }
            }
            if (mejor.Ancho == int.MaxValue && mejor.Largo == int.MaxValue) return null;
            return mejor;
        }
        public static void Comprueba(int[,] mapa, Rectangulo rectanguloActual, ref Rectangulo mejor, int islas, int fila, int columna)
        {
            if(TodosEnCerco(mapa, rectanguloActual, islas))
            {
                if (rectanguloActual.Largo * rectanguloActual.Ancho < mejor.Largo * mejor.Ancho)
                    mejor = new Rectangulo(new Punto(rectanguloActual.Punto.CoorX, rectanguloActual.Punto.CoorY), 
                        rectanguloActual.Ancho, rectanguloActual.Largo);
                return;
            }
            else
            {
                if(rectanguloActual.Punto.CoorX + rectanguloActual.Ancho + 1 < mapa.GetLength(0))
                {
                    Comprueba(mapa, new Rectangulo(new Punto(fila, columna), rectanguloActual.Ancho + 1, rectanguloActual.Largo), ref mejor, islas, fila, columna);
                }
                if (rectanguloActual.Punto.CoorY + rectanguloActual.Largo + 1 < mapa.GetLength(1))
                {
                    Comprueba(mapa, new Rectangulo(new Punto(fila, columna), rectanguloActual.Ancho, rectanguloActual.Largo + 1), ref mejor, islas, fila, columna);
                }
            }

        }
        public static bool TodosEnCerco(int[,] tablero, Rectangulo rectangulo, int cantidadIslas)
        {
            List<int> islas = new List<int>();

            for(int fila = rectangulo.Punto.CoorX; fila <= rectangulo.Punto.CoorX + rectangulo.Ancho - 1; fila++)
            {
                for(int columna = rectangulo.Punto.CoorY; columna <= rectangulo.Punto.CoorY + rectangulo.Largo - 1; columna++)
                {
                    if (tablero[fila, columna] > 0 && !islas.Contains(tablero[fila, columna]))
                        islas.Add(tablero[fila, columna]);
                }
            }
            if (islas.Count == cantidadIslas) return true;
            return false;
        }
        public static int[,] ModificaMapa(bool[,] mapa, out int cantidad)
        {
            int[] filaMov = { -1, 0, 1, 0 };
            int[] columnaMov = { 0, 1, 0, -1 };

            int[,] nuevoMapa = new int[mapa.GetLength(0), mapa.GetLength(1)];

            int isla = 0;

            for(int primerIndice = 0; primerIndice < mapa.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < mapa.GetLength(1); segundoIndice++)
                {
                    if(mapa[primerIndice, segundoIndice] && nuevoMapa[primerIndice, segundoIndice] == 0)
                    {
                        isla++;
                        Marca(nuevoMapa, mapa, isla, primerIndice, segundoIndice, filaMov, columnaMov);
                        
                    }
                }
            }
            cantidad = isla;
            return nuevoMapa;
        }
        public static void Marca(int[,] mapa, bool[,] mapaBool, int numero, int fila, int columna, int[] movFila, int[] movColumna)
        {
            
            mapa[fila, columna] = numero;

            for(int indice = 0; indice < movFila.Length; indice++)
            {
                int nuevaFila = fila + movFila[indice];
                int nuevaColumna = columna + movColumna[indice];

                if(EsValido(mapa, nuevaFila, nuevaColumna) && mapaBool[nuevaFila, nuevaColumna] && mapa[nuevaFila, nuevaColumna] == 0)
                {
                    Marca(mapa, mapaBool, numero, nuevaFila, nuevaColumna, movFila, movColumna);
                }
            }
        }
        public static bool EsValido(int[,] matrix, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < matrix.GetLength(0) && columna < matrix.GetLength(1); }

        public class Rectangulo
        {
            public Rectangulo(Punto punto, int ancho, int largo)
            {
                Punto = punto;
                Ancho = ancho;
                Largo = largo;
            }
            public Punto Punto { get; set; }
            public int Ancho { get; set; }
            public int Largo { get; set; }
        }
        public class Punto
        {
            public Punto(int coorX, int coorY)
            {
                CoorX = coorX;
                CoorY = coorY;
            }
            public int CoorX { get; set; }
            public int CoorY { get; set; }
        }
    }
}
