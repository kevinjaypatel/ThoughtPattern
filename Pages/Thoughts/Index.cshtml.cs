using System;
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
    public class IndexModel : PageModel
    {
        private readonly ThoughtPattern.Data.ThoughtPatternContext _context;

        public IndexModel(ThoughtPattern.Data.ThoughtPatternContext context)
        {
            _context = context;
        }

        public IList<Thought> Thought { get;set; }

        public async Task OnGetAsync()
        {
            Thought = await _context.Thought.ToListAsync();
        }
    }
}
