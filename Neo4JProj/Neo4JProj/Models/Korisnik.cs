using System;
using System.Collections.Generic;

namespace Neo4JProj.Models
{
    public class Korisnik
    {
        public String Idkorisnika { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Email { get; set; }
        public List<Korisnik> prijatelji { get; set; }
    }
}

