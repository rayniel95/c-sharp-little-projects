using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer
{
    public enum TokenType { Number, Plus, Mult, Minus, Div, OpenPar, ClosedPar};

    public class Token
    {
        TokenType tokenType;
        string value;
        public TokenType Type { get { return this.tokenType; } set { this.tokenType = value; } }

        public string Value { get { return this.value; } set { this.value = value; } }
    }
    public class Tokenizer : IEnumerator<Token>
    {
        string cadena;
        string caracteres;
        int cursor;
        Token current;
        TokenType[] tipos;
        public Tokenizer(string cadena)
        {
            if (cadena.Replace(" ", "") == "") throw new InvalidOperationException("La cadena no puede ser vacia");
            Reset();
            this.cadena = cadena.Replace(" ", "");
            this.current = null;
            this.caracteres = "+*-/()";
            this.tipos = new TokenType[] { TokenType.Plus, TokenType.Mult, TokenType.Minus, TokenType.Div, TokenType.OpenPar, TokenType.ClosedPar};
        }
        public Token Current
        {
            get
            {
                if (this.cursor < 0) throw new InvalidOperationException();
                return this.current;
            }
            private set { }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.cursor++;
            if (this.cursor >= this.cadena.Length) return false;

            if(this.caracteres.Contains(this.cadena[this.cursor]))
            {
                this.current = new Token();
                this.current.Value = this.caracteres[this.caracteres.IndexOf(this.cadena[this.cursor])].ToString();
                this.current.Type = this.tipos[this.caracteres.IndexOf(this.cadena[this.cursor])];
                return true;
            }
            string temp = "";
            while(this.cursor < this.cadena.Length && !this.caracteres.Contains(this.cadena[this.cursor]))
            {
                temp += this.cadena[this.cursor];
                this.cursor++;
            }
            this.cursor--;
            this.current = new Token();
            this.current.Value = temp;
            this.current.Type = TokenType.Number;
            return true;


        }

        public void Reset()
        {
            this.cursor = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer myTokenizer = new Tokenizer("(12 + 3 * (583");

            while (myTokenizer.MoveNext())
            {
                Console.WriteLine(myTokenizer.Current.Type);
                Console.WriteLine(myTokenizer.Current.Value);
            }
        }
    }
}
