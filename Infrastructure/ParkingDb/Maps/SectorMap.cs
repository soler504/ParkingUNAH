using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;

namespace ParkingUNAH.Infrastructure.ParkingDb.Maps
{
    public class SectorMap : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("tbSector");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasColumnType("varchar(100)");
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasColumnType("varchar(100)");
            builder.Property(x => x.Coordenadas).HasColumnName("coordenadas").HasColumnType("varchar(100)");
        }
    }
}
