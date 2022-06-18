using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class EstiloMusicalMapping : IEntityTypeConfiguration<EstiloMusical>
    {
        public void Configure(EntityTypeBuilder<EstiloMusical> builder)
        {
            builder.ToTable("EstiloMusical");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(200);

            builder.HasData(
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "Rock" },
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "Eletrônico" },
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "Lounge" },
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "Sertanejo" },
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "Samba" },
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "Forró" },
                new EstiloMusical { Id = Guid.NewGuid(), Nome = "MPB" }
           );
        }
    }
}
