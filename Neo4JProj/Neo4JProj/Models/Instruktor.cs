using System;
using System.Collections.Generic;

namespace Neo4JProj.Models
{
    public class Instruktor
    {
        public String Idinstruktora { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Starost { get; set; }
        public String Pol { get; set; }
        public String Biografija { get; set;}
        public String Brojtel { get; set; }
        public List<PlesnaSkola> listaSkola { get; set; }
        public Instruktor()
        { 

        }
    }
}
