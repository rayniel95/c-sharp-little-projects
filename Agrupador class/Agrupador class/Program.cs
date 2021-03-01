using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrupador_class
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> listaPersonas = new List<Persona>();

            listaPersonas.Add(new Persona("Carlos", new DateTime(2005, 3, 2)));
            listaPersonas.Add(new Persona("Juan", new DateTime(2005, 12, 5)));
            listaPersonas.Add(new Persona("Jose", new DateTime(1999, 4, 8)));

            Agrupador<Persona> myAgrupador = new Agrupador<Persona>();

            IEnumerable<IGrupo<Persona>> enumerable = myAgrupador.Agrupa(listaPersonas, new LongitudNombreSelector());

            foreach(var el in enumerable)
            {
                Console.WriteLine(el.Llave);
                foreach(var otherel in el)
                    Console.WriteLine(otherel.Nombre);
            }

        }
        public class LongitudNombreSelector : ISelector<Persona>
        {
            public object Selecciona(Persona x)
            {
                return x.Nombre.Length;
            }
        }
        public class AnoSelector : ISelector<Persona>
        {
            public object Selecciona(Persona x)
            {
                return x.Fecha.Year;
            }
        }
        public class Persona
        {
            public Persona(string nombre, DateTime fecha)
            {
                Nombre = nombre;
                Fecha = fecha;
            }
            public string Nombre
            {
                get;
                private set;
            }
            public DateTime Fecha
            {
                get;
                private set;
            }
        }

        public interface IAgrupador<T3>
        {
            IEnumerable<IGrupo<T3>> Agrupa(IEnumerable<T3> coleccion, ISelector<T3> selector);
        }
        public interface ISelector<T2>
        {
            object Selecciona(T2 x);
        }
        public interface IGrupo<T1> : IEnumerable<T1>
        {
            object Llave { get; }
        }
        public class Agrupador<T4> : IAgrupador<T4>
        {
            class Grupo : IGrupo<T4>
            {
                List<T4> elementos;
                object llave;
                public Grupo(object llave)
                {
                    this.llave = llave;
                    this.elementos = new List<T4>();
                }
                public List<T4> Elementos
                {
                    get { return this.elementos; }
                }
                public object Llave
                {
                    get
                    {
                        return this.llave;
                    }
                }

                public IEnumerator<T4> GetEnumerator()
                {
                    return this.elementos.GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
            }
            IEnumerable<T4> coleccion;
            ISelector<T4> selector;
            List<Grupo> grupos;
            public Agrupador() { }
            public IEnumerable<IGrupo<T4>> Agrupa(IEnumerable<T4> coleccion, ISelector<T4> selector)
            {
                this.coleccion = coleccion;
                this.selector = selector;
                this.grupos = new List<Grupo>();

                foreach(var elemento in this.coleccion)
                {
                    object myLLave = this.selector.Selecciona(elemento);
                    int indiceGrupo = this.ExisteGrupo(myLLave);

                    if (indiceGrupo == -1)
                    {
                        Grupo nuevoGrupo = new Grupo(myLLave);
                        nuevoGrupo.Elementos.Add(elemento);
                        this.grupos.Add(nuevoGrupo);
                    }
                    else
                    {
                        this.grupos[indiceGrupo].Elementos.Add(elemento);
                    }
                }
                return this.grupos;
            }
            int ExisteGrupo(object llave)
            {
                for(int indice = 0; indice < this.grupos.Count; indice++)
                {
                    if (this.grupos[indice].Llave.Equals(llave))
                        return indice;
                }
                return -1;
            }
        }
    }
}
