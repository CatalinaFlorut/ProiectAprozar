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
    public class DeleteModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public DeleteModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fruct Fruct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fruct = await _context.Fruct.FirstOrDefaultAsync(m => m.ID == id);

            if (Fruct == null)
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

            Fruct = await _context.Fruct.FindAsync(id);

            if (Fruct != null)
            {
                _context.Fruct.Remove(Fruct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
