using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AliciMusteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isim = table.Column<string>(type: "text", nullable: true),
                    CepTelefonNo = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EvTuru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliciMusteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmlakIsletmesi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsletmeAdi = table.Column<string>(type: "text", nullable: true),
                    Yetkili = table.Column<string>(type: "text", nullable: true),
                    TelefonNo = table.Column<int>(type: "integer", nullable: false),
                    Fax = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmlakIsletmesi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaticiMusteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isim = table.Column<string>(type: "text", nullable: true),
                    CepTelefonNo = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EvTuru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaticiMusteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emlak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmlakTuru = table.Column<string>(type: "text", nullable: true),
                    Alan = table.Column<int>(type: "integer", nullable: false),
                    OdaSayisi = table.Column<int>(type: "integer", nullable: false),
                    Kat = table.Column<string>(type: "text", nullable: true),
                    BinaKati = table.Column<int>(type: "integer", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MusteriSaticiId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emlak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emlak_SaticiMusteriler_MusteriSaticiId",
                        column: x => x.MusteriSaticiId,
                        principalTable: "SaticiMusteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emlak_MusteriSaticiId",
                table: "Emlak",
                column: "MusteriSaticiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AliciMusteriler");

            migrationBuilder.DropTable(
                name: "Emlak");

            migrationBuilder.DropTable(
                name: "EmlakIsletmesi");

            migrationBuilder.DropTable(
                name: "SaticiMusteriler");
        }
    }
}
