﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectAprozar.Data;
using ProiectAprozar.Models;

namespace ProiectAprozar.Pages.FructeData
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public DetailsModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public FructData FructData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FructData = await _context.FructData.FirstOrDefaultAsync(m => m.ID == id);

            if (FructData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
