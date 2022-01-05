using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectAprozar.Data;
using ProiectAprozar.Models;

namespace ProiectAprozar.Pages.Cosuri
{
    public class CreateModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public CreateModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "Email");
        ViewData["FructID"] = new SelectList(_context.Fruct, "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Cos Cos { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cos.Add(Cos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
