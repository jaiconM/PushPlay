﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushPlay.Domain.Entidades;

namespace PushPlay.Repository.Mapeamento
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("Musica");
            builder.HasKey(musica => musica.Id);

            builder.Property(musica => musica.Id).ValueGeneratedOnAdd();
            builder.Property(musica => musica.Nome).IsRequired().HasMaxLength(200);
            builder.Property(musica => musica.Sequencia).IsRequired();
            builder.HasOne(musica => musica.EstiloMusical);
            builder.HasMany(musica => musica.PlayLists).WithMany(playlist => playlist.Musicas);

            builder.OwnsOne(musica => musica.Duracao, musicaDuracao =>
            {
                musicaDuracao.Property(duracao => duracao.Valor).HasColumnName("DuracaoEmSegundos").IsRequired();
            });
        }
    }
}
