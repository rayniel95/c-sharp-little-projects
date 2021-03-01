using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central_Telefonica_class
{
    public class CentralTelefonica
    {
        LinkedList<Telefono> telefonos;
        public CentralTelefonica() { this.telefonos = new LinkedList<Telefono>(); }
        public void Registrar(string telefono)
        {
            if (BuscaRegistrado(telefono) != null) return;

            this.telefonos.AddLast(new Telefono(telefono));
        }
        public void Colgar(string telefono)
        {
            if (BuscaRegistrado(telefono) == null) throw new InvalidOperationException("Telefono no registrado");

            BuscaRegistrado(telefono).Colgar();

        }
        public void Descolgar(string telefono)
        {
            if (BuscaRegistrado(telefono) == null) throw new InvalidOperationException("Telefono no registrado");
            BuscaRegistrado(telefono).Descolgar();
        }
        public void Marcar(string telefonoLLamante, string telefonoMarcado)
        {
            if (BuscaRegistrado(telefonoLLamante) == null) throw new InvalidOperationException("Telefono no registrado");
            if (BuscaRegistrado(telefonoLLamante).EstaColgado) return;
            BuscaRegistrado(telefonoLLamante).Descolgar();
            BuscaRegistrado(telefonoMarcado).AgregaConversacion(telefonoLLamante);
        }
        public bool EstaSonando(string telefono)
        {
            if (BuscaRegistrado(telefono) == null) throw new InvalidOperationException("Telefono no registrado");

            return BuscaRegistrado(telefono).EstaSonando;

        }
        public IEnumerable<Conversacion> EnumeradorDeConversaciones()
        {
            foreach(var tel in this.telefonos)
            {
                if(tel.Conversaciones.Count > 0)
                {
                    Conversacion[] copia = new Conversacion[tel.Conversaciones.Count];
                    tel.Conversaciones.CopyTo(copia, 0);
                    foreach (var con in copia)
                        yield return con;
                }
            }
        }
        public Telefono BuscaRegistrado(string telefono)
        {
            foreach(var tel in this.telefonos)
            {
                if (tel != null && tel.Numero == telefono) return tel;
            }
            return null;
        }
    }
    public class Conversacion
    {
        string numeroLlamante;
        public Conversacion(string numeroLlamante)
        {
            this.numeroLlamante = numeroLlamante;
        }
        public string NumeroLLamante { get { return this.numeroLlamante; } }
       
    }
    public class Telefono
    {
        string numero;
        bool estaColgado;
        bool estaSonando;
        Queue<Conversacion> conversacionesAsociadas;
        public Telefono(string numero)
        {
            this.numero = numero;
            this.estaColgado = true;
            this.estaSonando = false;
            this.conversacionesAsociadas = new Queue<Conversacion>();
        }
        public string Numero { get { return this.numero; } }
        public void Descolgar()
        {
            if (!this.estaColgado) return;
            this.estaColgado = false;
            this.estaSonando = false;
            if (this.conversacionesAsociadas.Count > 0) this.conversacionesAsociadas.Dequeue();

        }
        public Queue<Conversacion> Conversaciones { get { return this.conversacionesAsociadas; } }
        public bool EstaSonando
        { get { return this.estaSonando; } }
        public bool EstaColgado
        { get { return this.estaColgado; } }
        public void Colgar()
        {
            if (this.estaColgado) return;

            if (this.conversacionesAsociadas.Count > 0) this.estaSonando = true;
            this.estaColgado = true;

        }
        public void AgregaConversacion(string numeroLLamante)
        {
            this.conversacionesAsociadas.Enqueue(new Conversacion(numeroLLamante));
            if(this.estaColgado) this.estaSonando = true;
        }
    }
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
            Console.WriteLine(cTel.EstaSonando("555555"));  
            cTel.Descolgar("555555");
            Console.WriteLine(cTel.EstaSonando("555555"));
            Console.WriteLine(cTel.BuscaRegistrado("555555"));
            Console.WriteLine();


            cTel.Descolgar("6410000");
            Console.WriteLine(cTel.BuscaRegistrado("6410000").EstaColgado);
            cTel.Marcar("6410000", "666666");
            Console.WriteLine(cTel.BuscaRegistrado("666666").EstaSonando);
            Console.WriteLine(cTel.BuscaRegistrado("666666").Conversaciones.Count);
            Console.WriteLine();

            cTel.Descolgar("666666");
            Console.WriteLine(cTel.BuscaRegistrado("666666").Conversaciones.Count);

            cTel.Descolgar("8339999");
            cTel.Marcar("8339999", "777777");
    
            cTel.Colgar("555555");

            Console.WriteLine(cTel.BuscaRegistrado("555555").EstaColgado);
            Console.WriteLine(cTel.BuscaRegistrado("555555").EstaSonando);

            cTel.Colgar("8321234");
            cTel.Descolgar("777777");
        }
    }
}
