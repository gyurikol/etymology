using System;
using Microsoft.EntityFrameworkCore;

namespace etymology.Models.dbContext
{
    public class MorphemeContext : DbContext
    {
        public MorphemeContext(DbContextOptions<MorphemeContext> options) : base(options)
        {
        }

        public DbSet<Morpheme> Morphemes { get; set; }
    }
}
