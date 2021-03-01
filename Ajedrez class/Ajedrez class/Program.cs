using System;
using System.Collections.Generic;

namespace Ajedrez_class
{
    class Program
    {
        static void Main(string[] args)
        {

            Tablero myTablero = new Tablero();

            myTablero.ColocaPieza(new Pieza(TipoPieza.Dama, ColorPieza.Negra), new Casilla(2, 5));
            myTablero.ColocaPieza(new Pieza(TipoPieza.Torre, ColorPieza.Blanca), new Casilla(3, 6));
            myTablero.ColocaPieza(new Pieza(TipoPieza.Torre, ColorPieza.Blanca), new Casilla(4, 3));
            myTablero.ColocaPieza(new Pieza(TipoPieza.Torre, ColorPieza.Blanca), new Casilla(5, 6));
            myTablero.ColocaPieza(new Pieza(TipoPieza.Dama, ColorPieza.Negra), new Casilla(6, 3));
            myTablero.ColocaPieza(new Pieza(TipoPieza.Alfil, ColorPieza.Negra), new Casilla(0, 0));


            foreach (var el in myTablero.PuedenMoverseHacia(new Casilla(4, 5)))  
            {
                Console.WriteLine(el.Fila);
                Console.WriteLine(el.Columna);
                Console.WriteLine();
            }

            //Console.WriteLine(myTablero.CantidadDeAmenazadas(ColorPieza.Blanca));
            //Console.WriteLine();

            //foreach (var el in myTablero.PiezasQueMasAmenazan)
            //{
            //    Console.WriteLine(el.Fila);
            //    Console.WriteLine(el.Columna);
            //    Console.WriteLine();
            //}
            //myTablero.ImprimeTablero();
            //myTablero.MuevePieza(new Casilla(6, 3), new Casilla(3, 6));
            //Console.WriteLine();
            //myTablero.ImprimeTablero();

            //Console.WriteLine();

            //Console.WriteLine(myTablero.PuedeMoverse(new Casilla(4, 3), new Casilla(0, 3)));
            //Console.WriteLine(myTablero.PuedeMoverse(new Casilla(0, 0), new Casilla(4, 4)));

            //Console.WriteLine();

            //Console.WriteLine(myTablero.PuedeMoverse(new Casilla(2, 5), new Casilla(0, 4)));
            //Console.WriteLine(myTablero.PuedeMoverse(new Casilla(2, 5), new Casilla(0, 7)));
        }
        public enum ColorPieza { Blanca, Negra};
        public enum TipoPieza { Alfil, Dama, Torre};
        public class Casilla
        {
            public Casilla(int fila, int columna)
            {
                Fila = fila;
                Columna = columna;
            }
            public int Fila { get; set; }
            public int Columna { get; set; }
        }
        public class Pieza
        {
            public Pieza(TipoPieza tipo, ColorPieza color)
            {
                Tipo = tipo;
                Color = color;
            }
            public TipoPieza Tipo { get; }
            public ColorPieza Color { get; }
        }
        public interface ITableroAjedrez
        {
            /// <summary>
            /// Coloca una pieza en un casilla específica del tablero.
            /// Si la casilla está ocupada lanza InvalidOperationException.
            /// </summary>
            void ColocaPieza(Pieza pieza, Casilla casilla);
            /// <summary>
            /// Devuelve si la pieza que está en una casilla de origen
            /// puede moverse a una casilla destino.
            /// Si no existe una pieza en la casilla origen
            /// lanza InvalidOperationException.
            /// Note que una pieza puede moverse a una casilla ocupada si
            /// se la puede comer.
            /// </summary>
            bool PuedeMoverse(Casilla casillaOrigen, Casilla casillaDestino);
            /// <summary>
            /// Mueve la pieza de una casilla origen a una destino.
            /// De existir una pieza de distinto color en la casilla destino se
            /// comerá a ésta
            /// Si no existe una pieza en la casilla de origen o no se
            /// puede efectuar el movimiento lanza InvalidOperationException.
            /// </summary>
            void MuevePieza(Casilla casillaOrigen, Casilla casillaDestino);
            /// <summary>
            /// Devuelve todas las casillas en las que hay piezas que pueden
            /// moverse hacia una casilla
            /// determinada.
            /// Note que puede que sea vacío el iterador.
            /// </summary>
            IEnumerable<Casilla> PuedenMoverseHacia(Casilla casilla);
            /// <summary>
            /// Devuelve la cantidad de piezas de un color determinado
            /// que son amenazadas.
            /// </summary>
            int CantidadDeAmenazadas(ColorPieza color);
            /// <summary>
            /// Devuelve las casillas en las que hay piezas que son amenazadas.
            /// Note que el iterador puede ser vacío
            /// una colección vacia.
            /// </summary>
            IEnumerable<Casilla> Amenazadas { get; }
            /// <summary>
            /// Devuelve el conjunto de casillas en las que están las piezas
            /// que amenazan la mayor cantidad
            /// de piezas enemigas.
            /// Esto es, el conjunto de piezas sobre el tablero tal que
            /// no exista otra que amenace a más piezas que las del conjunto.
            /// Note que si ninguna pieza amenaza a otra,
            /// el resultado serían todas las piezas sobre el tablero,
            /// ya que todas amenazan a 0 piezas.
            /// De no existir piezas en el tablero el iterador será vacío.
            /// </summary>
            IEnumerable<Casilla> PiezasQueMasAmenazan { get; }
            /// <summary>
            /// Devuelve la pieza situada en la casilla especificada.
            /// Si no existe una pieza en la casilla, devuelve null.
            /// </summary>
            Pieza this[Casilla casilla] { get; }
        }

