using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAprozar.Models
{
    public class FructData
    {
        public int ID { get; set; }
        public IEnumerable<Fruct> Fructe { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<FructCategorie> FructCategorii{ get; set; }
    }
}
