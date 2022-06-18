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
                    Sequencia = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("16901d29-6e18-4dec-9676-4250fe03c9f9"), "Sertanejo" },
                    { new Guid("324cdafb-95df-47d1-afda-47a47a0467da"), "Forró" },
                    { new Guid("38a4c33c-368f-429c-8b34-aeebc45a9521"), "Lounge" },
                    { new Guid("71da8f31-6e4d-4653-86e1-31a3e96d02aa"), "Samba" },
                    { new Guid("726775a2-c47e-40c8-abde-0a6d03c96fb5"), "MPB" },
                    { new Guid("b7c939aa-8604-46b4-9af2-54b87d2578fa"), "Rock" },
                    { new Guid("e93cc713-4a9d-4fcd-8a64-e4c3101b5a6c"), "Eletrônico" }
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
