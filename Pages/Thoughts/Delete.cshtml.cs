﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThoughtPattern.Data;
using ThoughtPattern.Models;

namespace ThoughtPattern.Pages.Thoughts
{
    public class DeleteModel : PageModel
    {
        private readonly ThoughtPattern.Data.ThoughtPatternContext _context;

        public DeleteModel(ThoughtPattern.Data.ThoughtPatternContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Thought = await _context.Thought.FindAsync(id);

            if (Thought != null)
            {
                _context.Thought.Remove(Thought);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
