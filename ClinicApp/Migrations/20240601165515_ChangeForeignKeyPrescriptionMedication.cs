using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeyPrescriptionMedication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionMedicaments",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_IdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionMedicaments",
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_IdPrescription",
                table: "PrescriptionMedicaments",
                column: "IdPrescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionMedicaments",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_IdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionMedicaments",
                table: "PrescriptionMedicaments",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_IdMedicament",
                table: "PrescriptionMedicaments",
                column: "IdMedicament");
        }
    }
}
