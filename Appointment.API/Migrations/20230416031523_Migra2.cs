using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.API.Migrations
{
    /// <inheritdoc />
    public partial class Migra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doctor_id",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "patient_id",
                table: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doctor_id",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "patient_id",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
