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
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme
            {
                ID = 1,
                Root = "a",
                dbMeaning = "toward",
                Origin = Morpheme.MorphemeOrigin.Latin,
                RootType = Morpheme.MorphemeType.Root
            });
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme
            {
                ID = 2,
                Root = "-able",
                dbMeaning = "Adjective: worth, Adjective: ability",
                Origin = Morpheme.MorphemeOrigin.Greek,
                RootType = Morpheme.MorphemeType.Suffix
            });
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme
            {
                ID = 3,
                Root = "-fy",
                dbMeaning = "make, form into",
                Origin = Morpheme.MorphemeOrigin.Latin,
                RootType = Morpheme.MorphemeType.Suffix
            });
            modelBuilder.Entity<Morpheme>().HasData(new Morpheme
            {
                ID = 4,
                Root = "test",
                dbMeaning = "test",
                Origin = Morpheme.MorphemeOrigin.English,
                RootType = Morpheme.MorphemeType.Root
            });
        }
    }
}
