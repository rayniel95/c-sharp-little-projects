using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerCadenasPorLong_class
{
    public class LongitudComparer : IComparer<string>
    {
        public int Compare(string primera, string segunda)
        {
            return primera.Length.CompareTo(segunda.Length);
        }
    }
    public class ComparaIntPorCercania : IComparer<int>
    {
        int valor;
        public ComparaIntPorCercania(int valor) { this.valor = valor; }
        public int Compare(int primero, int segundo)
        {
            return Math.Abs(primero - this.valor).CompareTo(Math.Abs(segundo - this.valor));
        }
    }
    public class CadenasComparer : IComparer<string>
    {
        public int Compare(string primera, string segunda)
        {
            return primera.ToLower().CompareTo(segunda.ToLower());
        }
    }
    public class IntComparer : IComparer<int>
    {
        public int Compare(int primero, int segundo)
        {
            return primero.CompareTo(segundo);
        }
    }
    public interface ICloneable<T>
    {
        T Clone();
    }
    public class Punto: ICloneable<Punto>
    {
        int coorX;
        int coorY;
        public Punto(int coorX, int coorY)
        {
            this.coorX = coorX;
            this.coorY = coorY;
        }
        public int CoorX
        {
            get { return this.coorX; }
        }
        public int CoorY
        {
            get { return this.coorY; }
        }
        public Punto Clone()
        {
            return new Punto(this.coorX, this.coorY);
        }
        public override bool Equals(object obj)
        {
            Punto myPunto = obj as Punto;

            if (myPunto == null)
                throw new Exception("Parametro debe ser un punto o una instancia de una clase heredera");
            return myPunto.CoorX == this.CoorX && myPunto.CoorY == this.CoorY;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 3, 2, 5, 1, 0, 45 };
            Console.WriteLine(Minimo(myArray, new IntComparer()));
        }
        static int Minimo(int[] array, IComparer<int> comparador)
        {
            int minimo = int.MaxValue;

            for (int indice = 0; indice < array.Length; indice++)
            {
                if (comparador.Compare(array[indice], minimo) < 0)
                    minimo = array[indice];
            }
            return minimo;
        }
    }
}