        public class Tablero : ITableroAjedrez
        {
            Pieza[,] tablero;
            public Tablero()
            {
                this.tablero = new Pieza[8, 8];
            }
            public Pieza this[Casilla casilla]  // ok
            {
                get
                {
                    return this.tablero[casilla.Fila, casilla.Columna];
                }
            }

            public IEnumerable<Casilla> Amenazadas  // ok
            {
                get
                {
                    return PiezasAmenazadas();
                }
            }
            List<Casilla> PiezasAmenazadas()    // ok
            {
                List<Casilla> amenazadas = new List<Casilla>();
                int[] movFila;
                int[] movColumna;
                for(int primerIndice = 0; primerIndice < 8; primerIndice++)
                {
                    for(int segundoIndice = 0; segundoIndice < 8; segundoIndice++)
                    {
                        if (this.tablero[primerIndice, segundoIndice] != null)
                        {
                            if (this.tablero[primerIndice, segundoIndice].Tipo == TipoPieza.Alfil)
                            {
                                movFila = new int[] { -1, 1, 1, -1 };
                                movColumna = new int[] { 1, 1, -1, -1 };
                            }
                            else if (this.tablero[primerIndice, segundoIndice].Tipo == TipoPieza.Torre)
                            {
                                movFila = new int[] { -1, 0, 1, 0 };
                                movColumna = new int[] { 0, 1, 0, -1 };
                            }
                            else
                            {
                                movFila = new int[] { -1, 1, 1, -1, -1, 0, 1, 0 };
                                movColumna = new int[] { 1, 1, -1, -1, 0, 1, 0, -1 };
                            }
                            for (int indice = 0; indice < movFila.Length; indice++)
                            {
                                int nuevaFila = primerIndice + movFila[indice];
                                int nuevaColumna = segundoIndice + movColumna[indice];

                                while (EsValida(nuevaFila, nuevaColumna))
                                {
                                    if (this.tablero[nuevaFila, nuevaColumna] != null && 
                                            this.tablero[nuevaFila, nuevaColumna].Color != this.tablero[primerIndice, segundoIndice].Color)
                                    {
                                        bool esta = false;
                                        foreach (var el in amenazadas)
                                        {
                                            if (el.Fila == nuevaFila && el.Columna == nuevaColumna)
                                                esta = true;
                                        }
                                        if (!esta)
                                        {
                                            amenazadas.Add(new Casilla(nuevaFila, nuevaColumna));
                                            break;
                                        }
                                    }
                                    else if (this.tablero[nuevaFila, nuevaColumna] != null && 
                                                this.tablero[nuevaFila, nuevaColumna].Color == this.tablero[primerIndice, segundoIndice].Color)
                                        break;

                                    nuevaFila += movFila[indice];
                                    nuevaColumna += movColumna[indice];
                                }
                            }
                        }
                    }
                }
                return amenazadas;
            }   
            bool EsValida(int fila, int columna)    // ok
            {
                return fila >= 0 && columna >= 0 && fila < 8 && columna < 8;
            }
            public IEnumerable<Casilla> PiezasQueMasAmenazan    // ok
            {
                get
                {
                    List<Casilla> piezas = new List<Casilla>();
                    int maximo = 0;

                    for(int primerIndice = 0; primerIndice < 8; primerIndice++)
                    {
                        for(int segundoIndice = 0; segundoIndice < 8; segundoIndice++)
                        {
                            if(tablero[primerIndice, segundoIndice] != null)
                            {
                                int cantidad = CantidadPiezasQueAmenaza(new Casilla(primerIndice, segundoIndice));
                                if(cantidad == maximo)
                                {
                                    piezas.Add(new Casilla(primerIndice, segundoIndice));
                                }
                                else if (cantidad > maximo)
                                {
                                    maximo = cantidad;
                                    piezas = new List<Casilla>();
                                    piezas.Add(new Casilla(primerIndice, segundoIndice));
                                }
                            }
                        }
                    }
                    return piezas;

                }
            }
            int CantidadPiezasQueAmenaza(Casilla pieza) // ok
            {
                int[] movFila;
                int[] movColumna;
                int cantidad = 0;

                if (this.tablero[pieza.Fila, pieza.Columna].Tipo == TipoPieza.Alfil)
                {
                    movFila = new int[] { -1, 1, 1, -1 };
                    movColumna = new int[] { 1, 1, -1, -1 };
                }
                else if (this.tablero[pieza.Fila, pieza.Columna].Tipo == TipoPieza.Torre)
                {
                    movFila = new int[] { -1, 0, 1, 0 };
                    movColumna = new int[] { 0, 1, 0, -1 };
                }
                else
                {
                    movFila = new int[] { -1, 1, 1, -1, -1, 0, 1, 0 };
                    movColumna = new int[] { 1, 1, -1, -1, 0, 1, 0, -1 };
                }

                for (int indice = 0; indice < movFila.Length; indice++)
                {
                    int nuevaFila = pieza.Fila + movFila[indice];
                    int nuevaColumna = pieza.Columna + movColumna[indice];

                    while (EsValida(nuevaFila, nuevaColumna))
                    {
                        if (this.tablero[nuevaFila, nuevaColumna] != null && this.tablero[nuevaFila, nuevaColumna].Color != this.tablero[pieza.Fila, pieza.Columna].Color)
                        {
                            cantidad++;
                            break;
                        }
                        else if (this.tablero[nuevaFila, nuevaColumna] != null && this.tablero[nuevaFila, nuevaColumna].Color == this.tablero[pieza.Fila, pieza.Columna].Color)
                            break;

                        nuevaFila += movFila[indice];
                        nuevaColumna += movColumna[indice];
                    }
                }
                return cantidad; 

            }   

