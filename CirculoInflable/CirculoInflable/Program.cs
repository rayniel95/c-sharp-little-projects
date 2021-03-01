using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirculoInflable
{
    class Circulo
    {
        int radio;

        public Circulo(int radio)
        {
            this.radio = radio;
        }
        public double Area()
        {
            double myRadio = this.radio;
            return Math.PI * Math.Pow(myRadio, 2);
        }
        public int Perimetro()
        {
            return 2 * this.radio;
        }
    }
    class CirculoInflable : Circulo
    {
        public CirculoInflable(int radio): base(radio){}

        public double Infla()
        {
            return this.Area() * 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circulo myCirco = new Circulo(3);

            Console.WriteLine(myCirco.Area());
            Console.WriteLine(myCirco.Perimetro());

            CirculoInflable myCircoInfla = new CirculoInflable(3);
            Console.WriteLine(myCircoInfla.Infla());
        }
    }
}
