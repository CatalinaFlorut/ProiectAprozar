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
    public class IndexModel : PageModel
    {
        private readonly ProiectAprozar.Data.ProiectAprozarContext _context;

        public IndexModel(ProiectAprozar.Data.ProiectAprozarContext context)
        {
            _context = context;
        }

        public IList<FructData> FructData { get; set; }

        public async Task OnGetAsync()
        {
            FructData= await _context.FructData.ToListAsync();
        }
    }
}
