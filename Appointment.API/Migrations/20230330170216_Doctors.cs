using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.API.Migrations
{
    /// <inheritdoc />
    public partial class Doctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Name",
                table: "Patient",
                newName: "IX_Patient_Name");

            migrationBuilder.AddColumn<int>(
                name: "DocumentNumber",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EPS",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarjeta_prof = table.Column<int>(type: "int", nullable: false),
                    Inicio_horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin_horario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Name",
                table: "Doctors",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "EPS",
                table: "Patient");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_Name",
                table: "Patients",
                newName: "IX_Patients_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");
        }
    }
}
