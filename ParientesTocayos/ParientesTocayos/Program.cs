using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParientesTocayos
{
    class Program
    {
        class Persona
        {
            string myNombre;
            Persona myMadre;
            Persona myPadre;
            public Persona(string nombre, Persona madre, Persona padre)
            {
                myNombre = nombre;
                myMadre = madre;
                myPadre = padre;
            }
            public string Nombre
            {
                get { return myNombre; }
            }
            public Persona Madre
            {
                get { return myMadre; }
            }
            public Persona Padre
            {
                get { return myPadre; }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            Persona angulo = new Persona(
                                        "Angulo",
                                        new Persona( // Madre de Angulo
                                        "Ofelia",
                                        new Persona( // Madre de Ofelia
                                        "María",
                                        null, // No se conoce la madre de María
                                        new Persona( // Padre de María
                                        "Angulo",
                                        null, // No se conoce la madre de Angulo
                                        null // No se conoce el padre de Angulo
                                        )
                                        ),
                                        new Persona( // Padre de Ofelia
                                        "Armando",
                                        null, // No se conoce la madre de Armando
                                        null // No se conoce el padre de Armando
                                        )
                                        ),
                                        new Persona( // Padre de Angulo
                                        "Manuel",
                                        new Persona( // Madre de Manuel
                                        "Angela",
                                        null, // No se conoce la madre de Angela
                                        null // No se conoce la madre de Angela
                                        ),
                                        null // No se conoce el padre de Manuel
                                        )
                                        );

            Console.WriteLine(angulo.Nombre);

            Console.WriteLine(ParienteTocayo(angulo));
        }
        static bool ParienteTocayo(Persona persona, Persona personaActual)
        {
            if (persona.Nombre == personaActual.Nombre)
                return true;
            else if (persona.Madre != null)
                return ParienteTocayo(persona.Madre, personaActual);

            else if (persona.Padre != null)
                return ParienteTocayo(persona.Padre, personaActual);

            else
                return false;
        }
        static bool ParienteTocayo(Persona p)
        {
            if (ParienteTocayo(p.Madre, p) || ParienteTocayo(p.Padre, p))
                return true;
            else
                return false;
        }
    }
}
