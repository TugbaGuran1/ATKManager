using Microsoft.EntityFrameworkCore.Migrations;

namespace ATKManager.Migrations.AppDb
{
    public partial class CalendarUpdateobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "FullCalendars",
                newName: "ThemeColor");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "FullCalendars",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "FullCalendars",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "FullCalendars",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "AllDay",
                table: "FullCalendars",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "IDCalendar",
                table: "FullCalendars",
                newName: "EventID");

            migrationBuilder.AddColumn<bool>(
                name: "IsFullDay",
                table: "FullCalendars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFullDay",
                table: "FullCalendars");

            migrationBuilder.RenameColumn(
                name: "ThemeColor",
                table: "FullCalendars",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "FullCalendars",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "FullCalendars",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "FullCalendars",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "FullCalendars",
                newName: "AllDay");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "FullCalendars",
                newName: "IDCalendar");
        }
    }
}
