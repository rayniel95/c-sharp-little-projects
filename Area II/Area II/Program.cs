using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Area_II
{
    class Program
    {
        static void Main(string[] args)
        {
            IO();
        }
        static decimal Area(float radio)
        {
            float dos = (float) 2;
            decimal area = (decimal) (Math.PI * Math.Pow(radio, dos));

            return area;
        }
        static void IO()
        {
            string radio = Console.ReadLine();
        
            if (radio.Contains("."))
                radio = radio.Replace(".", ",");
            
            string area = Area(float.Parse(radio)).ToString(); 

            if(area.Contains(","))
                area = area.Replace(",", ".");

            Console.WriteLine(area);
        }
    }
}
