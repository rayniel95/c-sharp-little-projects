using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoferEnFuga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CaminosDeFuga(5, 3, 2));
        }
        static int CaminosDeFuga(int fila, int columna, int maximoEnRecta)
        {
            int cantidad = 0;

            Moverse(0, 0, maximoEnRecta, fila, columna, ref cantidad, 0);

            return cantidad;
        }
        static void Moverse(int fila, int columna, int tope, int filaDestino, int columnaDestino, ref int cantidadDeCaminos, int recorridos)
        {
            if (fila == filaDestino && columna == columnaDestino)
                cantidadDeCaminos++;
        
            if (fila + 1 <= filaDestino)
                Moverse(fila + 1, columna, tope, filaDestino, columnaDestino, ref cantidadDeCaminos, 0);
            if (columna + 1 <= columnaDestino && recorridos < tope)
                Moverse(fila, columna + 1, tope, filaDestino, columnaDestino, ref cantidadDeCaminos, recorridos + 1);
        }
    }
}
