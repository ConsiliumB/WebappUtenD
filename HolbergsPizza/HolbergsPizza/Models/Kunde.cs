using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolbergsPizza.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Tlf { get; set; }
        public virtual List<Ordre> Ordrer { get; set; }
    }
}