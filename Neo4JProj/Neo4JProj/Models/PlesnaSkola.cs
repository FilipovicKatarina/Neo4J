using System;
using System.Collections.Generic;

namespace Neo4JProj.Models
{
    public class PlesnaSkola
    {
        public String Idskole { get; set; }
        public String Ime { get; set; }
        public String Grad {get; set;}
        public String Adresa { get; set; }
        public String Email { get; set; }
        public String Brojtel { get; set; }
        public string  Ocena { get; set; }
        public List<Ples> plesovi { get; set; }
    }
}
