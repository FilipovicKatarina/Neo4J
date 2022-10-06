using System;

namespace Neo4JProj.Models
{
    public class Ples
    {
        public String Idplesa { get; set; }
        public String Naziv { get; set; }
        public String Zemljaporekla { get; set; }
        public PlesnaSkola Skola { get; set; }
        public Instruktor Inst { get; set; }
    }
}
