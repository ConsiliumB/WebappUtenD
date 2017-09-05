using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolbergsPizza.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Antall { get; set; }
        public string Tykkelse { get; set; }
        public virtual Kunde Kunde { get; set; }
    }
}