using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ProiectAprozar.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        
        [Display(Name = "Denumire")]
        public string DenumireCategorie { get; set; }
        public ICollection<FructCategorie> FructCategorii { get; set; }
    }
}
