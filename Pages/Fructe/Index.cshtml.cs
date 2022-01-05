using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectAprozar.Data;
using ProiectAprozar.Models;

namespace ProiectAprozar.Pages.Fructe
{
    public class IndexModel : FructCategoriePageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public IndexModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public IList<Fruct> Fruct { get; set; }
        public FructData FructD { get; set; }
        public int FructID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            FructD = new FructData();

            FructD.Fructe = await _context.Fruct
             .Include(b=>b.Furnizor)
            .Include(b => b.FructCategorii)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .ToListAsync();
            if (id != null)
            {
                FructID = id.Value;
                Fruct fruct = FructD.Fructe
                  .Where(i => i.ID == id.Value).Single();
                FructD.Categorii = fruct.FructCategorii.Select(s => s.Categorie);
            }
        }
    }
}

