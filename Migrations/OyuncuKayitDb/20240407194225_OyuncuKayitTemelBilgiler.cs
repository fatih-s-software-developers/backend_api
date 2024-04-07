using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend_api.Migrations.OyuncuKayitDb
{
    /// <inheritdoc />
    public partial class OyuncuKayitTemelBilgiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OyuncuTemelBilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Adi = table.Column<string>(type: "text", nullable: false),
                    Soyadi = table.Column<string>(type: "text", nullable: false),
                    Ulke = table.Column<string>(type: "text", nullable: false),
                    Il = table.Column<string>(type: "text", nullable: false),
                    TelefonNumarasi = table.Column<string>(type: "text", nullable: false),
                    EpostaAdresi = table.Column<string>(type: "text", nullable: false),
                    Cinsiyet = table.Column<string>(type: "text", nullable: false),
                    DogumYili = table.Column<int>(type: "integer", nullable: false),
                    BedenOlcusu = table.Column<string>(type: "text", nullable: false),
                    OyunSeviye = table.Column<int>(type: "integer", nullable: false),
                    DahaOnceKatildiMi = table.Column<bool>(type: "boolean", nullable: false),
                    Oyuncu_Unic_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyuncuTemelBilgiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DahaOnceKatildigiLigTablo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oyuncuTemelBilgilerTabloId = table.Column<int>(type: "integer", nullable: false),
                    UlusalLiglerdeOynadiMi = table.Column<bool>(type: "boolean", nullable: false),
                    LigAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DahaOnceKatildigiLigTablo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DahaOnceKatildigiLigTablo_OyuncuTemelBilgiler_oyuncuTemelBi~",
                        column: x => x.oyuncuTemelBilgilerTabloId,
                        principalTable: "OyuncuTemelBilgiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MacEsTablo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oyuncuTemelBilgilerTabloId = table.Column<int>(type: "integer", nullable: false),
                    CiftMacTercihi = table.Column<bool>(type: "boolean", nullable: false),
                    CiftEsAdi = table.Column<string>(type: "text", nullable: false),
                    KarisikMacTercihi = table.Column<bool>(type: "boolean", nullable: false),
                    KarisikEsAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacEsTablo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MacEsTablo_OyuncuTemelBilgiler_oyuncuTemelBilgilerTabloId",
                        column: x => x.oyuncuTemelBilgilerTabloId,
                        principalTable: "OyuncuTemelBilgiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UcretTablo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oyuncuTemelBilgilerTabloId = table.Column<int>(type: "integer", nullable: false),
                    UcretOdemesiYapildiMi = table.Column<bool>(type: "boolean", nullable: false),
                    OdemeYapanKisininAdiSoyadi = table.Column<string>(type: "text", nullable: false),
                    OdemeYapilmasiPlanlananTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UcretTablo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UcretTablo_OyuncuTemelBilgiler_oyuncuTemelBilgilerTabloId",
                        column: x => x.oyuncuTemelBilgilerTabloId,
                        principalTable: "OyuncuTemelBilgiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DahaOnceKatildigiLigTablo_oyuncuTemelBilgilerTabloId",
                table: "DahaOnceKatildigiLigTablo",
                column: "oyuncuTemelBilgilerTabloId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MacEsTablo_oyuncuTemelBilgilerTabloId",
                table: "MacEsTablo",
                column: "oyuncuTemelBilgilerTabloId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UcretTablo_oyuncuTemelBilgilerTabloId",
                table: "UcretTablo",
                column: "oyuncuTemelBilgilerTabloId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DahaOnceKatildigiLigTablo");

            migrationBuilder.DropTable(
                name: "MacEsTablo");

            migrationBuilder.DropTable(
                name: "UcretTablo");

            migrationBuilder.DropTable(
                name: "OyuncuTemelBilgiler");
        }
    }
}
