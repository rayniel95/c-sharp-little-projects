using System;

namespace EvaluaPolinomio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Evalua(new int[] {1, 0, -5, 3}, 2));
        }
        static int Evalua(int [] polinomio, int numero)
        {
            double numer = (double) numero;
            double potencia = (double) (polinomio.Length - 1);
            double evalua = (double) 0;

            for(int index = 0; polinomio.Length >  index; index++)
            {
                evalua += Math.Pow(numer, potencia) * polinomio[index];
                potencia--;
             }
            return (int) evalua;
        }
    }
}
