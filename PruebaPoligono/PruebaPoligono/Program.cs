using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPoligono
{
    class Punto
    {
        int coorX;
        int coorY;

        public Punto(int coorX, int coorY)
        {
            this.coorX = coorX;
            this.coorY = coorY;
        }
        public int CoordenadaX
        {
            get
            {
                return this.coorX;
            }
        }
        public int CoordenadaY
        {
            get
            {
                return this.coorY;
            }
        }
    }
    class Poligono
    {
        Punto[] vertices;

        public Poligono(Punto[] vertices)
        {
            this.vertices = new Punto[vertices.Length];

            Array.Copy(vertices, this.vertices, vertices.Length);
        }
        public virtual double Area()
        {
            return 0;
        }
        public virtual double Perimetro()
        {
            return 0;
        }
    }
    class Segmento
    {
        Punto inicio;
        Punto extremo;

        public Segmento(Punto inicio, Punto extremo)
        {
            this.inicio = inicio;
            this.extremo = extremo;
        }
        public double Longitud
        {
            get
            {
                double longitud = Math.Sqrt(Math.Pow(this.inicio.CoordenadaX + this.extremo.CoordenadaX, 2) + Math.Pow(this.inicio.CoordenadaY + this.extremo.CoordenadaY, 2));
                return longitud;
            }
        }
    }
    class Rectangulo : Poligono
    {
        Punto[] vertices;
        public Rectangulo(Punto[] vertices) : base(vertices) {  }

        public override double Area()
        {
            Segmento primerLado = new Segmento(this.vertices[0], this.vertices[1]);

            Segmento segundoLado = new Segmento(this.vertices[1], this.vertices[2]);

            return primerLado.Longitud * segundoLado.Longitud;
        }
        public override double Perimetro()
        {
            Segmento primerLado = new Segmento(this.vertices[0], this.vertices[1]);

            Segmento segundoLado = new Segmento(this.vertices[1], this.vertices[2]);

            return 2 * primerLado.Longitud + 2 * segundoLado.Longitud;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Punto[] misVertices = { new Punto(1, 2), new Punto(3, 4), new Punto(5, 1), new Punto(1, 9) };

            Rectangulo myRect = new Rectangulo(misVertices);

            Console.WriteLine(myRect.Area());
            Console.WriteLine(myRect.Perimetro());
        }
    }
}
