using Microsoft.EntityFrameworkCore;
using ParkingUNAH.Infrastructure.ParkingDb.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;
using ParkingUNAH.Infrastructure.ParkingDb.Maps;

namespace ParkingUNAH.Infrastructure.ParkingDb
{
    public class ParkingDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Estacionamiento>? Estacionamiento { get; set; }
        public DbSet<Sector>? Sector { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<EstadisticasSectorDto>? EstadisticasSector { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new SectorMap());
            modelBuilder.ApplyConfiguration(new EstacionamientoMap());
            modelBuilder.ApplyConfiguration(new EstadisticasSectorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
