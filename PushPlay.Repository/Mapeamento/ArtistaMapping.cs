using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class ArtistaMapping : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artista");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.LinkFoto).HasMaxLength(500);
            builder.Property(x => x.Tipo);

            builder.HasMany(x => x.Albuns).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
