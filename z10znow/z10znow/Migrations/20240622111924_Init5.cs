using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace z10znow.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerscriptionMedicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPerscription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerscriptionMedicaments", x => new { x.IdMedicament, x.IdPerscription });
                    table.ForeignKey(
                        name: "FK_PerscriptionMedicaments_Medicaments_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerscriptionMedicaments_Perscriptions_IdPerscription",
                        column: x => x.IdPerscription,
                        principalTable: "Perscriptions",
                        principalColumn: "IdPerscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerscriptionMedicaments_IdPerscription",
                table: "PerscriptionMedicaments",
                column: "IdPerscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerscriptionMedicaments");
        }
    }
}
