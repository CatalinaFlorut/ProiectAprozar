using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectAprozar.Data;
using ProiectAprozar.Models;

namespace ProiectAprozar.Pages.Cosuri
{
    public class IndexModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public IndexModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public IList<Cos> Cos { get;set; }

        public float Total;
        public async Task OnGetAsync()
        {
            Cos = await _context.Cos
                .Include(c => c.Client)
                .Include(c => c.Fruct).ToListAsync();
        }
    }
}
