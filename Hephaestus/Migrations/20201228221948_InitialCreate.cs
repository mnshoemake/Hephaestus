using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hephaestus.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Epithet = table.Column<string>(nullable: false),
                    EpithetDie = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameDie = table.Column<int>(nullable: false),
                    Lineage = table.Column<string>(nullable: true),
                    IsDemigod = table.Column<bool>(nullable: false),
                    Pronouns = table.Column<string>(nullable: true),
                    HonoredGod = table.Column<string>(nullable: true),
                    Strength = table.Column<string>(nullable: true),
                    ArtsAndOrationDie = table.Column<int>(nullable: false),
                    BloodAndValorDie = table.Column<int>(nullable: false),
                    CraftAndReasonDie = table.Column<int>(nullable: false),
                    ResolveAndSpiritDie = table.Column<int>(nullable: false),
                    FavorGodName1 = table.Column<string>(nullable: true),
                    FavorGodName2 = table.Column<string>(nullable: true),
                    FavorGodName3 = table.Column<string>(nullable: true),
                    FavorGodName4 = table.Column<string>(nullable: true),
                    FavorScore1 = table.Column<int>(nullable: false),
                    FavorScore2 = table.Column<int>(nullable: false),
                    FavorScore3 = table.Column<int>(nullable: false),
                    FavorScore4 = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_UserId",
                table: "Heroes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
