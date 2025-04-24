using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingUNAH.Infrastructure.ParkingDb.Dtos;

namespace ParkingUNAH.Infrastructure.ParkingDb.Maps
{
    public class EstadisticasSectorMap : IEntityTypeConfiguration<EstadisticasSectorDto>
    {
        public void Configure(EntityTypeBuilder<EstadisticasSectorDto> builder)
        {
            builder.HasNoKey();
        }
    }
}
