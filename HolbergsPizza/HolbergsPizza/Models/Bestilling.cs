using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolbergsPizza.Models
{
    public class Bestilling
    {
        public string Pizza { get; set; }
        public string Tykkelse { get; set; }
        public int Antall { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Tlf { get; set; }

    }
}