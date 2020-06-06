using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThoughtPattern.Models;

namespace ThoughtPattern.Data
{
    public class ThoughtPatternContext : DbContext
    {
        public ThoughtPatternContext (DbContextOptions<ThoughtPatternContext> options)
            : base(options)
        {
        }

        public DbSet<ThoughtPattern.Models.Thought> Thought { get; set; }
    }
}
