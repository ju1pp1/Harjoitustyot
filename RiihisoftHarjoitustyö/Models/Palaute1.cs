using System;
using System.Collections.Generic;

namespace RiihisoftHarjoitustyö.Models
{
    public partial class Palaute1
    {
        public int Id { get; set; }
        public string Etunimi { get; set; } = null!;
        public string Sukunimi { get; set; } = null!;
        public string Sähköposti { get; set; } = null!;
        public string AvoinPalaute { get; set; } = null!;
    }
}
