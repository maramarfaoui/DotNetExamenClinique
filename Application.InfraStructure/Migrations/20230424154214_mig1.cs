using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinique",
                columns: table => new
                {
                    CliniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NumTel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinique", x => x.CliniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddresseEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumDossier = table.Column<int>(type: "int", nullable: false),
                    NumTel = table.Column<int>(type: "int", nullable: false),
                    NomComplet_Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomComplet_Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Chambre",
                columns: table => new
                {
                    NumeroChambre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliniqueFk = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    typeChambre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambre", x => x.NumeroChambre);
                    table.ForeignKey(
                        name: "FK_Chambre_Clinique_CliniqueFk",
                        column: x => x.CliniqueFk,
                        principalTable: "Clinique",
                        principalColumn: "CliniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admission",
                columns: table => new
                {
                    DateAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChambreFk = table.Column<int>(type: "int", nullable: false),
                    PatientFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MotifAdmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbJours = table.Column<int>(type: "int", nullable: false),
                    chambreNumeroChambre = table.Column<int>(type: "int", nullable: false),
                    patientCIN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission", x => new { x.DateAdmission, x.ChambreFk, x.PatientFk });
                    table.ForeignKey(
                        name: "FK_Admission_Chambre_chambreNumeroChambre",
                        column: x => x.chambreNumeroChambre,
                        principalTable: "Chambre",
                        principalColumn: "NumeroChambre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admission_Patient_patientCIN",
                        column: x => x.patientCIN,
                        principalTable: "Patient",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admission_chambreNumeroChambre",
                table: "Admission",
                column: "chambreNumeroChambre");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_patientCIN",
                table: "Admission",
                column: "patientCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Chambre_CliniqueFk",
                table: "Chambre",
                column: "CliniqueFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admission");

            migrationBuilder.DropTable(
                name: "Chambre");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Clinique");
        }
    }
}
