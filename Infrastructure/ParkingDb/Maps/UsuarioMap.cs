using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;

namespace ParkingUNAH.Infrastructure.ParkingDb.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tbUsuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnName("username").HasColumnType("varchar(100)");
            builder.Property(x => x.Password).HasColumnName("password").HasColumnType("varchar(100)");
        }
    }
}
