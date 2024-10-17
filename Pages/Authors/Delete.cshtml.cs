using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albu_Carina_Lab2.Data;
using Albu_Carina_Lab2.Models;

namespace Albu_Carina_Lab2.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly Albu_Carina_Lab2.Data.Albu_Carina_Lab2Context _context;

        public DeleteModel(Albu_Carina_Lab2.Data.Albu_Carina_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Authors { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);

            if (authors == null)
            {
                return NotFound();
            }
            else
            {
                Authors = authors;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FindAsync(id);
            if (authors != null)
            {
                Authors = authors;
                _context.Authors.Remove(Authors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
