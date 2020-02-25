using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeloVMONT.Data
{
    public class BikeStationsVelovMontContext : DbContext
    {
        public BikeStationsVelovMontContext(DbContextOptions<BikeStationsVelovMontContext> options) : base(options)
        {
        }
        public DbSet<Models.Favoris> Favoris { get; set; }
        public DbSet<Models.SupportBike> SupportBke { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Favoris>().ToTable("Favoris");
            modelBuilder.Entity<Models.SupportBike>().ToTable("SupportBike");
        }
    }
}