            public int CantidadDeAmenazadas(ColorPieza color)   // ok
            {
                List<Casilla> amenazadas = PiezasAmenazadas();

                int cantidad = 0;

                foreach(var el in amenazadas)
                {
                    if (this.tablero[el.Fila, el.Columna].Color == color)
                        cantidad++;
                }
                return cantidad;
                
            }

            public void ColocaPieza(Pieza pieza, Casilla casilla)   //ok
            {
                if (this.tablero[casilla.Fila, casilla.Columna] != null)
                    throw new InvalidOperationException();

                this.tablero[casilla.Fila, casilla.Columna] = pieza;
            }

            public void MuevePieza(Casilla casillaOrigen, Casilla casillaDestino)   // ok
            {
                if(this.tablero[casillaOrigen.Fila, casillaOrigen.Columna] == null) throw new InvalidOperationException();
                if (this.tablero[casillaDestino.Fila, casillaDestino.Columna].Color == this.tablero[casillaOrigen.Fila, casillaOrigen.Columna].Color)
                    throw new InvalidOperationException();
                this.tablero[casillaDestino.Fila, casillaDestino.Columna] = this.tablero[casillaOrigen.Fila, casillaOrigen.Columna];
                this.tablero[casillaOrigen.Fila, casillaOrigen.Columna] = null;
            }

