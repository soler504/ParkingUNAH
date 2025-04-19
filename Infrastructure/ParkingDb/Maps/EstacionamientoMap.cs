using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;

namespace ParkingUNAH.Infrastructure.ParkingDb.Maps
{
    public class EstacionamientoMap : IEntityTypeConfiguration<Estacionamiento>
    {
        public void Configure(EntityTypeBuilder<Estacionamiento> builder)
        {
            builder.ToTable("tbEstacionamiento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Posicion).HasColumnName("posicion").HasColumnType("int");
            builder.Property(x => x.SectorId).HasColumnName("sectorId").HasColumnType("int");
            builder.Property(x => x.EstaOcupado).HasColumnName("estaOcupado").HasColumnType("bit");
            builder.Property(x => x.EsActivo).HasColumnName("esActivo").HasColumnType("bit");
        }
    }
}
