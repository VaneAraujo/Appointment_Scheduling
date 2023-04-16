using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.API.Migrations
{
    /// <inheritdoc />
    public partial class Migra1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bussiness_start_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bussiness_end_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idpaciente = table.Column<int>(name: "Id paciente", type: "int", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    Idmédico = table.Column<int>(name: "Id médico", type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    appointment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appointment_start_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    appointment_end_time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_Id médico",
                        column: x => x.Idmédico,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_Id paciente",
                        column: x => x.Idpaciente,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_role_id",
                table: "Roles",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Id médico",
                table: "Schedules",
                column: "Id médico");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Id paciente",
                table: "Schedules",
                column: "Id paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_order_id",
                table: "Schedules",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_id",
                table: "Users",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
