using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectAprozar.Data;
using ProiectAprozar.Models;

namespace ProiectAprozar.Pages.Fructe
{
    public class EditModel : FructCategoriePageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public EditModel(ProiectAprozar.Data.ProiectAprozarContext context)
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

            Fruct = await _context.Fruct
                .Include(b=>b.Furnizor)
                .Include(b => b.FructCategorii).
                ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Fruct == null)
            {
                return NotFound();
            }
            PopulateAssignedCategorieData(_context, Fruct);
            ViewData["FurnizorID"] = new SelectList(_context.Furnizor, "ID","Denumire");
            return Page();
           
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fructToUpdate = await _context.Fruct
                .Include(i => i.FructCategorii)
                .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (fructToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Fruct>(
                fructToUpdate,
                "Fruct",
                i => i.Denumire, i => i.Pret, i => i.TaraOrigine))
            {
                UpdateFructCategorii(_context, selectedCategorii, fructToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateFructCategorii(_context, selectedCategorii, fructToUpdate);
            PopulateAssignedCategorieData(_context, fructToUpdate);
            return Page();

        }
    }
           
}
