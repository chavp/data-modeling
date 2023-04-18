using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Organizations.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "organization");

            migrationBuilder.CreateTable(
                name: "Parties",
                schema: "organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartyType = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Team_Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Level = table.Column<decimal>(type: "TEXT", nullable: true),
                    HP = table.Column<decimal>(type: "TEXT", nullable: true),
                    MP = table.Column<decimal>(type: "TEXT", nullable: true),
                    Strength = table.Column<decimal>(type: "TEXT", nullable: true),
                    Agility = table.Column<decimal>(type: "TEXT", nullable: true),
                    Resilience = table.Column<decimal>(type: "TEXT", nullable: true),
                    Experience = table.Column<decimal>(type: "TEXT", nullable: true),
                    PartyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Parties_PartyId",
                        column: x => x.PartyId,
                        principalSchema: "organization",
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Name",
                schema: "organization",
                table: "Parties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Team_Name",
                schema: "organization",
                table: "Parties",
                column: "Team_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PartyId",
                schema: "organization",
                table: "Stats",
                column: "PartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats",
                schema: "organization");

            migrationBuilder.DropTable(
                name: "Parties",
                schema: "organization");
        }
    }
}
