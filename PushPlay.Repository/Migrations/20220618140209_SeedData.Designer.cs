﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PushPlay.Repository.Contexto;

#nullable disable

namespace PushPlay.Repository.Migrations
{
    [DbContext(typeof(PushPlayContext))]
    [Migration("20220618140209_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PushPlay.Domain.Entidades.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<Guid?>("ArtistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LinkFoto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Artista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LinkFoto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artista", (string)null);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.EstiloMusical", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EstiloMusical", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("20645dbf-a208-47cb-ba00-0cc13af37d36"),
                            Nome = "Rock"
                        },
                        new
                        {
                            Id = new Guid("bf7a62a2-98e0-4b68-983b-cb49741a4958"),
                            Nome = "Eletrônico"
                        },
                        new
                        {
                            Id = new Guid("3c9782e0-2887-49b2-b058-4fc569567ae9"),
                            Nome = "Lounge"
                        },
                        new
                        {
                            Id = new Guid("f8ac17f4-df92-45d4-9330-9958f3479fcd"),
                            Nome = "Sertanejo"
                        },
                        new
                        {
                            Id = new Guid("f018a0ed-74a5-4c00-aa94-6342d1bac3bc"),
                            Nome = "Samba"
                        },
                        new
                        {
                            Id = new Guid("e492ec06-5cd0-4f62-8304-a50faaebbc5e"),
                            Nome = "Forró"
                        },
                        new
                        {
                            Id = new Guid("589e9b14-967d-40a8-b645-4d61eafa73b0"),
                            Nome = "MPB"
                        });
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstiloMusicalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("PlayListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sequencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("EstiloMusicalId");

                    b.HasIndex("PlayListId");

                    b.ToTable("Musica", (string)null);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.PlayList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PlayList", (string)null);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkFoto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Album", b =>
                {
                    b.HasOne("PushPlay.Domain.Entidades.Artista", null)
                        .WithMany("Albuns")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Musica", b =>
                {
                    b.HasOne("PushPlay.Domain.Entidades.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PushPlay.Domain.Entidades.EstiloMusical", "EstiloMusical")
                        .WithMany()
                        .HasForeignKey("EstiloMusicalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PushPlay.Domain.Entidades.PlayList", null)
                        .WithMany("Musicas")
                        .HasForeignKey("PlayListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("PushPlay.Domain.ValueObjects.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("DuracaoEmSegundos");

                            b1.HasKey("MusicaId");

                            b1.ToTable("Musica");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

                    b.Navigation("Duracao")
                        .IsRequired();

                    b.Navigation("EstiloMusical");
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.PlayList", b =>
                {
                    b.HasOne("PushPlay.Domain.Entidades.Usuario", null)
                        .WithMany("PlayLists")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Usuario", b =>
                {
                    b.OwnsOne("PushPlay.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("PushPlay.Domain.ValueObjects.Senha", "Senha", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Senha");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Senha")
                        .IsRequired();
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Artista", b =>
                {
                    b.Navigation("Albuns");
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.PlayList", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("PushPlay.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("PlayLists");
                });
#pragma warning restore 612, 618
        }
    }
}
