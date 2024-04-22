using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brukere",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    epost = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    tlf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brukere__3213E83F0C61AA8E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prisdata",
                columns: table => new
                {
                    kvalitet = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: false),
                    pris = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__prisdata__6801686609B89173", x => x.kvalitet);
                });

            migrationBuilder.CreateTable(
                name: "romdata",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kvalitet = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: false),
                    antall_senger = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__romdata__3213E83F5EF89C12", x => x.id);
                    table.ForeignKey(
                        name: "FK__romdata__antall___02084FDA",
                        column: x => x.kvalitet,
                        principalTable: "prisdata",
                        principalColumn: "kvalitet");
                });

            migrationBuilder.CreateTable(
                name: "bookingdata",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rom_id = table.Column<int>(type: "INTEGER", nullable: false),
                    startdato = table.Column<DateTime>(type: "datetime", nullable: false),
                    sluttdato = table.Column<DateTime>(type: "datetime", nullable: false),
                    antall_personer = table.Column<int>(type: "INTEGER", nullable: false),
                    bruker = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bookingd__3213E83FFC66BD4D", x => x.id);
                    table.ForeignKey(
                        name: "FK__bookingda__bruke__07C12930",
                        column: x => x.bruker,
                        principalTable: "brukere",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__bookingda__rom_i__06CD04F7",
                        column: x => x.rom_id,
                        principalTable: "romdata",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingdata_bruker",
                table: "bookingdata",
                column: "bruker");

            migrationBuilder.CreateIndex(
                name: "IX_bookingdata_rom_id",
                table: "bookingdata",
                column: "rom_id");

            migrationBuilder.CreateIndex(
                name: "IX_romdata_kvalitet",
                table: "romdata",
                column: "kvalitet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingdata");

            migrationBuilder.DropTable(
                name: "brukere");

            migrationBuilder.DropTable(
                name: "romdata");

            migrationBuilder.DropTable(
                name: "prisdata");
        }
    }
}
