using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixedMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_AspNetUsers_UserIdId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_UserIdId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Records");

            migrationBuilder.AddColumn<long>(
                name: "PacientId",
                table: "Records",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameAllergy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameDisease = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameMedication = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameVaccination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryAllergies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    IsNowSick = table.Column<bool>(nullable: false),
                    AllergiesId = table.Column<long>(nullable: false),
                    PacientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryAllergies", x => new { x.AllergiesId, x.PacientId });
                    table.ForeignKey(
                        name: "FK_HistoryAllergies_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryAllergies_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryDiseases",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsNowSick = table.Column<bool>(nullable: false),
                    DiseasesId = table.Column<long>(nullable: false),
                    PacientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryDiseases", x => new { x.DiseasesId, x.PacientId, x.Id });
                    table.ForeignKey(
                        name: "FK_HistoryDiseases_Diseases_DiseasesId",
                        column: x => x.DiseasesId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryDiseases_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryMedications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    IsNowApply = table.Column<bool>(nullable: false),
                    MedicationsId = table.Column<long>(nullable: false),
                    PacientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryMedications", x => new { x.MedicationsId, x.PacientId });
                    table.ForeignKey(
                        name: "FK_HistoryMedications_Medications_MedicationsId",
                        column: x => x.MedicationsId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryMedications_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryVaccinations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PacientId = table.Column<long>(nullable: false),
                    VaccinationsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryVaccinations", x => new { x.VaccinationsId, x.PacientId });
                    table.ForeignKey(
                        name: "FK_HistoryVaccinations_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryVaccinations_Vaccinations_VaccinationsId",
                        column: x => x.VaccinationsId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_PacientId",
                table: "Records",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAllergies_PacientId",
                table: "HistoryAllergies",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryDiseases_PacientId",
                table: "HistoryDiseases",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryMedications_PacientId",
                table: "HistoryMedications",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryVaccinations_PacientId",
                table: "HistoryVaccinations",
                column: "PacientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Pacients_PacientId",
                table: "Records",
                column: "PacientId",
                principalTable: "Pacients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Pacients_PacientId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "HistoryAllergies");

            migrationBuilder.DropTable(
                name: "HistoryDiseases");

            migrationBuilder.DropTable(
                name: "HistoryMedications");

            migrationBuilder.DropTable(
                name: "HistoryVaccinations");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Records_PacientId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "PacientId",
                table: "Records");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Records",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserIdId",
                table: "Records",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_AspNetUsers_UserIdId",
                table: "Records",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
