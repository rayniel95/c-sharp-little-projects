using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MetodoEulerRayniel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<float[]> vectores = Calculador(float.Parse(this.InputC1.Text), float.Parse(this.InputC2.Text), float.Parse(this.InputC3.Text), int.Parse(this.InputCantidadPuntos.Text),
                                                    int.Parse(this.InputPaso.Text), float.Parse(this.InputX1.Text), float.Parse(this.InputX2.Text), float.Parse(this.InputX3.Text),
                                                    float.Parse(this.InputX4.Text), float.Parse(this.InputX5.Text), float.Parse(this.InputX6.Text), float.Parse(this.InputT.Text));

            for (int q = 0; q < chart1.Series.Count; q++)
                this.chart1.Series[q].Points.Clear();
            this.chart1.Series.Clear();

            for (int funcion = 0; funcion < 6; funcion++)
            {
                this.chart1.Series.Add("Funcion " + (funcion + 1));
                this.chart1.Series[chart1.Series.Count - 1].ChartType = SeriesChartType.Line;

                foreach(var vector in vectores)
                {
                    this.chart1.Series[funcion].Points.AddXY(vector[0], vector[funcion + 1]);
                }
            }


        }
        public static List<float[]> Calculador(float c1, float c2, float c3, int cantidadPuntos, int paso, float x1, float x2, float x3, float x4, float x5, float x6, float T)
        {
            float[] xn = { T, x1, x2, x3, x4, x5, x6 };
            float[] xn1 = new float[7];

            float[,] matriz = {
                                  {0, 0, 0, 1, 0, 0},
                                  {0, 0, 0, 0, 1, 0},
                                  {0, 0, 0, 0, 0, 1},
                                  {-1 * c1, c1, 0, 0, 0, 0},
                                  {c2, -2 * c2, c2, 0, 0, 0},
                                  {0, c3, -1 * c3, 0, 0, 0}
                              };

            List<float[]> puntos = new List<float[]>(cantidadPuntos + 1);

            puntos.Add(xn);

            for (int veces = 1; veces <= cantidadPuntos; veces++)
            {
                float tiempo = T + veces * paso;

                for (int primerIndice = 0; primerIndice < 6; primerIndice++)
                {
                    float numero = 0;
                    for (int segundoIndice = 0; segundoIndice < 6; segundoIndice++)
                    {
                        numero += matriz[primerIndice, segundoIndice] * xn[segundoIndice + 1];
                    }
                    xn1[primerIndice + 1] = numero;
                }

                for (int indice = 1; indice < 7; indice++)
                {
                    xn1[indice] = paso * xn1[indice];
                    xn1[indice] += xn[indice];
                }
                xn1[0] = tiempo;

                puntos.Add(xn1);

                xn = xn1;
                xn1 = new float[7];
            }

            return puntos;
        }
    }
}
