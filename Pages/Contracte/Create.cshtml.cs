using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Contracte
{
    public class CreateModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDropdowns();
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }
        public SelectList TransportSl { get; set; }
        public SelectList ClientSl { get; set; }
        public SelectList CazareSl { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(Contract.TransportID, Contract.ClientID, Contract.CazareID);
                return Page();
            }

            _context.Contract.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void PopulateDropdowns(int? transportId = null, int? clientId = null, int? cazareId = null)
        {
            TransportSl = new SelectList(_context.Transport, "ID", "Firma", transportId);
            ClientSl = new SelectList(_context.Client, "ID", "Nume", clientId);
            CazareSl = new SelectList(_context.Cazare, "ID", "Tip", cazareId);
        }

    }
}
