using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAprozar.Models
{
    public class Cos
    {
        public int ID { get; set; }
        public int FructID { get; set; }
        public Fruct Fruct { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        [Column(TypeName = "integer")]
        public int Cantitate { get; set; }

    }
}
