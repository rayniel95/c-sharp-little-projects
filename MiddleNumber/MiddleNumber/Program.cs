using System;

namespace MiddleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un número");

            int number_one = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe un segundo número");

            int number_two = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe un tercer número");

            int number_tree = int.Parse(Console.ReadLine());

            int max = number_one;
            int min = number_one;

            if (number_two > max)
                max = number_two;
            else if (number_tree > max)
                max = number_tree;

            if (number_two < min)
                min = number_two;
            else if (number_tree < min)
                min = number_tree;

            Console.WriteLine("El máximo es " + max);
            Console.WriteLine("El mínimo es " + min);


            Console.WriteLine(((number_one + number_two + number_tree) / 3.0) + " Es el promedio");
        }
    }
}
