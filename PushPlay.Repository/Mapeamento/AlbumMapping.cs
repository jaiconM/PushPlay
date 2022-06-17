using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(200);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.LinkFoto).HasMaxLength(500);
            builder.Property(x => x.Ano).IsRequired();

            builder.HasMany(x => x.Musicas).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