            public bool PuedeMoverse(Casilla casillaOrigen, Casilla casillaDestino) // ok
            {
                if (this.tablero[casillaOrigen.Fila, casillaOrigen.Columna] == null) throw new InvalidOperationException();

                if (this.tablero[casillaOrigen.Fila, casillaOrigen.Columna].Tipo == TipoPieza.Torre)
                    return casillaOrigen.Fila == casillaDestino.Fila || casillaOrigen.Columna == casillaDestino.Columna;
                else if (this.tablero[casillaOrigen.Fila, casillaOrigen.Columna].Tipo == TipoPieza.Alfil)
                    return Math.Abs(casillaOrigen.Fila - casillaDestino.Fila) == Math.Abs(casillaOrigen.Columna - casillaDestino.Columna);
                
                return (casillaOrigen.Fila == casillaDestino.Fila || casillaOrigen.Columna == casillaDestino.Columna) || (Math.Abs(casillaOrigen.Fila - casillaDestino.Fila) == Math.Abs(casillaOrigen.Columna - casillaDestino.Columna));

            }
            public void ImprimeTablero()
            {
                for(int primerIndice = 0; primerIndice < 8; primerIndice++)
                {
                    for (int segundoIndice = 0; segundoIndice < 8; segundoIndice++)
                    {
                        if (this.tablero[primerIndice, segundoIndice] == null)
                            Console.Write("\t null");
                        else
                        {
                            Console.Write("\t"+this.tablero[primerIndice, segundoIndice].Tipo);
                            Console.Write(this.tablero[primerIndice, segundoIndice].Color);
                        }
                    }
                    Console.WriteLine();
                }
            }

            public IEnumerable<Casilla> PuedenMoverseHacia(Casilla casilla) // ok
            {
                List<Casilla> amenazadas = new List<Casilla>();

                int[] movFila = new int[] { -1, 0, 1, 0};
                int[] movColumna = new int[] { 0, 1, 0, -1 };

                for(int indice = 0; indice < movFila.Length; indice++)
                {
                    int nuevaFila = casilla.Fila + movFila[indice];
                    int nuevaColumna = casilla.Columna + movColumna[indice];

                    while(EsValida(nuevaFila, nuevaColumna))
                    {
                        if(this.tablero[nuevaFila, nuevaColumna] != null && (this.tablero[nuevaFila, nuevaColumna].Tipo == TipoPieza.Torre || 
                                this.tablero[nuevaFila, nuevaColumna].Tipo == TipoPieza.Dama))
                        {
                            amenazadas.Add(new Casilla(nuevaFila, nuevaColumna));
                            break;
                        }
                        nuevaFila += movFila[indice];
                        nuevaColumna += movColumna[indice];
                    }
                }
                movFila = new int[] { -1, -1, 1, 1 };
                movColumna = new int[] {-1, 1, 1, -1 };

                for (int indice = 0; indice < movFila.Length; indice++)
                {
                    int nuevaFila = casilla.Fila + movFila[indice];
                    int nuevaColumna = casilla.Columna + movColumna[indice];

                    while (EsValida(nuevaFila, nuevaColumna))
                    {
                        if (this.tablero[nuevaFila, nuevaColumna] != null && (this.tablero[nuevaFila, nuevaColumna].Tipo == TipoPieza.Alfil ||
                                this.tablero[nuevaFila, nuevaColumna].Tipo == TipoPieza.Dama))
                        {
                            amenazadas.Add(new Casilla(nuevaFila, nuevaColumna));
                            break;
                        }
                        nuevaFila += movFila[indice];
                        nuevaColumna += movColumna[indice];
                    }
                }

                return amenazadas;
            }
        }
    }
}
