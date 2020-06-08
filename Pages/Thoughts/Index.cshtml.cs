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
    public class IndexModel : PageModel
    {
        private readonly ThoughtPattern.Data.ThoughtPatternContext _context;

        public IndexModel(ThoughtPattern.Data.ThoughtPatternContext context)
        {
            _context = context;
        }

        public IList<Thought> Thought { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList FilteredThoughts { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ThoughtDescription { get; set; }

        public async Task OnGetAsync()
        {
            var thoughts = from t in _context.Thought
                           orderby t.ReleaseDate descending
                           select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
                thoughts = (IOrderedQueryable<Thought>)thoughts.Where(t => t.Description.Contains(SearchString));
            }

            Thought = await thoughts.ToListAsync();
        }
    }
}
