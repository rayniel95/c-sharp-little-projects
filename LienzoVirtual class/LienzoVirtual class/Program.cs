using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LienzoVirtual_class
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Lienzo myLienzo = new Lienzo();

            myLienzo.AdicionaPuntos(new Point(0, 0));
            myLienzo.AdicionaPuntos(new Point(1, 1));
            myLienzo.AdicionaPuntos(new Point(5, 9));
            myLienzo.AdicionaPuntos(new Point(40, 34));
            myLienzo.AdicionaPuntos(new Point(6, 10));
            myLienzo.AdicionaPuntos(new Point(8, 12));
            myLienzo.AdicionaPuntos(new Point(7, 11));


            Lienzo lienzo = new Lienzo();
            //dibujo 1
            lienzo.AdicionaPuntos(new Point(5, 7), new Point(5, 8), new Point(5, 9),
            new Point(4, 9), new Point(4, 10));
            //dibujo 2
            lienzo.AdicionaPuntos(new Point(7, 8), new Point(7, 9));
            lienzo.AdicionaPuntos(new Point(8, 9), new Point(8, 10));
            //dibujo 3
            lienzo.AdicionaPuntos(new Point(10, 12), new Point(10, 13), new Point(10, 14),
            new Point(9, 13), new Point(11, 13));

            int i = 1;
            foreach (IEnumerable<Point> dibujo in lienzo.Dibujos())
            {
                Console.WriteLine("Figura {0}:", i++);
                foreach (Point p in dibujo)
                {
                    Console.WriteLine("({0};{1})", p.CoorX, p.CoorY);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Puntos del dibujo que contiene a (5,8):");
            foreach (Point p in lienzo.Dibujo(new Point(5, 8)))
            {
                Console.WriteLine("({0};{1})", p.CoorX, p.CoorY);
            }

            Console.WriteLine();
            lienzo.AdicionaPuntos(new Point(6, 8), new Point(9, 11));

            i = 1;
            foreach (IEnumerable<Point> dibujo in lienzo.Dibujos())
            {
                Console.WriteLine("Figura {0}:", i++);
                foreach (Point p in dibujo)
                {
                    Console.WriteLine("({0};{1})", p.CoorX, p.CoorY);
                }
            }

        }

        public class Point
        {
            public Point(int x, int y)
            {
                CoorX = x;
                CoorY = y;
            }
            public int CoorX
            { get; private set; }
            public int CoorY
            { get; private set; }
        }

        class Lienzo
        {
            class Punto:Point
            {
                public Punto(int x, int y) : base(x, y) { }
                public override bool Equals(object obj)
                {
                    Point punto = obj as Point;
                    if (punto == null) return false;
                    return punto.CoorX == this.CoorX && punto.CoorY == this.CoorY;
                }
            }
            class PuntosComparer : IComparer<Punto>
            {
                public int Compare(Punto x, Punto y)
                {
                    if (x.CoorX != y.CoorX)
                        return x.CoorX.CompareTo(y.CoorX);
                    return x.CoorY.CompareTo(y.CoorY);
                }
            }
            List<List<Punto>> dibujos;
            public Lienzo()
            {
                this.dibujos = new List<List<Punto>>();
            }

            public void AdicionaPuntos(params Point[] puntos)
            {
                if (puntos == null) throw new ArgumentException();
                foreach(var punto in puntos)
                {
                    Punto nuevo = new Punto(punto.CoorX, punto.CoorY);
                    int indice = EstaEnLienzo(nuevo);
                    if (indice != -1) continue;

                    List<Punto> nuevoDibujo = new List<Punto>();
                    nuevoDibujo.Add(nuevo);
                    List<List<Punto>> aEliminar = new List<List<Punto>>();
                    foreach(var dibu in this.dibujos)
                    {
                        foreach(var punt in dibu)
                        {
                            if(Math.Abs(punt.CoorX - nuevo.CoorX) <= 1 && Math.Abs(punt.CoorY - nuevo.CoorY) <= 1)
                            {
                                foreach(var other in dibu)
                                {
                                    nuevoDibujo.Add(other);
                                }
                                aEliminar.Add(dibu);
                                break;
                            }
                        }
                    }
                    foreach(var dibu in aEliminar)
                    {
                        for(int myIndice = 0; myIndice < this.dibujos.Count; myIndice++)
                        {
                            if (this.dibujos[myIndice] == dibu)
                            {
                                this.dibujos.RemoveAt(myIndice);
                                break;
                            }
                        }
                    }
                    nuevoDibujo.Sort(new PuntosComparer());
                    this.dibujos.Add(nuevoDibujo);
                }
            }
            public IEnumerable<Point> Dibujo(Point p)
            {
                if (p == null) throw new ArgumentNullException();
                int indice = EstaEnLienzo(new Punto(p.CoorX, p.CoorY));
                if (indice == -1) throw new ArgumentException();

                return this.dibujos[indice];
            }
            public IEnumerable<IEnumerable<Point>> Dibujos()
            {
                return this.dibujos;
            }
            int EstaEnLienzo(Punto punto)
            {
                for(int indice = 0; indice < this.dibujos.Count; indice++)
                {
                    if (this.dibujos[indice].Contains(punto))
                        return indice;
                }
                return -1;
            }
        }
    }
}
