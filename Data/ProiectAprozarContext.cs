using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectAprozar.Models;

namespace ProiectAprozar.Data
{
    public class ProiectAprozarContext : DbContext
    {
        public ProiectAprozarContext (DbContextOptions<ProiectAprozarContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectAprozar.Models.Fruct> Fruct { get; set; }

        public DbSet<ProiectAprozar.Models.Client> Client { get; set; }

        public DbSet<ProiectAprozar.Models.Categorie> Categorie { get; set; }

        public DbSet<ProiectAprozar.Models.Cos> Cos { get; set; }

        public DbSet<ProiectAprozar.Models.FructData> FructData { get; set; }

        public DbSet<ProiectAprozar.Models.Furnizor> Furnizor { get; set; }
    }
}
