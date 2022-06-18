using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class PlayListMapping : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            builder.ToTable("PlayList");
            builder.HasKey(playlist => playlist.Id);

            builder.Property(playlist => playlist.Id).ValueGeneratedOnAdd();
            builder.Property(playlist => playlist.Nome).HasMaxLength(200);

            builder.HasMany(playlist => playlist.Musicas).WithMany(musica => musica.PlayLists);
            builder.HasMany(playlist => playlist.Seguidores).WithMany(musica => musica.PlayListsQueSegue);
        }
    }
}
