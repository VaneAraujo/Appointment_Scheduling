using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.API.Migrations
{
    /// <inheritdoc />
    public partial class Migra3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_Id médico",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_Id paciente",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Id paciente",
                table: "Schedules",
                newName: "patient_id");

            migrationBuilder.RenameColumn(
                name: "Id médico",
                table: "Schedules",
                newName: "doctor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Id paciente",
                table: "Schedules",
                newName: "IX_Schedules_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Id médico",
                table: "Schedules",
                newName: "IX_Schedules_doctor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_doctor_id",
                table: "Schedules",
                column: "doctor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_patient_id",
                table: "Schedules",
                column: "patient_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_doctor_id",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_patient_id",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "Schedules",
                newName: "Id paciente");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "Schedules",
                newName: "Id médico");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_patient_id",
                table: "Schedules",
                newName: "IX_Schedules_Id paciente");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_doctor_id",
                table: "Schedules",
                newName: "IX_Schedules_Id médico");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_Id médico",
                table: "Schedules",
                column: "Id médico",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_Id paciente",
                table: "Schedules",
                column: "Id paciente",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
