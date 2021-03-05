using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodoEulerRayniel
{
    public partial class Canvas : Control
    {
        float zoom;
        public Canvas()
        {
            InitializeComponent();
            zoom = 1.0F;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.Clear(Color.White);

            pe.Graphics.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, -1, 50 + (this.Width / 2), (this.Height - 50) / 2);

            pe.Graphics.ScaleTransform(zoom, zoom);

            List<float[]> listaPuntos = Calculador(this.C1, this.C2, this.C3, this.CantidadPuntos, this.Paso, this.X1, this.X2, this.X3, this.X4, this.X5, this.X6, this.t);

            for (int indice = 1; indice < 7; indice++)
            {
                for (int vector = 1; vector < listaPuntos.Count; vector++)
                {
                    pe.Graphics.DrawLine(new Pen(Brushes.Black, 0.001F), new PointF(listaPuntos[vector - 1][0], listaPuntos[vector - 1][indice]), new PointF(listaPuntos[vector][0],
                                                                                                                                                        listaPuntos[vector][indice]));
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
        public float C1 { get; set; }
        public float C2 { get; set; }
        public float C3 { get; set; }
        public int CantidadPuntos { get; set; }
        public int Paso { get; set; }
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float X3 { get; set; }
        public float X4 { get; set; }
        public float X5 { get; set; }
        public float X6 { get; set; }
        public float t { get; set; }
        public void ZoomIn()
        {
            this.zoom += 10.0F;
        }
        public void ZoomOut()
        {
            if (this.zoom - 10 < 0) return;
            this.zoom -= 10;
        }
    }
}
