using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.ExamenII;

namespace CalculadoraSimple_class
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Prueba1

            //CalculadoraSimple cs = new CalculadoraSimple();
            //cs.Ejecuta(new Operacion('+', 2));
            //cs.Ejecuta(new Operacion('+', 3));
            //cs.Ejecuta(new Operacion('*', 10));
            //Console.WriteLine(cs.ResultadoActual()); //imprime 50
            //cs.Undo();
            //Console.WriteLine(cs.ResultadoActual()); //imprime 5
            //cs.Undo();
            //Console.WriteLine(cs.ResultadoActual()); //imprime 2
            //cs.Redo();
            //Console.WriteLine(cs.ResultadoActual()); //imprime 5






            #endregion
            #region Prueba2
            //CalculadoraSimple cs = new CalculadoraSimple();
            //cs.Ejecuta(new Operacion('*', 0)); //operacion 1
            //Console.WriteLine(cs.ResultadoActual()); // imprime 0
            //cs.Ejecuta(new Operacion('/', 5)); //operacion 2
            //Console.WriteLine(cs.ResultadoActual()); // imprime 0
            //cs.Ejecuta(new Operacion('+', 10)); //operacion 3 
            //cs.Ejecuta(new Operacion('+', 10)); //operacion 4 
            //cs.Ejecuta(new Operacion('+', 10)); //operacion 5 
            //cs.Ejecuta(new Operacion('+', 10)); //operacion 6
            //Console.WriteLine(cs.ResultadoActual()); // imprime 40
            //cs.Undo(); //des-hace la opereación 6
            //Console.WriteLine(cs.ResultadoActual()); // imprime 30
            //cs.Ejecuta(new Operacion('+', 5)); //operacion 7
            //cs.Redo(); //sin efecto pq la instrucción inmediata anterior no fue "Undo"
            //Console.WriteLine(cs.ResultadoActual()); // imprime 35
            //cs.Undo(); //des-hace la opereación 7 
            //cs.Undo(); //des-hace la opereación 5 (la operacion 6 ya había sido des-hecha)
            //Console.WriteLine(cs.ResultadoActual()); // imprime 20
            //cs.Redo(); //re-hace la operacion 5 
            //cs.Redo(); //re-hace la operacion 7 
            //cs.Redo(); //sin efecto porque solo se habían hecho dos Undo inmediatamente antes
            //Console.WriteLine(cs.ResultadoActual()); // imprime 35 //Note que en este caso la operacion 6 fue des-hecha y no interviene en el resultado
            //foreach (var operacion in cs.OperacionesEfectivas())
            //{
            //    Console.WriteLine(operacion);
            //} 
            ////Note que la operación 6 no se considera efectiva (fue deshecha y no se rehízo)
            ////Esto imprime las operaciones 1, 2, 3, 4, 5 y 7, es decir se escribiría 
            //// (* 0) // (/ 5) // (+ 10) // (+ 10) // (+ 10)// (+,5)





            #endregion
            #region Prueba3

            CalculadoraSimple cs = new CalculadoraSimple();
            cs.Ejecuta(new Operacion('+', 5)); //operacion 1
            cs.Undo(); //des-hace la operacion 1 
            cs.Undo(); //sin efecto, no existen instrucciones efectivas
            Console.WriteLine(cs.ResultadoActual()); //imprime 0
            cs.Ejecuta(new Operacion('/', 0)); //lanza DivideByZeroException








            #endregion

        }

        public class CalculadoraSimple : ICalculadora
        {
            Stack<Operacion> hechas;
            Stack<Operacion> desHechas;
            public CalculadoraSimple()
            {
                this.hechas = new Stack<Operacion>();
                this.hechas.Push(new Operacion(' ', 0));
                this.desHechas = new Stack<Operacion>();
            }
            /// <summary> 
            /// Procesa la instrucción especificada. Si la operación especificada  
            /// es '/' y el valor es 0 el método debe lanzar una excepción del 
            /// tipo DivideByZeroException.  
            /// </summary>  
            /// <param name="operacion">Instancia de la clase Operacion que describe  
            /// la operacion a realizar.  
            /// </param> 

            public void Ejecuta(Operacion operacion)
            {
                if (operacion.Operador == '/' && operacion.Operando == 0) throw new DivideByZeroException();
                this.desHechas.Clear();
                this.hechas.Push(operacion);

            }
            /// <summary> /// 
            /// Deshace la última instrucción, si no hay ninguna instrucción el 
            /// método no tiene ningún efecto. 
            /// </summary> 
            public void Undo()
            {
                if (this.hechas.Count == 1) return;
                this.desHechas.Push(this.hechas.Pop());
            }
            /// <summary> 
            /// 
            /// Deja sin efecto la última instrucción "Undo". El método solamente 
            /// tiene efecto cuando es invocado después de una instrucción de tipo 
            /// "Undo" o "Redo". 
            /// </summary> 
            public void Redo()
            {
                if (this.desHechas.Count == 0) return;

                this.hechas.Push(this.desHechas.Pop());

            }
            /// <summary> 
            /// El método calcula el resultado de realizar todas las operaciones 
            /// efectivas. Una operación efectiva es toda aquella que no ha sido 
            /// "des-hecha" a través de la instrucción "Undo", o que después 
            /// de "des-hecha" ha sido "re-hecha" a través de la instrucción "Redo" 
            /// </summary> 
            /// <returns>
            /// Retorna el resultado calculado
            /// </returns> 
            public int ResultadoActual()
            {

                int primero = this.hechas.ElementAt(this.hechas.Count - 1).Operando;

                for(int indice = this.hechas.Count - 2; indice >= 0; indice--)
                {
                    if(this.hechas.ElementAt(indice).Operador == '+')
                    {
                        primero += this.hechas.ElementAt(indice).Operando;
                    }
                    else if(this.hechas.ElementAt(indice).Operador == '-')
                    {
                        primero -= this.hechas.ElementAt(indice).Operando;
                    }
                    else if(this.hechas.ElementAt(indice).Operador == '/')
                    {
                        primero /= this.hechas.ElementAt(indice).Operando;
                    }
                    else if(this.hechas.ElementAt(indice).Operador == '*')
                    {
                        primero *= this.hechas.ElementAt(indice).Operando;
                    }
                }
                return primero;
            }

            public IEnumerable<Operacion> OperacionesEfectivas()
            {
                for(int indice = this.hechas.Count - 2; indice >= 0; indice--)
                {
                    yield return this.hechas.ElementAt(indice);
                }
            }
        }

        public interface ICalculadora
        { 
            /// <summary> 
            /// Procesa la instrucción especificada. Si la operación especificada 
            /// es '/' y el valor es 0 el método debe lanzar una excepción del 
            /// tipo DivideByZeroException. 
            /// </summary> 
            /// <param name="operacion">Instancia de la clase Operacion que describe 
            /// la operacion a realizar. 
            /// </param> 
            void Ejecuta(Operacion operacion);
            /// <summary> 
            /// Deshace la última instrucción, si no hay ninguna instrucción el 
            /// método no tiene ningún efecto. 
            /// </summary> 
            void Undo();
            /// <summary> 
            /// Deja sin efecto la última instrucción "Undo". El método solamente 
            /// tiene efecto cuando es invocado después de una instrucción de tipo 
            /// "Undo" o "Redo". 
            /// </summary> 
            void Redo();
            /// <summary> 
            /// El método calcula el resultado de realizar todas las operaciones 
            /// efectivas. Una operación efectiva es toda aquella que no ha sido 
            /// "des-hecha" a través de la instrucción "Undo", o que después 
            /// de "des-hecha" ha sido "re-hecha" a través de la instrucción "Redo" 
            /// </summary> /// <returns>Retorna el resultado calculado</returns> 
            int ResultadoActual();
            /// <summary> 
            /// Devuelve una secuencia de todas las operaciones efectivas realizadas 
            /// hasta el momento 
            /// </summary> 
            /// <returns>La secuencia calculada</returns> 
            IEnumerable<Operacion> OperacionesEfectivas();
        }

    }
}
