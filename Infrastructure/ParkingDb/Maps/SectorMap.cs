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
            builder.Property(x => x.LatitudMin).HasColumnName("latitudMin").HasColumnType("numeric(18,6)");
            builder.Property(x => x.LongitudMin).HasColumnName("longitudMin").HasColumnType("numeric(18,6)");
            builder.Property(x => x.LatitudMax).HasColumnName("latitudMax").HasColumnType("numeric(18,6)");
            builder.Property(x => x.LongitudMax).HasColumnName("longitudMax").HasColumnType("numeric(18,6)");
        }
    }
}
