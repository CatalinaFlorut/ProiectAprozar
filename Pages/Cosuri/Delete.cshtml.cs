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
    public class DeleteModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public DeleteModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cos = await _context.Cos.FindAsync(id);

            if (Cos != null)
            {
                _context.Cos.Remove(Cos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
