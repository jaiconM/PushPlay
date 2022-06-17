using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(200);
            builder.Property(x => x.LinkFoto).HasMaxLength(500);
            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email").IsRequired();
            });
            builder.OwnsOne(x => x.Senha, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Senha").IsRequired();
            });

            builder.HasMany(x => x.PlayLists).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
