using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen.Restaurante;

namespace RestauranteOcupado_class
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            TestingWeboo();
            Console.WriteLine();
            MyTesting();




            #endregion
        }

        public class Restaurante : IRestaurante
        {
            class ClienteEqualityComparer : IEqualityComparer<Cliente>
            {
                public bool Equals(Cliente x, Cliente y)
                {
                    return x == y;
                }

                public int GetHashCode(Cliente obj)
                {
                    return obj.GetHashCode();
                }
            }

            Queue<Cliente> cola;
            List<Cliente> mesas;
            Dictionary<Cliente, int> platosAConsumir;
            int[] platosConsumidos;

            public Restaurante(int mesas)
            {
                this.mesas = new List<Cliente>();
                for (int indice = 0; indice < mesas; indice++)
                    this.mesas.Add(null);
                this.cola = new Queue<Cliente>();
                this.platosAConsumir = new Dictionary<Cliente, int>(new ClienteEqualityComparer());
                this.platosConsumidos = new int[mesas];
            }
            public int EnLaCola
            {
                get
                {
                    return this.cola.Count;
                }
            }

            public void LlegaCliente(Cliente cliente)
            {
                if (this.mesas.Contains(null) && this.cola.Count == 0)
                {
                    this.platosAConsumir.Add(cliente, cliente.PlatosAConsumir);
                    this.mesas[this.mesas.IndexOf(null)] = cliente;
                }
                else if(this.mesas.Contains(null) && this.cola.Count > 0)
                {
                    Cliente nuevo = this.cola.Dequeue();
                    this.platosAConsumir.Add(nuevo, nuevo.PlatosAConsumir);
                    this.mesas[this.mesas.IndexOf(null)] = nuevo;
                }
                else
                    this.cola.Enqueue(cliente);
                this.DaVuelta();

             
            }

            public int PlatosConsumidos(int mesa)
            {
                int restos = 0;
                if (this.mesas[mesa] != null)
                    restos = this.mesas[mesa].PlatosAConsumir - this.platosAConsumir[this.mesas[mesa]];
                return this.platosConsumidos[mesa] + restos;
            }

            public IEnumerable<Cliente> PorPagar()
            {
                foreach(var cliente in this.mesas)
                {
                    if (cliente != null && this.platosAConsumir[cliente] <= 0)
                        yield return cliente;
                }
            }

            public Cliente ProximoAPagar()
            {
                bool hayAlguien = false;
                foreach(var cliente in this.mesas)
                {
                    if (cliente != null)
                        hayAlguien = true;
                }
                if (!hayAlguien) return null;

                while (QuedanPorConsumir())
                    this.DaVuelta();

                Cliente temp = null;

                for(int indice = 0; indice < this.mesas.Count; indice++)
                {
                    if(this.mesas[indice] != null && this.platosAConsumir[this.mesas[indice]] <= 0)
                    {
                        temp = this.mesas[indice];
                        this.platosConsumidos[indice] += temp.PlatosAConsumir;
                        this.platosAConsumir.Remove(temp);

                        if (this.cola.Count > 0)
                        {
                            Cliente nuevo = this.cola.Dequeue();
                            this.platosAConsumir.Add(nuevo, nuevo.PlatosAConsumir);
                            this.mesas[indice] = nuevo;
                        }
                        else
                            this.mesas[indice] = null;
                        break;
                    }
                }
                this.DaVuelta();
                return temp;

            }
            bool QuedanPorConsumir()
            {
                foreach(var cliente in this.platosAConsumir)
                {
                    if (cliente.Value <= 0) return false;
                }
                return true;
            }
            void DaVuelta()
            {
                foreach (var cliente in this.mesas)
                {
                    if(cliente != null && this.platosAConsumir.ContainsKey(cliente))
                        this.platosAConsumir[cliente]--;
                }
            }
        }

        public static void MyTesting()
        {
            var restaurante = new Restaurante(4);

            //LlegaCliente(A(4))
            Cliente A = new Cliente(4);
            restaurante.LlegaCliente(A);

            Cliente B = new Cliente(4);
            restaurante.LlegaCliente(B);

            Cliente C = new Cliente(4);
            restaurante.LlegaCliente(C);

            Cliente D = new Cliente(4);
            restaurante.LlegaCliente(D);

            Cliente E = new Cliente(4);
            restaurante.LlegaCliente(E);

            Console.WriteLine(restaurante.PlatosConsumidos(0));
            Console.WriteLine(restaurante.ProximoAPagar());

            Console.WriteLine(restaurante.EnLaCola);

            Console.ReadLine();
        }
        public static void TestingWeboo()
        {
            // Este código reproduce el ejemplo mostrado en el documento
            // Siéntase libre de añadir tantas pruebas como considere necesario

            // Inicio
            var restaurante = new Restaurante(3);

            //LlegaCliente(A(4))
            Cliente A = new Cliente(4);
            restaurante.LlegaCliente(A);
            Verifica(restaurante.EnLaCola, 0);
            Verifica(restaurante.PlatosConsumidos(0), 1);

            //LlegaCliente(B(3))
            Cliente B = new Cliente(3);
            restaurante.LlegaCliente(B);
            Verifica(restaurante.EnLaCola, 0);
            Verifica(restaurante.PlatosConsumidos(0), 2);
            Verifica(restaurante.PlatosConsumidos(1), 1);

            //LlegaCliente(C(1))
            Cliente C = new Cliente(1);
            restaurante.LlegaCliente(C);
            Verifica(restaurante.EnLaCola, 0);
            Verifica(restaurante.PlatosConsumidos(0), 3);
            Verifica(restaurante.PlatosConsumidos(1), 2);
            Verifica(restaurante.PlatosConsumidos(2), 1);

            //PorPagar
            Verifica(restaurante.PorPagar(), C);

            //LlegaCliente(D(1))
            Cliente D = new Cliente(1);
            restaurante.LlegaCliente(D);
            Verifica(restaurante.EnLaCola, 1);

            //PorPagar
            Verifica(restaurante.PorPagar(), A, B, C);

            //LlegaCliente(E(3))
            Cliente E = new Cliente(3);
            restaurante.LlegaCliente(E);
            Verifica(restaurante.EnLaCola, 2);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), A);
            Verifica(restaurante.EnLaCola, 1);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), D);
            Verifica(restaurante.EnLaCola, 0);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), B);

            //PorPagar
            Verifica(restaurante.PorPagar(), C);

            //LlegaCliente(F(5))
            Cliente F = new Cliente(5);
            restaurante.LlegaCliente(F);
            Verifica(restaurante.EnLaCola, 0);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), E);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), C);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), F);

            //ProximoAPagar
            Verifica(restaurante.ProximoAPagar(), null);

            //PlatosConsumidos(1)
            Verifica(restaurante.PlatosConsumidos(1), 8);

            Console.ReadLine();
        }

        public static void Verifica<T>(T real, T esperado)
        {
            if (Equals(real, esperado))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("OK    ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0} == {1}", real, esperado);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("ERROR ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0} != {1}", real, esperado);
            }
        }
        public  static void Verifica<T>(IEnumerable<T> real, params T[] esperado)
        {
            if (Enumerable.SequenceEqual(real, esperado))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("OK    ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Enumerables iguales");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("ERROR ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Enumerables distintos");
            }
        }
        public static string ToString<T>(IEnumerable<T> elems)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in elems)
            {
                sb.Append(item);
                sb.Append(", ");
            }

            return sb.ToString(0, sb.Length - 2);
        }

    }
}
