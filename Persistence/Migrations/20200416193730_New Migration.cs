using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNowApply",
                table: "HistoryMedications");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "HistoryDiseases");

            migrationBuilder.DropColumn(
                name: "IsNowSick",
                table: "HistoryDiseases");

            migrationBuilder.DropColumn(
                name: "IsNowSick",
                table: "HistoryAllergies");

            migrationBuilder.RenameColumn(
                name: "NameVaccination",
                table: "Vaccinations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "NameMedication",
                table: "Medications",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "NameDisease",
                table: "Diseases",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "NameAllergy",
                table: "Allergies",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Vaccinations",
                newName: "NameVaccination");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Medications",
                newName: "NameMedication");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Diseases",
                newName: "NameDisease");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Allergies",
                newName: "NameAllergy");

            migrationBuilder.AddColumn<bool>(
                name: "IsNowApply",
                table: "HistoryMedications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "HistoryDiseases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsNowSick",
                table: "HistoryDiseases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNowSick",
                table: "HistoryAllergies",
                nullable: false,
                defaultValue: false);
        }
    }
}
