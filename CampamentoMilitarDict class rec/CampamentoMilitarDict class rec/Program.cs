using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampamentoMilitarDict_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Jerarquia<T> : IJerarquia<T>
        {
            class MyOrden<T1>:OrdenDada<T1>
            {
                public MyOrden(string integrante, T1 orden, string dadaPor):base(integrante, orden)
                {
                    DadaPor = dadaPor;
                }
                public string DadaPor { get; private set; }
            }


            Dictionary<string, MyOrden<T>> ordenes;
            Dictionary<string, int> integrantes;

            private readonly string jefeSupremo;
            public Jerarquia(string jefeSupremo)
            {
                this.jefeSupremo = jefeSupremo;

                this.integrantes = new Dictionary<string, int>();
                this.ordenes = new Dictionary<string, MyOrden<T>>();

                this.integrantes.Add(this.jefeSupremo, 0);
                this.ordenes.Add(this.jefeSupremo, null);

            }
            public void AsignaJefe(string jefe, string subordinado)
            {
                if (this.integrantes.ContainsKey(subordinado) || !this.integrantes.ContainsKey(jefe))
                    throw new InvalidOperationException("no existe el jefe o el subordinado ya se ha asignado");

                this.integrantes.Add(subordinado, this.integrantes[jefe] + 1);
                this.ordenes.Add(subordinado, null);
            }
            public bool EsSuperior(string superior, string integrante)
            {
                if(!this.integrantes.ContainsKey(superior) || !this.integrantes.ContainsKey(integrante))
                    throw new InvalidOperationException("no existe el superior o el integrante");

                return this.integrantes[integrante] > this.integrantes[superior];

            }
            public void Ordena(string superior, string integrante, T orden)
            {
                if (!this.integrantes.ContainsKey(superior) || !this.integrantes.ContainsKey(integrante))
                    throw new InvalidOperationException("no existe el superior o el integrante");

                if (this.ordenes[integrante] == null || this.integrantes[this.ordenes[integrante].DadaPor] > this.integrantes[superior])
                    this.ordenes[integrante] = new MyOrden<T>(integrante, orden, superior);
            }
            public T Orden(string integrante, out string superior)
            {
                if (!this.integrantes.ContainsKey(integrante) || this.ordenes[integrante] == null)
                    throw new InvalidOperationException("no existe el integrante o esta haciendo nada");

                superior = this.ordenes[integrante].DadaPor;
                return this.ordenes[integrante].Orden;
            }
            public bool TieneOrden(string integrante)
            {
                if (!this.integrantes.ContainsKey(integrante))
                    throw new InvalidOperationException("no existe el integrante");

                return this.ordenes[integrante] != null;
            }
            public bool Existe(string integrante)
            {
                return this.integrantes.ContainsKey(integrante);
            }
            public IEnumerable<OrdenDada<T>> OrdenesPorCumplir()
            {
                return this.ordenes.Values;
            }
        }
        public interface IJerarquia<T>
        {
            void AsignaJefe(string jefe, string subordinado);
            bool EsSuperior(string superior, string integrante);
            void Ordena(string superior, string integrante, T orden);
            T Orden(string integrante, out string superior);
            bool TieneOrden(string integrante);
            bool Existe(string integrante);
            IEnumerable<OrdenDada<T>> OrdenesPorCumplir();
        }
        public class OrdenDada<T>
        {
            private readonly string integrante; private readonly T orden;
            public OrdenDada(string integrante, T orden) { this.integrante = integrante; this.orden = orden; }
            public string Integrante { get { return integrante; } }
            public T Orden { get { return orden; } }
        }
    }
}
