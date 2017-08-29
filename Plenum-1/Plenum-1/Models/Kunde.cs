using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plenum_1.Models
{
    public class Kunde
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
    }
}