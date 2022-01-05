using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectAprozar.Models
{
    public class Fruct
    {
        public int ID { get; set; }
        public string Denumire { get;  set; }
        [Display(Name ="Țară de origine")]
        public string TaraOrigine { get; set; }
        [Display(Name = "Preț")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Categorie")]
        public ICollection<FructCategorie> FructCategorii{ get; set; }

        public ICollection<Cos> Cosuri { get; set; }

        [ForeignKey("Furnizor")]
        public int FurnizorID { get; set; }
        public Furnizor Furnizor { get; set; }
    }
}
