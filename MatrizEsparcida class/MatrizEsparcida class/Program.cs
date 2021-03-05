using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MatrizEsparcida_class
{
    public interface IMatriz:IEnumerable<Celda>
    {
        int Filas { get; }
        int Columnas { get; }
        int CantidadDeElementosNoNulos { get; }
        void Inserta(Celda celda);
        int ValorEn(int fila, int columna);
        void Adiciona(IMatriz otra);
        IEnumerable<Celda> Fila(int fila);
        IEnumerable<Celda> Columna(int columna);
    }
    public class CeldaComparer : IComparer<Celda>
    {
        public int Compare(Celda primera, Celda segunda)
        {
            if (primera.Fila == segunda.Fila)
                return primera.Columna.CompareTo(segunda.Columna);
            return primera.Fila.CompareTo(segunda.Fila);
        }
    }
    public class Celda
    {
        int valor;
        ulong fila;
        ulong columna;

        public Celda(ulong fila, ulong columna, int valor)
        {
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
        }
        public ulong Fila
        {
            get { return this.fila; }
            set { this.fila = value; }
        }
        public ulong Columna
        {
            get { return this.columna; }
            set { this.columna = value; }
        }
        public int Valor
        {
            get { return this.valor; }
            set
            {
                this.valor = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} en ({1};{2})", Valor, Fila, Columna);
        }
    }
    public class MatrizEsparcida : IMatriz
    {
        private class Enumerador : IEnumerator<Celda>
        {
            Celda[] elementos;
            int actual;
            bool hayActual;

            public Enumerador(Celda[] elementos)
            {
                this.elementos = elementos;
                this.actual = -1;
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public bool MoveNext()
            {
                actual++;
                hayActual = actual < this.elementos.Length;
                return hayActual;
            }
            public Celda Current
            {
                get
                {
                    if (hayActual)
                        return this.elementos[actual];
                    throw new Exception("Cursor fuera de posicion");
                }
            }
            public void Dispose() { }
            public void Reset()
            {
                this.actual = -1;
                hayActual = false;
            }
        }

        int cantidadFilas;
        int cantidadColumnas;

        List<Celda> elementos;
        public MatrizEsparcida(int filas, int columnas)
        {
            if (filas <= 0 || columnas <= 0)
                throw new Exception("Dimension Invalida");

            this.cantidadFilas = filas;
            this.cantidadColumnas = columnas;
            this.elementos = new List<Celda>();
        }
        public IEnumerator<Celda> GetEnumerator()
        {
            Celda[] array = new Celda[this.elementos.Count];
            this.elementos.CopyTo(array);

            IEnumerator<Celda> myEnumerdor = new Enumerador(array);

            return myEnumerdor;
        }
 
        public int Columnas
        {
            get { return this.cantidadColumnas; }
        }
        public int Filas
        {
            get { return this.cantidadFilas; }
        }
        public void AgregaColumnas(int columnas)
        {
            this.cantidadColumnas += columnas;
        }
        public void AgregaFilas(int filas)
        {
            this.cantidadFilas += filas;
        }
        public void AsignaElemento(ulong fila, ulong columna, int elemento)
        {
            int indice = Busca(fila, columna, elemento);

            if (indice == -1 && elemento != 0)
            {
                this.elementos.Add(new Celda(fila, columna, elemento));
                this.elementos.Sort(new CeldaComparer());
            }
            else if (indice > -1 && elemento != 0)
            {
                this.elementos[indice].Valor = elemento;
            }
            else if (indice > -1 && elemento == 0)
            {
                this.elementos.RemoveAt(indice);
            }
        }
        private int Busca(ulong fila, ulong columna, int elemento)
        {
            for (int indice = 0; indice < this.elementos.Count; indice++)
            {
                if (this.elementos[indice].Fila == fila && this.elementos[indice].Columna == columna && this.elementos[indice].Valor == elemento)
                    return indice;
                else if (this.elementos[indice].Fila > fila)
                    break;
            }
            return -1;
        }
        public void EliminaFila(ulong fila)
        {
            this.cantidadFilas--;

            int myIndice = 0;

            for (int indice = 0; indice < this.elementos.Count; indice++)
            {
                if (this.elementos[indice].Fila == fila)
                {
                    myIndice = indice;
                    break;
                }
            }
            while (this.elementos[myIndice].Fila == fila)
            {
                this.elementos.RemoveAt(myIndice);
            }
        }
        public void ELiminaColumna(ulong columna)
        {
            this.cantidadColumnas--;

            int cantidad = this.elementos.Count;
            int contador = 0;

            for (int indice = 0; indice < cantidad; indice++)
            {
                if (this.elementos[contador].Columna == columna)
                {
                    this.elementos.RemoveAt(contador);
                }
                else if (contador < this.elementos.Count)
                    contador++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Inserta(Celda celda)
        {
            this.AsignaElemento((ulong)celda.Fila, (ulong)celda.Columna, celda.Valor);
        }

        public int ValorEn(int fila, int columna)
        {
            IEnumerator<Celda> myEnumerator = this.GetEnumerator();
            int valor = -1;

            while(myEnumerator.MoveNext())
            {
                if ((int)myEnumerator.Current.Fila == fila && (int)myEnumerator.Current.Columna == columna)
                    valor = myEnumerator.Current.Valor;
            }
            return valor;
        }

        public void Adiciona(IMatriz otra)
        {
            List<Celda> nueva = new List<Celda>();
            List<Celda> mayor;
            List<Celda> menor;

            if (Math.Max(this.elementos.Count, otra.CantidadDeElementosNoNulos) == this.elementos.Count)
            {
                mayor = this.elementos;
                menor = new List<Celda>();

                foreach (Celda elemento in otra)
                    menor.Add(elemento);
            }
            else
            {
                mayor = new List<Celda>();

                foreach (Celda elemento in otra)
                    mayor.Add(elemento);
                menor = this.elementos;
            }
            for(int primerIndice = 0; primerIndice < menor.Count; primerIndice++)
            {
                for(int segundoIndice = 0; segundoIndice < mayor.Count; segundoIndice++)
                {
                    if(menor[primerIndice].Fila == mayor[segundoIndice].Fila && menor[primerIndice].Columna == menor[segundoIndice].Columna)
                    {
                        if (menor[primerIndice].Valor + mayor[segundoIndice].Valor != 0)
                            nueva.Add(new Celda(menor[primerIndice].Fila, menor[primerIndice].Columna, menor[primerIndice].Valor + mayor[segundoIndice].Valor));
                    }
                }
            }
            this.elementos = nueva;
        }

        public IEnumerable<Celda> Fila(int fila)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Celda> Columna(int columna)
        {
            throw new NotImplementedException();
        }

        public int CantidadDeElementosNoNulos
        {
            get { return this.elementos.Count; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MatrizEsparcida my = new MatrizEsparcida(234, 4333);

            
        }
    }
}
