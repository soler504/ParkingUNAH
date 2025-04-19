using Microsoft.EntityFrameworkCore;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;
using ParkingUNAH.Infrastructure.ParkingDb.Maps;

namespace ParkingUNAH.Infrastructure.ParkingDb
{
    public class ParkingDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Estacionamiento>? Estacionamiento { get; set; }
        public DbSet<Sector>? Sector { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SectorMap());
            modelBuilder.ApplyConfiguration(new EstacionamientoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
