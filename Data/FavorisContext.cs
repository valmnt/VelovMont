using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeloVMONT.Data
{
    public class FavorisContext : DbContext
    {
        public FavorisContext(DbContextOptions<FavorisContext> options) : base(options)
        {
        }
        public DbSet<Models.Favoris> Favoris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Favoris>().ToTable("Favoris");
        }
    }
}
