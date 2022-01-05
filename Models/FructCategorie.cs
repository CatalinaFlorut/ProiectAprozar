using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAprozar.Models
{
    public class FructCategorie
    {
        public int ID { get; set; }
        public int FructID { get; set; }
        public Fruct Fruct { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
