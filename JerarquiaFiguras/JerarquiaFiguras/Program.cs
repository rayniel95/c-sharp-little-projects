using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerarquiaFiguras
{
    public interface ICloneable<T>
    {
        T Clone();
    }
    public abstract class Figura : ICloneable<Figura>
    {
        public abstract double Perimetro { get; }
        public abstract double Area { get; }
        public abstract Figura Clone();
    }
    public class Rectangulo : Figura
    {
        protected double ladoMenor;
        protected double ladoMayor;

        public Rectangulo(double longitudMenor, double longitudMayor)
        {
            if (longitudMayor <= 0 || longitudMenor <= 0)
                throw new Exception("Parametros fuera del rango establecido");
            this.ladoMenor = longitudMenor;
            this.ladoMayor = longitudMayor;
        }
        public double LongitudMenor
        { get { return this.ladoMenor; } }
        public double LongitudMayor
        { get { return this.ladoMayor; } }
        public override double Area
        {
            get { return this.ladoMayor * this.ladoMenor; }
        }
        public override double Perimetro
        {
            get { return 2 * this.ladoMenor + 2 * this.ladoMayor; }
        }
        public override Figura Clone()
        {
            return new Rectangulo(this.ladoMenor, this.ladoMayor);
        }
        public override bool Equals(object obj)
        {
            Rectangulo myRect = obj as Rectangulo;
           
            if (myRect == null)
                return false;

            return myRect.LongitudMayor == this.ladoMayor && myRect.LongitudMenor == this.ladoMenor;
        }
    }
    public class Circulo : Figura
    {
        protected double radio;
        public Circulo(double radio)
        {
            if (radio <= 0)
                throw new Exception("Parametros fuera del rango establecido");
            this.radio = radio;
        }
        public double Radio
        {
            get { return this.radio; }
        }
        public override double Area
        {
            get { return Math.PI * Math.Pow(this.radio, 2); }
        }
        public override double Perimetro
        {
            get { return 2 * Math.PI * this.radio; }
        }
        public override Figura Clone()
        {
            return new Circulo(this.radio);
        }
        public override bool Equals(object obj)
        {
            Circulo myCirc = obj as Circulo;
            if (myCirc == null)
                return false;
            return myCirc.Radio == this.radio;
        }
    }
    public class Cuadrado : Figura
    {
        protected double lado;
        public Cuadrado(double lado)
        {
            if (lado <= 0) throw new Exception("Parametros fuera del rango establecido");
            this.lado = lado;
        }
        public double Lado { get { return this.lado; } }
        public override double Area
        {
            get { return Math.Pow(this.lado, 2); }
        }
        public override double Perimetro
        {
            get { return 4 * this.lado; }
        }
        public override Figura Clone()
        {
            return new Cuadrado(this.lado);
        }
        public override bool Equals(object obj)
        {
            Cuadrado cuadro = obj as Cuadrado;

            if (cuadro == null)
                return false;
            return cuadro.Lado == this.lado;
        }
    }
    public class CuadradoAmpliable : Cuadrado
    {
        public CuadradoAmpliable(double lado) : base(lado) {}
        public virtual void Amplia()
        { this.lado = this.lado * 2; }
        public override Figura Clone()
        {
            return new CuadradoAmpliable(this.lado);
        }
    }
    public class SectorCircular : Circulo
    {
        int grados;
        public SectorCircular(double radio, int grados) : base(radio) 
        {
            if (grados <= 0 || grados > 360)
                throw new Exception("Parametro fuera del limite establecido");
            this.grados = grados; 
        }
        public override double Area
        {
            get
            {
                return Math.Pow(this.radio, 2) * this.grados / 2;
            }
        }
        public override double Perimetro
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public override Figura Clone()
        {
            return new SectorCircular(this.radio, this.grados);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangulo rect = new Rectangulo(4, 5);
            Rectangulo myRect = new Rectangulo(3, 5);

            Console.WriteLine(rect.Equals(myRect));
        }
    }
}
