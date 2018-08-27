using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace etymology.Models.dbContext
{
    public class MorphemeContext : DbContext
    {
        public MorphemeContext(DbContextOptions<MorphemeContext> options) : base(options)
        {
        }

        public DbSet<Morpheme> Morphemes { get; set; }

        // add data seeding
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme("a", new List<string> { "toward" }, Morpheme.MorphemeOrigin.Latin, 1));
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme("-able", new List<string> { "Adjective: worth, ability" }, Morpheme.MorphemeOrigin.Greek, 2));
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme("-fy", new List<string> { "make, form into" }, Morpheme.MorphemeOrigin.Latin, 3));
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme("test", new List<string> { "test" }, Morpheme.MorphemeOrigin.English, 4));

        }
    }
}
