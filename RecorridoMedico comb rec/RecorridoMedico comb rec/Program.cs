using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorridoMedico_comb_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1
            //int[,] matriz =
            //{
            //    {0, 2, 0 },
            //    {0, 1, 2 },
            //    {2, 0, 1 }
            //};

            //Console.WriteLine(MinimaCantidadMedicos(matriz, 1));

            #endregion
            #region Prueba2

            //int[,] mapa =
            //{
            //    {1, 2, 0, 0, 2, 0, 0 },
            //    {0, 0, 0, 1, 0, 0, 0 },
            //    {0, 0, 2, 0, 2, 0, 0 },
            //    {0, 0, 0, 0, 0, 1, 0 }
            //};

            //Console.WriteLine(MinimaCantidadMedicos(mapa, 1));

            #endregion
            #region Prueba3

            //int[,] mapa =
            //{
            //    {0, 2, 0 },
            //    {0, 2, 2 },
            //    {2, 0, 1 }
            //};

            //Console.WriteLine(MinimaCantidadMedicos(mapa, 1));

            #endregion
            #region Prueba4

            //int[,] mapa =
            //{
            //    {0, 2, 0 },
            //    {0, 2, 2 },
            //    {2, 0, 1 }
            //};

            //Console.WriteLine(MinimaCantidadMedicos(mapa, 2));

            #endregion


        }
        public static int MinimaCantidadMedicos(int[,] mapa, int radioMedico)
        {
            int medico = 0;
            int paciente = 0;

            for(int primerIndice = 0; primerIndice < mapa.GetLength(0); primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < mapa.GetLength(1); segundoIndice++)
                {
                    if(mapa[primerIndice, segundoIndice] == 1)
                    {
                        medico--;
                        mapa[primerIndice, segundoIndice] = medico;
                        
                    }
                    else if(mapa[primerIndice, segundoIndice] == 2)
                    {
                        paciente++;
                        mapa[primerIndice, segundoIndice] = paciente;
                        
                    }
                }
            }

            List<int> medicos = new List<int>();

            for(int numeroMedico = -1; numeroMedico >= medico; numeroMedico--)
            {
                medicos.Add(numeroMedico);
            }

            for(int veces = 1; veces <= medicos.Count; veces++)
            {
                int cantidad = Recorrido(medicos.ToArray(), new int[veces], 0, 0, radioMedico, mapa, paciente);
                if (cantidad != -1) return cantidad;
            }
            return -1;
        }

        public static int Recorrido(int[] medicos, int[] subConjunto, int posMedicos, int posSubConjunto, int radio, int[,] matrix, int cantidadPacientes)
        {
            if (posSubConjunto == subConjunto.Length)
            {

                if (SeAlcanzanTodos(matrix, subConjunto, radio, cantidadPacientes)) return subConjunto.Length;

            }
            else if (posMedicos == medicos.Length) return -1;
            else
            {
                subConjunto[posSubConjunto] = medicos[posMedicos];

                int primera = Recorrido(medicos, subConjunto, posMedicos + 1, posSubConjunto + 1, radio, matrix, cantidadPacientes);

                if (primera != -1) return primera;

                int segunda = Recorrido(medicos, subConjunto, posMedicos + 1, posSubConjunto, radio, matrix, cantidadPacientes);

                if (segunda != -1) return segunda;
            }
            return -1;
        }
        public static bool SeAlcanzanTodos(int[,] matriz, int[] subConjuntoMedico, int radioMedico, int cantidadPacientes)
        {
            List<int> pacientes = new List<int>();

            foreach(var medico in subConjuntoMedico)
            {
                for(int primerIndice = 0; primerIndice < matriz.GetLength(0); primerIndice++)
                {
                    for(int segundoIndice = 0; segundoIndice < matriz.GetLength(1); segundoIndice++)
                    {
                        if(matriz[primerIndice, segundoIndice] == medico)
                        {
                            List<int> pacinetesAlcanzados = new List<int>();
                            for (int fila = primerIndice - radioMedico; fila <= primerIndice + radioMedico; fila++)
                            {
                                for(int columna = segundoIndice - radioMedico; columna <= segundoIndice + radioMedico; columna++)
                                {
                                    if(EsValido(matriz, fila, columna))
                                    {
                                        if(matriz[fila, columna] > 0)
                                        {
                                            pacinetesAlcanzados.Add(matriz[fila, columna]);
                                        }
                                    }
                                }
                            }
                            pacientes = pacientes.Union(pacinetesAlcanzados).ToList();
                            if (pacientes.Count == cantidadPacientes) return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool EsValido(int[,] matriz, int fila, int columna)
        { return fila >= 0 && columna >= 0 && fila < matriz.GetLength(0) && columna < matriz.GetLength(1); }
    }
}
