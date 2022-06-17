using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("Musica");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Sequencia).IsRequired();
            builder.HasOne(x => x.EstiloMusical);

            builder.OwnsOne(x => x.Duracao, p =>
            {
                p.Property(f => f.Valor).HasColumnName("DuracaoEmSegundos").IsRequired();
            });
        }
    }
}
