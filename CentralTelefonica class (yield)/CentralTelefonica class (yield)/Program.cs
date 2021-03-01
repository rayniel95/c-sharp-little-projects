using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralTelefonica_class__yield_
{
    class Program
    {
        static void Main(string[] args)
        {
            CentralTelefonica cTel = new CentralTelefonica();
        
            cTel.Registrar("8321234");
            cTel.Registrar("555555");
            cTel.Registrar("6410000");
            cTel.Registrar("666666");
            cTel.Registrar("555555");
            cTel.Registrar("8339999");
            cTel.Registrar("777777");

            cTel.Descolgar("8321234");
            cTel.Marcar("8321234", "555555");
            Console.WriteLine(cTel.EstaSonando("555555")); // debe devolver true
            cTel.Descolgar("555555");

            cTel.Descolgar("6410000");
            cTel.Marcar("6410000", "666666");
            cTel.Descolgar("666666");
            cTel.Descolgar("8339999");
            cTel.Marcar("8339999", "777777");
            IEnumerator e = cTel.EnumeradorDeConversaciones();
            cTel.Colgar("555555");
            cTel.Colgar("8321234");
            cTel.Descolgar("777777");
            while (e.MoveNext())
            {
                Conversacion conv = (Conversacion)e.Current;
                Console.WriteLine(conv.numeroLlamante + " - " +
                conv.numeroReceptor);
            }

            // 8321234 - 555555
            // 6410000 - 666666



        }

        public interface ICentralTelefonica
        {
            void Registrar(string telef);
            void Descolgar(string telef);
            void Colgar(string telef);
            void Marcar(string numeroLlamante, string numeroReceptor);
            bool EstaSonando(string telef);
            IEnumerator<Conversacion> EnumeradorDeConversaciones();
        }
        public class Conversacion
        {
            public Conversacion(string numeroLlamante, string numeroReceptor)
            {
                this.numeroLlamante = numeroLlamante;
                this.numeroReceptor = numeroReceptor;
            }
            public string numeroLlamante, numeroReceptor;
        }

        public class CentralTelefonica : ICentralTelefonica
        {
            class Telefono
            {
                public Telefono(string numero)
                {
                    Numero = numero;
                    Conversaciones = new Queue<Conversacion>();
                    EstaColgado = true;
                }
                public string Numero { get; private set; }
                public bool EstaSonando
                {
                    get
                    {
                        if (EstaColgado && Conversaciones.Count > 0)
                            return true;
                        return false;
                    }
                }
                public bool EstaColgado { get; private set; }
                public void Colgar()
                {
                    if (EnConversacion)
                        Conversaciones.Dequeue();
                    EstaColgado = true;
                    EnConversacion = false;
                }
                public void Descolgar()
                {
                    EstaColgado = false;
                    if (Conversaciones.Count > 0)
                    {
                        EnConversacion = true;
                    }
                }
                public void Marcar(Telefono telefonoAMarcar)
                {
                    if(!EstaColgado)
                        telefonoAMarcar.Conversaciones.Enqueue(new Conversacion(Numero, telefonoAMarcar.Numero));
                }
                public bool EnConversacion { get; private set; }

                public Queue<Conversacion> Conversaciones { get; }
            }

            Dictionary<string, Telefono> telefonos;
            public CentralTelefonica()
            {
                this.telefonos = new Dictionary<string, Telefono>();
            }
            public void Colgar(string telef)
            {
                if(EstaRegistrado(telef))
                {
                    this.telefonos[telef].Colgar();
                    return;
                }
                throw new InvalidOperationException("telefono no registrado");
            }

            public void Descolgar(string telef)
            {
                if (EstaRegistrado(telef))
                {
                    this.telefonos[telef].Descolgar();
                    return;
                }
                throw new InvalidOperationException("telefono no registrado");
            }

            public IEnumerator<Conversacion> EnumeradorDeConversaciones()
            {
                foreach(var telefono in this.telefonos.Values)
                {
                    foreach(var conversacion in telefono.Conversaciones.ToArray())
                    {
                        yield return conversacion;
                    }

                }
                yield break;
            }

            public bool EstaSonando(string telef)
            {
                if(EstaRegistrado(telef))
                {
                    return this.telefonos[telef].EstaSonando;
                }
                throw new InvalidOperationException("telefono no registrado");
            }

            public void Marcar(string numeroLlamante, string numeroReceptor)
            {
                if(EstaRegistrado(numeroLlamante) && EstaRegistrado(numeroReceptor) && !this.telefonos[numeroLlamante].EnConversacion)
                {
                    this.telefonos[numeroLlamante].Marcar(this.telefonos[numeroReceptor]);
                    return;
                }
                throw new InvalidOperationException();
            }

            public void Registrar(string telef)
            {
                if (EstaRegistrado(telef)) { return; }
                this.telefonos.Add(telef, new Telefono(telef));
            }
            bool EstaRegistrado(string telefono)
            {
                return this.telefonos.ContainsKey(telefono);
            }
        }

    }
}
