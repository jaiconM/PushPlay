using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PushPlay.Repository.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstiloMusical",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("20645dbf-a208-47cb-ba00-0cc13af37d36"), "Rock" },
                    { new Guid("3c9782e0-2887-49b2-b058-4fc569567ae9"), "Lounge" },
                    { new Guid("589e9b14-967d-40a8-b645-4d61eafa73b0"), "MPB" },
                    { new Guid("bf7a62a2-98e0-4b68-983b-cb49741a4958"), "Eletrônico" },
                    { new Guid("e492ec06-5cd0-4f62-8304-a50faaebbc5e"), "Forró" },
                    { new Guid("f018a0ed-74a5-4c00-aa94-6342d1bac3bc"), "Samba" },
                    { new Guid("f8ac17f4-df92-45d4-9330-9958f3479fcd"), "Sertanejo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("20645dbf-a208-47cb-ba00-0cc13af37d36"));

            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("3c9782e0-2887-49b2-b058-4fc569567ae9"));

            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("589e9b14-967d-40a8-b645-4d61eafa73b0"));

            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("bf7a62a2-98e0-4b68-983b-cb49741a4958"));

            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("e492ec06-5cd0-4f62-8304-a50faaebbc5e"));

            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("f018a0ed-74a5-4c00-aa94-6342d1bac3bc"));

            migrationBuilder.DeleteData(
                table: "EstiloMusical",
                keyColumn: "Id",
                keyValue: new Guid("f8ac17f4-df92-45d4-9330-9958f3479fcd"));
        }
    }
}
