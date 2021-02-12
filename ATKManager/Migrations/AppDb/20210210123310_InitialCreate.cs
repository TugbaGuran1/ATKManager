using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATKManager.Migrations.AppDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ATK");

            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    CourtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.CourtID);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "CourtSchedule",
                columns: table => new
                {
                    TimeTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourtID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtSchedule", x => x.TimeTableID);
                    table.ForeignKey(
                        name: "FK_CourtSchedule_Court_CourtID",
                        column: x => x.CourtID,
                        principalTable: "Court",
                        principalColumn: "CourtID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourtSchedule_CourtID",
                table: "CourtSchedule",
                column: "CourtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourtSchedule");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Court");
        }
    }
}
