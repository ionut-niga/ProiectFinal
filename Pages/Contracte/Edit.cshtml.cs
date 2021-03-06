using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Contracte
{
    public class EditModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contract Contract { get; set; }
        public SelectList TransportSl { get; set; }
        public SelectList ClientSl { get; set; }

        public SelectList CazareSl { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract.FirstOrDefaultAsync(m => m.ID == id);

            PopulateDropdowns(Contract.TransportID);
            PopulateDropdowns(Contract.ClientID);
            PopulateDropdowns(Contract.CazareID);

            if (Contract == null)
            {
                return NotFound();
            }
            ViewData["TransportID"] = new SelectList(_context.Set<Transport>(), "ID", "Firma");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(Contract.TransportID);
                PopulateDropdowns(Contract.ClientID);
                PopulateDropdowns(Contract.CazareID);
                return Page();
            }

            _context.Attach(Contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(Contract.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.ID == id);
        }

        private void PopulateDropdowns(int? selectedValue = null)
        {
            TransportSl = new SelectList(_context.Transport, "ID", "Firma", selectedValue);
            ClientSl = new SelectList(_context.Client, "ID", "Nume", selectedValue);
            CazareSl = new SelectList(_context.Cazare, "ID", "Tip", selectedValue);
        }
    }
}
