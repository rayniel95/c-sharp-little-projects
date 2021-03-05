using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolEvaluadorExpresiones_class_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario myArbol = new ArbolBinarioOperadorMultiplica(
                                        new ArbolBinarioOperadorResta(
                                            new ArbolBinarioOperando(2),
                                            new ArbolBinarioOperando(4)),
                                        new ArbolBinarioOperadorMultiplica(
                                            new ArbolBinarioOperando(5),
                                            new ArbolBinarioOperando(7)));

            Console.WriteLine(myArbol.Evalua());
    


        }

        public class ArbolBinario
        {

            public ArbolBinario(ArbolBinario hijoIzq, ArbolBinario hijoDer)
            {
                HijoIzq = hijoIzq;
                HijoDer = hijoDer;
            }
            public ArbolBinario HijoIzq
            {
                get;
                private set;
            }
            public ArbolBinario HijoDer
            {
                get;
                private set;
            }
            public bool EsHoja
            {
                get
                {
                    return HijoDer == null && HijoIzq == null;
                }
            }
            public virtual int Evalua()
            {
                if(this.HijoIzq.EsHoja && this.HijoDer.EsHoja)
                {
                    return this.Aplica(this.HijoIzq.Evalua(), this.HijoDer.Evalua());
                }
                return this.Aplica(HijoIzq.Evalua(), HijoDer.Evalua());
            }
            public virtual int Aplica(int primero, int segundo)
            {
                return primero + segundo;
            }
        }
        public class ArbolBinarioOperadorSuma:ArbolBinario
        {
            public ArbolBinarioOperadorSuma(ArbolBinario hijoIzq, ArbolBinario hijoDer):base(hijoIzq, hijoDer)
            {

            }
            public override int Aplica(int primero, int segundo)
            {
                return base.Aplica(primero, segundo);
            }
        }
        public class ArbolBinarioOperadorResta:ArbolBinario
        {
            public ArbolBinarioOperadorResta(ArbolBinario hijoIzq, ArbolBinario hijoDer):base(hijoIzq, hijoDer)
            {

            }
            public override int Aplica(int primero, int segundo)
            {
                return primero - segundo;
            }
        }
        public class ArbolBinarioOperadorMultiplica:ArbolBinario
        {
            public ArbolBinarioOperadorMultiplica(ArbolBinario hijoIzq, ArbolBinario hijoDer):base(hijoIzq, hijoDer) { }
            public override int Aplica(int primero, int segundo)
            {
                return primero * segundo;
            }
        }
        public class ArbolBinarioOperadorDivide:ArbolBinario
        {
            public ArbolBinarioOperadorDivide(ArbolBinario hijoIzq, ArbolBinario hijoDer):base(hijoIzq, hijoDer) { }
            public override int Aplica(int primero, int segundo)
            {
                return primero / segundo;
            }
        }
        

        public class ArbolBinarioOperando:ArbolBinario
        {
            int valor;
            public ArbolBinarioOperando(int valor):base(null, null)
            {
                this.valor = valor;
            }
            public override int Evalua()
            {
                return this.valor;
            }
        }


    }
}
