using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace JerarquiaCuentasTarjetasProductos
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
    public class Producto : ICloneable<Producto>
    {
        protected string nombre;
        public Producto(string nombre)
        {
            if(nombre.Replace(" ", "") == "")
                throw new Exception("Nombre no puede ser vacio");
            this.nombre = nombre;
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public override bool Equals(object obj)
        {
            Producto myProd = obj as Producto;

            if (myProd == null)
                return false;

            return myProd.Nombre == this.nombre;
        }
        public virtual Producto Clone()
        {
            return new Producto(this.nombre);
        }

    }
    public class ProductoPrecio : Producto
    {
        protected double precio;
        public ProductoPrecio(string nombre, double precio) : base(nombre)
        {
            if (precio < 0)
                throw new Exception("Precio no puede ser menor que cero");
            this.precio = precio;
        }
        public double Precio
        {
            get { return this.precio; }
            set { if (value < 0) throw new Exception("Valor debe ser mayor que cero"); this.precio = value; }
        }
        public override bool Equals(object obj)
        {
            ProductoPrecio myProd = obj as ProductoPrecio;
            if (myProd == null) return false;
            return myProd.Precio == this.precio && myProd.Nombre == this.nombre;
        }
        public new ProductoPrecio Clone()
        {
            return new ProductoPrecio(this.nombre, this.precio);
        }
        
    }
    public class ProductoDescuento : ProductoPrecio
    {
        protected double descuento;
        public ProductoDescuento(string nombre, double precio, double descuento) : base(nombre, precio)
        {
            if (descuento < 0 || descuento > precio) throw new Exception("El descuento debe ser mayor que cero y menor que el precio del producto");
            this.descuento = descuento;
        }
        public double PrecioConDescuento
        {
            get
            {
                return this.precio - this.descuento;
            }
        }
        public double Descuento
        {
            get { return this.descuento; }
            set
            {
                if (value < 0 || value > precio) throw new Exception("El descuento debe ser mayor que cero y menor que el precio del producto");
                this.descuento = value;
            }
        }
        public new ProductoDescuento Clone()
        {
            return new ProductoDescuento(this.nombre, this.precio, this.descuento);
        }
        public override bool Equals (object obj)
        {
            ProductoDescuento myProd = obj as ProductoDescuento;

            if (myProd == null) return false;
            return myProd.Descuento == this.descuento && myProd.Nombre == this.nombre && myProd.Precio == this.precio;
        }
    }
    public class ComparaProdPrecio : IComparer<ProductoPrecio>
    {
        public int Compare(ProductoPrecio primero, ProductoPrecio segundo)
        {
            return primero.Precio.CompareTo(segundo.Precio);
        }
    }
    public class ComparaProdDescuento : IComparer<ProductoDescuento>
    {
        public int Compare(ProductoDescuento primero, ProductoDescuento segundo)
        {
            return primero.Descuento.CompareTo(segundo.Descuento);
        }
    }
    public class ComparaProdNombre : IComparer<Producto>
    {
        public int Compare(Producto primero, Producto segundo)
        {
            return primero.Nombre.CompareTo(segundo.Nombre);
        }
    }
    public class Cuenta : ICloneable<Cuenta>
    {
        protected string titular;
        protected double saldo;
        public Cuenta(string titular, double saldo)
        {
            if (saldo < 0 || titular.Replace(" ", "") == "") throw new Exception("Parametros incorrectos");
            this.titular = titular;
            this.saldo = saldo;
        }
        public virtual void Extrae(double cantidad)
        {
            if (cantidad > this.saldo || cantidad < 0)
                throw new InvalidOperationException();
            this.saldo -= cantidad;
        }
        public void Agrega(double cantidad)
        {
            if (cantidad < 0) throw new InvalidOperationException();
            this.saldo += cantidad;
        }
        public string Titular
        {
            get { return this.titular; }
        }
        public double Saldo
        {
            get
            {
                return this.saldo;
            }
        }
        public Cuenta Clone()
        { return new Cuenta(this.titular, this.saldo); }
        public override bool Equals(object obj)
        {
            Cuenta cuenta = obj as Cuenta;
            if (cuenta == null) return false;
            return cuenta.Saldo == this.saldo && cuenta.Titular == this.titular;
        }

    }
    public class CuentaTransferencia : Cuenta, ICloneable<CuentaTransferencia>
    {
        public CuentaTransferencia(string titular, double saldo) : base(titular, saldo) {}
        public virtual void Transfiere(Cuenta cuenta, double cantidad)
        {
            if (cuenta == null || cantidad < 0 || cantidad > this.saldo) throw new InvalidOperationException();
            this.saldo -= cantidad;
            cuenta.Agrega(cantidad);
        }
        public CuentaTransferencia Clone()
        {
            return new CuentaTransferencia(this.titular, this.saldo);
        }
        public override bool Equals(object obj)
        {
            CuentaTransferencia cuenta = obj as CuentaTransferencia;
            if (cuenta == null) return false;
            return cuenta.Saldo == this.saldo && cuenta.Titular == this.titular;
        }
    }
    public class CuentaConjunta : CuentaTransferencia, ICloneable<CuentaConjunta>, IEnumerable<string>
    {
        class Enumerator : IEnumerator<string>
        {
            int cursor;
            string[] elementos;
            public Enumerator(string[] elementos)
            {
                this.elementos = elementos;
                Reset();
            }
            public string Current
            { get 
                { 
                    if (this.cursor < 0) throw new InvalidOperationException();
                    return this.elementos[this.cursor];
                } 
            }
            public bool MoveNext()
            {
                if (this.cursor < this.elementos.Length) { this.cursor++; return true; }
                return false;
            }
            public void Reset()
            {
                this.cursor = -1;
            }
            public void Dispose() { }
            object IEnumerator.Current { get { return Current; } }
        }   
        string[] titulares;
        public CuentaConjunta(string[] titulares, double saldo) : base(titulares[0], saldo)
        {
            if (titulares.Length < 2) throw new Exception("Deben haber al menos dos titulares en la cuenta");
            this.titulares = titulares;
        }
        public string[] Titulares
        { get { return this.titulares; } }
        public override bool Equals(object obj)
        {
            CuentaConjunta cuenta = obj as CuentaConjunta;
            if (cuenta == null) return false;
            for(int indice = 0; indice < Math.Min(this.titulares.Length, cuenta.Titulares.Length); indice++)
            {
                if (this.titulares[indice] != cuenta.Titulares[indice])
                    return false;
            }
            return this.saldo == cuenta.Saldo;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return new Enumerator(this.titulares);
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public CuentaConjunta Clone()
        { return new CuentaConjunta(this.titulares, this.saldo); } // tener presente que se pasa por referencia.

    }


    class Program
    {
        static void Main(string[] args)
        {
            CuentaTransferencia myCuenta = new CuentaTransferencia("yo", 233333);
          
        }
    }
}
