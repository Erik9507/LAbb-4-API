using Microsoft.EntityFrameworkCore.Migrations;

namespace LAbb_4_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(nullable: true),
                    InterestDescription = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebbAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebbSiteName = table.Column<string>(nullable: true),
                    Webbadress = table.Column<string>(nullable: true),
                    InterestsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebbAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebbAdresses_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Viktor", "0701234599" },
                    { 2, "Lukas", "0704593288" },
                    { 3, "Erik", "0707842511" },
                    { 4, "Simon", "0738432077" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "InterestDescription", "InterestName", "PersonId" },
                values: new object[,]
                {
                    { 1, "Padel is a racquet sport that combines the elements of tennis, squash and badminton.", "Padel", 1 },
                    { 3, "Coding makes it possible for us to create computer software, games, apps and websites.", "Coding", 1 },
                    { 2, "A sport in which participants climb up, down or across natural rock formations or artificial rock walls.", "Rock climbing", 2 },
                    { 4, "Surfing is the sport of riding waves in an upright or prone position. Surfers catch the ocean, river, or man-made waves and glide across the surface", "Surfing", 4 }
                });

            migrationBuilder.InsertData(
                table: "WebbAdresses",
                columns: new[] { "Id", "InterestsId", "WebbSiteName", "Webbadress" },
                values: new object[,]
                {
                    { 1, 1, "World Padel Tour", "https://www.worldpadeltour.com/en" },
                    { 3, 3, "Code Cademy", "https://www.codecademy.com/" },
                    { 2, 2, "Climb Europe", "https://climb-europe.com/" },
                    { 4, 4, "Surfer Today", "https://www.surfertoday.com/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WebbAdresses_InterestsId",
                table: "WebbAdresses",
                column: "InterestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebbAdresses");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
