using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectAprozar.Data;
using ProiectAprozar.Models;

namespace ProiectAprozar.Pages.Fructe
{
    public class CreateModel : FructCategoriePageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public CreateModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FurnizorID"] = new SelectList(_context.Furnizor, "ID", "Denumire");
            var fruct = new Fruct();
            fruct.FructCategorii = new List<FructCategorie>();
            PopulateAssignedCategorieData(_context, fruct);
            return Page();
        }

        [BindProperty]
        public Fruct Fruct { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newFruct = new Fruct();
            if (selectedCategorii != null)
            {
                newFruct.FructCategorii= new List<FructCategorie>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new FructCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newFruct.FructCategorii.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Fruct>(
            newFruct,
            "Fruct",
            i => i.Denumire, i => i.Pret,
            i => i.TaraOrigine,i=>i.FurnizorID))
            {
                _context.Fruct.Add(newFruct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategorieData(_context, newFruct);
            
            return Page();
        }
    }
}
