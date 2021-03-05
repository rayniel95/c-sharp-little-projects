using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampamentoMilitar_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {


        }

        public class Jerarquia<T> : IJerarquia<T>
        {
            class NombreEqualityComparer<T5> : IEqualityComparer<Arbol<T5>>
            {
                public bool Equals(Arbol<T5> x, Arbol<T5> y)
                {
                    return x.Nombre.Equals(y.Nombre);
                }

                public int GetHashCode(Arbol<T5> obj)
                {
                    return obj.Nombre.GetHashCode();
                }
            }
            class MyOrden<T1> : OrdenDada<T1>
            {
                public MyOrden(string integrante, T1 orden, Arbol<T1> dadaPor) : base(integrante, orden)
                {
                    DadaPor = dadaPor;
                }
                public Arbol<T1> DadaPor
                {
                    get;
                    private set;
                }
            }
            class Arbol<T2>
            {
                public Arbol(string nombre, int nivel, MyOrden<T2> orden = null, List<Arbol<T2>> hijos = null)
                {
                    Nombre = nombre;
                    Orden = orden;
                    Hijos = new List<Arbol<T2>>();
                    Nivel = nivel;
                }
                public string Nombre
                {
                    get;
                    private set;
                }
                public MyOrden<T2> Orden
                {
                    get;
                    set;
                }
                public List<Arbol<T2>> Hijos
                {
                    get;
                    private set;
                }
                public int Nivel
                {
                    get;
                    private set;
                }
                public IEnumerable<Arbol<T2>> RecorridoSinContarRaiz()
                {
                    List<Arbol<T2>> myLista = new List<Arbol<T2>>();
                    Resuelve(this, myLista, 0);
                    return myLista;

                }
                public IEnumerable<Arbol<T2>> RecorridoContandoRaiz()
                {
                    yield return this;
                    foreach (var hijo in this.Hijos)
                        foreach (var otroHijo in hijo.RecorridoContandoRaiz())
                            yield return otroHijo;
                }
                void Resuelve(Arbol<T2> arbolaActual, List<Arbol<T2>> lista, int llamado)
                {
                    if (llamado > 0)
                        lista.Add(arbolaActual);
                    foreach (var arbol in arbolaActual.Hijos)
                        Resuelve(arbol, lista, llamado + 1);
                }
            }

            private readonly string jefeSupremo;
            Arbol<T> arbol;
            public Jerarquia(string jefeSupremo)
            {
                this.jefeSupremo = jefeSupremo;
                this.arbol = new Arbol<T>(jefeSupremo, 0);

            }
            public void AsignaJefe(string jefe, string subordinado)
            {
                if (!this.Existe(jefe) || this.Existe(subordinado))
                    throw new InvalidOperationException("el jefe no esta o ya el subordinado tien un jefe");

                foreach (var arbol in this.arbol.RecorridoContandoRaiz())
                {
                    if (arbol.Nombre.Equals(jefe))
                    {
                        arbol.Hijos.Add(new Arbol<T>(subordinado, arbol.Nivel + 1));
                        break;
                    }
                }
            }
            public bool EsSuperior(string superior, string integrante)
            {
                if (!this.Existe(integrante) || !this.Existe(superior))
                    throw new InvalidOperationException("no hay alguno de los dos");

                foreach (var arbol in this.arbol.RecorridoContandoRaiz())
                {
                    if (arbol.Nombre.CompareTo(superior) == 0)
                    {
                        foreach (var hijo in arbol.RecorridoSinContarRaiz())
                        {
                            if (hijo.Nombre.CompareTo(integrante) == 0)
                                return true;
                        }
                    }
                }
                return false;
            }
            public void Ordena(string superior, string integrante, T orden)
            {
                if (!this.Existe(superior) || !this.Existe(integrante))
                    throw new InvalidOperationException("no hay alguno de los dos");

                Arbol<T> arbolSuperior = null;

                if (this.EsSuperior(superior, integrante))
                {
                    foreach (var arbol in this.arbol.RecorridoContandoRaiz())
                    {
                        if (arbol.Nombre.CompareTo(superior) == 0)
                        {
                            arbolSuperior = arbol;
                            foreach (var hijo in arbolSuperior.RecorridoSinContarRaiz())
                            {
                                if ((hijo.Nombre.CompareTo(integrante) == 0 && hijo.Orden == null) ||
                                    (hijo.Nombre.CompareTo(integrante) == 0 && hijo.Orden != null && hijo.Orden.DadaPor.Nivel > arbolSuperior.Nivel))
                                {
                                    hijo.Orden = new MyOrden<T>(integrante, orden, arbolSuperior);
                                    break;
                                }
                            }
                        }
                    }


                }
            }
            public T Orden(string integrante, out string superior)
            {
                if (!this.Existe(integrante))
                    throw new InvalidOperationException("el integrante no existe");

                superior = "";
                MyOrden<T> orden = null;

                foreach (var arbol in this.arbol.RecorridoSinContarRaiz())
                {
                    if (arbol.Nombre.Equals(integrante))
                    {
                        if (arbol.Orden == null) throw new InvalidOperationException("No esta cumpliendo ninguna orden el integrante");
                        orden = arbol.Orden;
                        superior = orden.DadaPor.Nombre;
                    }
                }
                return orden.Orden;
            }
            public bool TieneOrden(string integrante)
            {
                if (!this.Existe(integrante))
                    throw new InvalidOperationException("el integrante no existe");

                foreach (var arbol in this.arbol.RecorridoContandoRaiz())
                {
                    if (arbol.Nombre.Equals(integrante))
                    {
                        if (arbol.Orden == null) return false;
                    }
                }
                return true;
            }
            public bool Existe(string integrante)
            {
                return this.arbol.RecorridoContandoRaiz().Contains(new Arbol<T>(integrante, 0), new NombreEqualityComparer<T>());
            }
            public IEnumerable<OrdenDada<T>> OrdenesPorCumplir()
            {
                List<MyOrden<T>> ordenes = new List<MyOrden<T>>();

                foreach (var arbol in this.arbol.RecorridoContandoRaiz())
                {
                    if (arbol.Orden != null)
                        ordenes.Add(arbol.Orden);
                }
                return ordenes;
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
            public OrdenDada(string integrante, T orden)
            {
                this.integrante = integrante; this.orden = orden;
            }
            public string Integrante
            {
                get { return integrante; }
            }
            public T Orden
            {
                get { return orden; }
            }
        }

    }
}
