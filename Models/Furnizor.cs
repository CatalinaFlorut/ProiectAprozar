using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAprozar.Models
{
    public class Furnizor
    {
        [Key]
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string CUI { get; set; }
        public ICollection<Fruct> Fructe { get; set; }
    }
}
