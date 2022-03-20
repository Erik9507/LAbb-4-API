using Microsoft.EntityFrameworkCore.Migrations;

namespace LAbb_4_API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "interests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(nullable: true),
                    InterestDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interests", x => x.Id);
                });

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
                name: "webbAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebbSiteName = table.Column<string>(nullable: true),
                    webbAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_webbAdresses", x => x.Id);
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
                table: "interests",
                columns: new[] { "Id", "InterestDescription", "InterestName" },
                values: new object[,]
                {
                    { 1, "Padel is a racquet sport that combines the elements of tennis, squash and badminton.", "Padel" },
                    { 2, "A sport in which participants climb up, down or across natural rock formations or artificial rock walls.", "Rock climbing" },
                    { 3, "Coding makes it possible for us to create computer software, games, apps and websites.", "Coding" },
                    { 4, "Surfing is the sport of riding waves in an upright or prone position. Surfers catch the ocean, river, or man-made waves and glide across the surface", "Surfing" }
                });

            migrationBuilder.InsertData(
                table: "webbAdresses",
                columns: new[] { "Id", "WebbSiteName", "webbAdress" },
                values: new object[,]
                {
                    { 1, "World Padel Tour", "https://www.worldpadeltour.com/en" },
                    { 2, "Climb Europe", "https://climb-europe.com/" },
                    { 3, "Code Cademy", "https://www.codecademy.com/" },
                    { 4, "Surfer Today", "https://www.surfertoday.com/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interests");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "webbAdresses");
        }
    }
}
