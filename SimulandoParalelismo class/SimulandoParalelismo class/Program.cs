using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulandoParalelismo_class
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrganizador organizador = new MiOrganizador();

            CPU cpu1 = organizador.CreaCPU(75);
            organizador.AdicionaTarea(cpu1, new Tarea("X", 325));

            CPU cpu2 = organizador.CreaCPU(20);
            organizador.AdicionaTarea(cpu2, new Tarea("Y", 10));

            CPU cpu3 = organizador.CreaCPU(30);
            organizador.AdicionaTarea(cpu3, new Tarea("Z", 80));

            //Adicionando tareas del ejemplo
            organizador.AdicionaTarea(cpu1, new Tarea("C", 100));
            organizador.AdicionaTarea(cpu1, new Tarea("A", 175));
            organizador.AdicionaTarea(cpu2, new Tarea("M", 120));
            organizador.AdicionaTarea(cpu2, new Tarea("B", 60));
            organizador.AdicionaTarea(cpu3, new Tarea("R", 80));
            organizador.AdicionaTarea(cpu3, new Tarea("K", 110));

            Console.WriteLine("Respuesta Correcta es la Tarea: Y");
            Console.WriteLine(organizador.ProximaTarea());
            Console.WriteLine("Respuesta Correcta es la Tarea: Z");
            Console.WriteLine(organizador.ProximaTarea());
            Console.WriteLine("Respuesta Correcta es la Tarea: X");
            Console.WriteLine(organizador.ProximaTarea());

            //foreach (Tarea tarea in organizador.Ejecuta(50))
            //{
            //    //No debe ejecutarse esta instruccion,
            //    //pues no se finaliza ninguna tarea
            //    Console.WriteLine(tarea);
            //}

            //En estos momentos el organizador debe tener la misma configuracion
            //que el ejemplo dado en la especificacion del problema
            Console.WriteLine("Respuesta Correcta es la Tarea: C");
            Console.WriteLine(organizador.ProximaTarea());

            Console.WriteLine("Respuesta Correcta son\n  Tarea: R\n  Tarea: M");
            foreach (Tarea tarea in organizador.Ejecuta(200))
                Console.WriteLine(tarea);

            //Continua Probando ...
            Console.WriteLine("Respuesta Correcta son\n  Tarea: A\n  Tarea: K\n  Tarea: B");
            foreach (Tarea tarea in organizador.Ejecuta(long.MaxValue))
                Console.WriteLine(tarea);
        }
        public class Tarea
        {
            public Tarea(string nombre, long duracion)
            {
                Nombre = nombre;
                Duracion = duracion;
            }
            public string Nombre { get; }
            public long Duracion { get; }
            public override string ToString()
            {
                return Nombre;
            }
        }
        public class CPU
        {
            public CPU(long ciclosCPU)
            { CiclosCPU = ciclosCPU; }
            public long CiclosCPU { get; }
        }
        public interface IOrganizador
        {
            /// Devuelva la cantidad de CPU virtuales creados.
            int TotalCPU { get; }
            /// Crea un nuevo CPU virtual.
            CPU CreaCPU(long ciclosCPU);
            /// Adiciona una tarea al CPU virtual especificado.
            void AdicionaTarea(CPU cpu, Tarea tarea);
            /// Devuelve la próxima que termina. Si no hay tareas o todos los CPU están
            /// interrumpidos, entonces devuelve null.
            Tarea ProximaTarea();
            /// Interrumpe la ejecución del CPU virtual, de forma que
            /// cuando le toque el turno a este CPU el organizador pase
            /// directamente al siguiente.
            void Duerme(CPU cpu);
            /// Reanuda la ejecución del CPU virtual, de forma que
            /// cuando le toque el turno a este CPU funcione de forma habitual.
            void Despierta(CPU cpu);
            /// Devuelve todas las tareas que terminan su ejecución después de esa cantidad
            /// de ciclos de CPU.
            IEnumerable<Tarea> Ejecuta(long ciclos);
            /// Devuelve todas las tareas asignadas a ese CPU (sin quitarlas de la cola
            /// de ejecución).
            IEnumerable<Tarea> TareasEnCPU(CPU cpu);
        }
        public class MiOrganizador : IOrganizador
        {
            #region IOrganizador Members

            class MyCpu : CPU
            {
                List<MyTarea> tareas;
                bool estaDormido;
                long ciclosQueQuedan;
                public MyCpu(long ciclos) : base(ciclos)
                {
                    this.tareas = new List<MyTarea>();
                    this.estaDormido = false;
                    this.ciclosQueQuedan = ciclos;
                }
                public bool EstaDormido
                {
                    get { return this.estaDormido; }
                    set { this.estaDormido = value; }
                }
                public List<MyTarea> Tareas
                {
                    get { return this.tareas; }
                }
                public long CiclosQueQuedan
                {
                    get { return this.ciclosQueQuedan; }
                    set { this.ciclosQueQuedan = value; }
                }
            }
            class MyTarea : Tarea
            {
                long ciclosQueFaltan;
                public MyTarea(string nombre, long duracion) : base(nombre, duracion)
                {
                    this.ciclosQueFaltan = duracion;
                }
                public long CiclosQueFaltan
                {
                    get { return this.ciclosQueFaltan; }
                    set { this.ciclosQueFaltan = value; }
                }
            }
            List<MyCpu> cpus;
            int indiceUltimo;
            public MiOrganizador()
            {
                this.cpus = new List<MyCpu>();
                this.indiceUltimo = 0;
            }
            public void AdicionaTarea(CPU cpu, Tarea tarea)
            {
                if (cpu == null || tarea == null) throw new ArgumentNullException();
                int indice = ExisteCpu(cpu);

                if (indice == -1) throw new ArgumentException();

                this.cpus[indice].Tareas.Add(new MyTarea(tarea.Nombre, tarea.Duracion));

            }
            int ExisteCpu(CPU cpu)
            {
                for (int indice = 0; indice < this.cpus.Count; indice++)
                {
                    if (this.cpus[indice] == cpu)
                        return indice;
                }
                return -1;
            }

            public CPU CreaCPU(long ciclosCPU)
            {
                if (ciclosCPU <= 0) throw new ArgumentException();
                MyCpu nuevoCpu = new MyCpu(ciclosCPU);

                this.cpus.Add(nuevoCpu);
                return nuevoCpu;
            }

            public void Despierta(CPU cpu)
            {
                if (cpu == null) throw new ArgumentNullException();

                int indice = ExisteCpu(cpu);

                if (indice != -1)
                {
                    this.cpus[indice].EstaDormido = false;
                }
                else
                    throw new ArgumentException();
            }

            public void Duerme(CPU cpu)
            {
                if (cpu == null) throw new ArgumentNullException();
                int indice = ExisteCpu(cpu);
                if (indice == -1) throw new ArgumentNullException();
                this.cpus[indice].EstaDormido = true;
            }
            bool HayTareas()
            {
                bool hayDespiertos = false;
                bool hayTareas = false;
                foreach (var cpu in this.cpus)
                {
                    if (!cpu.EstaDormido)
                        hayDespiertos = true;
                    if (cpu.Tareas.Count > 0)
                        hayTareas = true;
                }

                if (!hayDespiertos || !hayTareas) return false;
                return true;
            }
            bool TodasTerminadas()
            {
                foreach (var cpu in this.cpus)
                {
                    foreach (var tarea in cpu.Tareas)
                    {
                        if (tarea.CiclosQueFaltan != 0)
                            return false;
                    }
                }
                return true;
            }
            public IEnumerable<Tarea> Ejecuta(long ciclos)
            {
                if (!HayTareas()) return null;
                List<MyTarea> terminadas = new List<MyTarea>();

                while (ciclos > 0 && HayTareas())
                {
                    for (int indice = this.indiceUltimo; indice < this.cpus.Count && ciclos > 0; indice++)
                    {
                        if (this.cpus[indice].EstaDormido)
                            continue;
                        if (this.cpus[indice].CiclosQueQuedan == 0)
                            this.cpus[indice].CiclosQueQuedan = this.cpus[indice].CiclosCPU;
                        while (this.cpus[indice].CiclosQueQuedan > 0 && ciclos > 0 && this.cpus[indice].Tareas.Count > 0)
                        {
                            long ciclosEjecutar = 0;
                            if (this.cpus[indice].CiclosQueQuedan - ciclos <= 0)
                            {
                                ciclosEjecutar = this.cpus[indice].CiclosQueQuedan;
                                ciclos -= ciclosEjecutar;
                                this.cpus[indice].CiclosQueQuedan = 0;
                            }
                            else
                            {
                                ciclosEjecutar = ciclos;
                                ciclos = 0;
                                this.indiceUltimo = indice;
                                this.cpus[indice].CiclosQueQuedan -= ciclosEjecutar;
                            }
                            foreach (var tarea in this.cpus[indice].Tareas)
                            {
                                if (tarea.CiclosQueFaltan - ciclosEjecutar > 0)
                                {
                                    tarea.CiclosQueFaltan -= ciclosEjecutar;
                                    ciclosEjecutar = 0;
                                    break;
                                }
                                else
                                {
                                    ciclosEjecutar -= tarea.CiclosQueFaltan;
                                    tarea.CiclosQueFaltan = 0;
                                    terminadas.Add(tarea);
                                }
                            }
                            foreach (var tar in terminadas)
                            {
                                for (int indiceDos = 0; indiceDos < this.cpus[indice].Tareas.Count; indiceDos++)
                                {
                                    if (tar == this.cpus[indice].Tareas[indiceDos])
                                    {
                                        this.cpus[indice].Tareas.RemoveAt(indiceDos);
                                        break;
                                    }
                                }
                            }
                            ciclos += ciclosEjecutar;
                            this.cpus[indice].CiclosQueQuedan += ciclosEjecutar;

                        }
                    }
                    if (ciclos > 0)
                        this.indiceUltimo = 0;
                }
                return terminadas;
            }

            public Tarea ProximaTarea()
            {
                if (!HayTareas()) return null;

                MyTarea terminada = null;

                while (terminada == null)
                {
                    for (int indice = this.indiceUltimo; indice < this.cpus.Count && terminada == null; indice++)
                    {
                        if (this.cpus[indice].EstaDormido)
                            continue;
                        if (this.cpus[indice].CiclosQueQuedan == 0)
                            this.cpus[indice].CiclosQueQuedan = this.cpus[indice].CiclosCPU;

                        while (this.cpus[indice].CiclosQueQuedan > 0 && terminada == null && this.cpus[indice].Tareas.Count > 0)
                        {

                            if (this.cpus[indice].Tareas[0].CiclosQueFaltan - this.cpus[indice].CiclosQueQuedan > 0)
                            {
                                this.cpus[indice].Tareas[0].CiclosQueFaltan -= this.cpus[indice].CiclosQueQuedan;
                                this.cpus[indice].CiclosQueQuedan = 0;
                                break;
                            }
                            else
                            {
                                this.cpus[indice].CiclosQueQuedan -= this.cpus[indice].Tareas[0].CiclosQueFaltan;
                                this.cpus[indice].Tareas[0].CiclosQueFaltan = 0;
                                terminada = this.cpus[indice].Tareas[0];
                                this.cpus[indice].Tareas.RemoveAt(0);
                                this.indiceUltimo = indice;
                                break;
                            }



                        }
                    }
                    if (terminada == null)
                        this.indiceUltimo = 0;
                }
                return terminada;


            }

            public IEnumerable<Tarea> TareasEnCPU(CPU cpu)
            {
                if (cpu == null) throw new ArgumentNullException();
                int indice = ExisteCpu(cpu);
                if (indice == -1) throw new ArgumentException();
                return this.cpus[indice].Tareas;
            }

            public int TotalCPU
            {
                get { return this.cpus.Count; }
            }

            #endregion
        }
    }
}
