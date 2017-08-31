using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HolbergsPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Tykkelse { get; set; }
        public int Antall { get; set; }
        public int KundeId { get; set; }
        [ForeignKey("KundeId")]
        public Kunde Kunde { get; set; }
    }
}