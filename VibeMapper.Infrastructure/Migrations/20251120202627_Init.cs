using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VibeMapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chemicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CASNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ECNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DNELs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExposureRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExposedGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExposureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChemicalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNELs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DNELs_Chemicals_ChemicalId",
                        column: x => x.ChemicalId,
                        principalTable: "Chemicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PNECs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChemicalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNECs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PNECs_Chemicals_ChemicalId",
                        column: x => x.ChemicalId,
                        principalTable: "Chemicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DNELs_ChemicalId",
                table: "DNELs",
                column: "ChemicalId");

            migrationBuilder.CreateIndex(
                name: "IX_PNECs_ChemicalId",
                table: "PNECs",
                column: "ChemicalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DNELs");

            migrationBuilder.DropTable(
                name: "PNECs");

            migrationBuilder.DropTable(
                name: "Chemicals");
        }
    }
}
