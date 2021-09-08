using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctor_Appointment_WebAPI_BackEnd.Migrations
{
    public partial class Appointment_System : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patient_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patient_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patient_Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Id = table.Column<int>(type: "int", nullable: true),
                    Patient_Id = table.Column<int>(type: "int", nullable: true),
                    Appointment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Details_Doctor_Details_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctor_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Details_Patient_Details_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patient_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Details_Doctor_Id",
                table: "Appointment_Details",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Details_Patient_Id",
                table: "Appointment_Details",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment_Details");

            migrationBuilder.DropTable(
                name: "Doctor_Details");

            migrationBuilder.DropTable(
                name: "Patient_Details");
        }
    }
}
