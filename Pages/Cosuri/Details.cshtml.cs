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
    public class DetailsModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public DetailsModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public Cos Cos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cos = await _context.Cos
                .Include(c => c.Client)
                .Include(c => c.Fruct).FirstOrDefaultAsync(m => m.ID == id);

            if (Cos == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
