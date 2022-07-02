using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PushPlay.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LinkFoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstiloMusical",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstiloMusical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LinkFoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LinkFoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    ArtistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artista_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayList_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Musica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstiloMusicalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuracaoEmSegundos = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musica_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musica_EstiloMusical_EstiloMusicalId",
                        column: x => x.EstiloMusicalId,
                        principalTable: "EstiloMusical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayListUsuario",
                columns: table => new
                {
                    PlayListsQueSegueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeguidoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListUsuario", x => new { x.PlayListsQueSegueId, x.SeguidoresId });
                    table.ForeignKey(
                        name: "FK_PlayListUsuario_PlayList_PlayListsQueSegueId",
                        column: x => x.PlayListsQueSegueId,
                        principalTable: "PlayList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListUsuario_Usuario_SeguidoresId",
                        column: x => x.SeguidoresId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicaPlayList",
                columns: table => new
                {
                    MusicasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaPlayList", x => new { x.MusicasId, x.PlayListsId });
                    table.ForeignKey(
                        name: "FK_MusicaPlayList_Musica_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaPlayList_PlayList_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "PlayList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstiloMusical",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("12c3bec0-14c1-44fa-bac0-67d8d748a680"), "Samba" },
                    { new Guid("31551f53-a578-4cab-91ea-112dd7629642"), "Lounge" },
                    { new Guid("38cac14c-3b67-40f2-bd80-a2b3eb48a0ba"), "Rock" },
                    { new Guid("7d534f9b-b950-4496-8088-25b001c277d2"), "Forró" },
                    { new Guid("80e6621e-eb1f-4522-beb0-2b6ade0e3a78"), "Sertanejo" },
                    { new Guid("b363b7b3-582f-48dc-8fe1-bb749cbc6b78"), "Eletrônico" },
                    { new Guid("f65bc513-edba-4271-952d-48ac394fae3a"), "MPB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistaId",
                table: "Album",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_AlbumId",
                table: "Musica",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_EstiloMusicalId",
                table: "Musica",
                column: "EstiloMusicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicaPlayList_PlayListsId",
                table: "MusicaPlayList",
                column: "PlayListsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_UsuarioId",
                table: "PlayList",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListUsuario_SeguidoresId",
                table: "PlayListUsuario",
                column: "SeguidoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicaPlayList");

            migrationBuilder.DropTable(
                name: "PlayListUsuario");

            migrationBuilder.DropTable(
                name: "Musica");

            migrationBuilder.DropTable(
                name: "PlayList");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "EstiloMusical");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Artista");
        }
    }
}
