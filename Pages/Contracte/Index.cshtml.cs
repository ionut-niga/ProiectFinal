using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Contracte
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Contract> Contract { get;set; }

        public async Task OnGetAsync()
        {
            Contract = await _context.Contract
                .Include(b => b.Transport)
                .Include(b => b.Client)
                .Include(b => b.Cazare)
                .ToListAsync();

        }
    }
}
