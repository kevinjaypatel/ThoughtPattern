using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThoughtPattern.Data;
using ThoughtPattern.Models;

namespace ThoughtPattern.Pages.Thoughts
{
    public class EditModel : PageModel
    {
        private readonly ThoughtPattern.Data.ThoughtPatternContext _context;

        public EditModel(ThoughtPattern.Data.ThoughtPatternContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Thought Thought { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Thought = await _context.Thought.FirstOrDefaultAsync(m => m.ID == id);

            if (Thought == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Thought).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThoughtExists(Thought.ID))
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

        private bool ThoughtExists(int id)
        {
            return _context.Thought.Any(e => e.ID == id);
        }
    }
}
