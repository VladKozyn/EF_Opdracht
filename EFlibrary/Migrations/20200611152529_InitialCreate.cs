using Microsoft.EntityFrameworkCore.Migrations;

namespace EFlibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    StamNummer = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Bijnaam = table.Column<string>(nullable: true),
                    Trainer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.StamNummer);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Rugnummer = table.Column<int>(nullable: false),
                    Waarde = table.Column<int>(nullable: false),
                    TeamStamnummer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spelers_Teams_TeamStamnummer",
                        column: x => x.TeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "StamNummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpelerWaarde = table.Column<int>(nullable: false),
                    oudTeamStamNummer = table.Column<int>(nullable: true),
                    SpelerId = table.Column<int>(nullable: false),
                    NieuwTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_NieuwTeamId",
                        column: x => x.NieuwTeamId,
                        principalTable: "Teams",
                        principalColumn: "StamNummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Spelers_SpelerId",
                        column: x => x.SpelerId,
                        principalTable: "Spelers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_oudTeamStamNummer",
                        column: x => x.oudTeamStamNummer,
                        principalTable: "Teams",
                        principalColumn: "StamNummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_TeamStamnummer",
                table: "Spelers",
                column: "TeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_NieuwTeamId",
                table: "Transfers",
                column: "NieuwTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SpelerId",
                table: "Transfers",
                column: "SpelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_oudTeamStamNummer",
                table: "Transfers",
                column: "oudTeamStamNummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
