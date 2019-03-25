using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crowdience.Models
{
    public class CrowdienceContext : DbContext
    {
        public CrowdienceContext(DbContextOptions<CrowdienceContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}