using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzonDeCorreos_class
{
    public class ComparadorPorAsunto : IComparer<Mensaje>
    {
        public int Compare(Mensaje x, Mensaje y)
        {
            return x.Asunto.CompareTo(y.Asunto);
        }
    }
    public class CorreosMatcom : ICategoria
    {
        public CorreosMatcom()
        {
            Nombre = "Matcom";
        }
        public string Nombre
        {
            get;
            private set;
        }

        public bool Incluye(Mensaje mensaje)
        {
            return mensaje.Remitente.Contains("matcom.uh");
        }
    }
    public interface ICategoria
    {
        string Nombre { get; }
        bool Incluye(Mensaje mensaje);
    }
    public class Mensaje
    {
        string remitente;
        DateTime fecha;
        string asunto;
        string cuerpo;
        public Mensaje(string remitente, DateTime fecha, string asunto, string cuerpo)
        {
            this.remitente = remitente;
            this.fecha = fecha;
            this.asunto = asunto;
            this.cuerpo = cuerpo;
        }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public string Remitente { get { return this.remitente; } set { this.remitente = value; } }
        public string Asunto { get { return this.asunto; } set { this.asunto = value; } }
        public string Cuerpo { get { return this.cuerpo; } set { this.cuerpo = value; } }
    }

    public class Buzon
    {
        class MensajePorFechaComparer : IComparer<Mensaje>
        {
            public int Compare(Mensaje x, Mensaje y)
            {
                if (x.Fecha.Year != y.Fecha.Year)
                    return x.Fecha.Year.CompareTo(y.Fecha.Year);
                if (x.Fecha.Month != y.Fecha.Month)
                    return x.Fecha.Month.CompareTo(y.Fecha.Month);
                return x.Fecha.Day.CompareTo(y.Fecha.Day);
            }
        }
        List<Mensaje> mensajes;
        List<ICategoria> categorias;
        public Buzon()
        {
            this.categorias = new List<ICategoria>();
            this.mensajes = new List<Mensaje>();
        }
        public bool Recibe(Mensaje mensaje)
        {
            if (Palabras(mensaje) > this.MaximoDePalabrasPorMensaje) return false;
            this.mensajes.Add(mensaje);
            return true;
        }
        public IEnumerable<Mensaje> MensajesEnBuzon()
        {
            this.mensajes.Sort(new MensajePorFechaComparer());
            return this.mensajes;
        }
        public IEnumerable<Mensaje> MensajesEnBuzon(IComparer<Mensaje> comparador)
        {
            this.mensajes.Sort(comparador);
            return this.mensajes;
        }
        public IEnumerable<Mensaje> MensajesEnCategoria(string categoria, IComparer<Mensaje> comparador)
        {
            List<Mensaje> temp = (List<Mensaje>)MensajesEnCategoria(categoria);
            temp.Sort(comparador);
            return temp;
        }
        public IEnumerable<Mensaje> MensajesEnCategoria(string categoria)
        {
            List<Mensaje> mensajesEnCategoria = new List<Mensaje>();
            ICategoria catego = null;
            foreach(var cat in this.categorias)
            {
                if (cat.Nombre.CompareTo(categoria) == 0)
                    catego = cat;
            }
            if (catego == null) return mensajesEnCategoria;

            foreach(var mensaj in this.mensajes)
            {
                if (catego.Incluye(mensaj))
                    mensajesEnCategoria.Add(mensaj);
            }
            return mensajesEnCategoria;
        }

        public List<ICategoria> Categorias
        {
            get
            {
                return this.categorias; 
            }
        }
        public int MaximoDePalabrasPorMensaje
        {
            get;
            set;
        }

        int Palabras(Mensaje mensaje)
        {
            int palabras = 0;
            bool nuevaPalabra = false;

            foreach(char caracter in mensaje.Asunto.ToLower())
            {
                if(caracter.ToString().CompareTo("z") < caracter.ToString().CompareTo("a") && nuevaPalabra == false)
                {
                    nuevaPalabra = true;
                    palabras++;
                }
                else if(!(caracter.ToString().CompareTo("z") < caracter.ToString().CompareTo("a")))
                {
                    nuevaPalabra = false;
                }
            }
            nuevaPalabra = false;
            foreach (var caracter in mensaje.Cuerpo.ToLower())
            {
                if (caracter.ToString().CompareTo("z") < caracter.ToString().CompareTo("a") && nuevaPalabra == false)
                {
                    nuevaPalabra = true;
                    palabras++;
                }
                else if (!(caracter.ToString().CompareTo("z") < caracter.ToString().CompareTo("a")))
                {
                    nuevaPalabra = false;
                }
            }
            return palabras;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Buzon myBuzon = new Buzon();
            myBuzon.MaximoDePalabrasPorMensaje = 10;
            Console.WriteLine(myBuzon.Recibe(new Mensaje("pedro@yahoo.com",
                                                new DateTime(2012, 5, 12),
                                                "Saludos",
                                                "Hola, Juan:\n\tTe escribo con gusto estas 11 palabras. \nSaludos,\n\t\tPedro")));

            Console.WriteLine(myBuzon.Recibe(new Mensaje("maria@yahoo.com",
                                                new DateTime(2011, 3, 3),
                                                "Recordatorio",
                                                "Recuerda pasar por la casa.")));

            Console.WriteLine(myBuzon.Recibe(new Mensaje("jose@matcom.uh.cu",
                                                new DateTime(2012, 6, 1),
                                                "Estamos a la espera",
                                                "Trae los documentos \n\tJose..")));

            Console.WriteLine(myBuzon.Recibe(new Mensaje("jose@yahoo.com",
                                                new DateTime(2010, 2, 10),
                                                "Problema",
                                                "...No puedo ir...")));

            Console.WriteLine(myBuzon.Recibe(new Mensaje("jose@matcom.uh.cu",
                                                new DateTime(2012, 6, 2),
                                                "Ausencia",
                                                "No viniste\n\nJose")));

            Console.WriteLine(myBuzon.Recibe(new Mensaje("maria@matcom.uh.cu",
                                                new DateTime(2012, 6, 1),
                                                "Informe",
                                                "Puse -el-informe- en el escritorio.")));

            foreach (Mensaje m in myBuzon.MensajesEnBuzon())
                Console.WriteLine("{0} - {1}", m.Remitente, m.Asunto);

            Console.WriteLine();

            ICategoria cat = new CorreosMatcom();

            myBuzon.Categorias.Add(cat);

            foreach (Mensaje m in myBuzon.MensajesEnCategoria("Matcom"))
                Console.WriteLine(m.Remitente);

            Console.WriteLine();

            foreach (Mensaje m in myBuzon.MensajesEnBuzon(new ComparadorPorAsunto()))
                Console.WriteLine("{0} - {1}", m.Remitente, m.Asunto);

            Console.WriteLine();

            foreach (Mensaje m in myBuzon.MensajesEnCategoria("Matcom", new ComparadorPorAsunto()))
                Console.WriteLine("{0} - {1}", m.Remitente, m.Asunto);
        }
    }
}
