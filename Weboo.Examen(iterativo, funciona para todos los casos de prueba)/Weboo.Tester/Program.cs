using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen;

namespace Weboo.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Ejemplo 1
            int[] ej1 = { 1, 1, 2, 3, 2, 2 };
            int r1 = Constructora.MinNivelarParcela(ej1);
            ChequearRespuesta(3, r1, 1);

            //Ejemplo 2
            int[] ej2 = { 2, 2, 4, 3, 4, 1, 1 };
            int r2 = Constructora.MinNivelarParcela(ej2);
            ChequearRespuesta(6, r2, 2);

            //Ejemplo 3
            int[] ej3 = { 3, 3, 3, 3 };
            int r3 = Constructora.MinNivelarParcela(ej3);
            ChequearRespuesta(0, r3, 3);

            //Ejemplo 4
            int[] ej4 = { 1, 1, 1, 2, 2, 1, 1, 2 };
            int r4 = Constructora.MinNivelarParcela(ej4);
            ChequearRespuesta(2, r4, 4);
        }

        /// <summary>
        /// Imprime el resultado de un test
        /// </summary>
        /// <param name="correcta">Respuesta esperada para el test</param>
        /// <param name="respuesta">Respuesta a chequear con la correcta</param>
        /// <param name="caso">Numero del test</param>
        private static void ChequearRespuesta(int correcta, int respuesta, int caso)
        {
            Console.WriteLine("Caso de Ejemplo {0}.", caso);
            if (respuesta == correcta)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correcto");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrecto. Se esperaba {0} y se obtuvo {1}.", correcta, respuesta);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
