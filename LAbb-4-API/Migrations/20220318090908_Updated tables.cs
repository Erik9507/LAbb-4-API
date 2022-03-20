using Microsoft.EntityFrameworkCore.Migrations;

namespace LAbb_4_API.Migrations
{
    public partial class Updatedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterestsId",
                table: "webbAdresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "personId",
                table: "interests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_webbAdresses_InterestsId",
                table: "webbAdresses",
                column: "InterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_interests_personId",
                table: "interests",
                column: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_interests_People_personId",
                table: "interests",
                column: "personId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_webbAdresses_interests_InterestsId",
                table: "webbAdresses",
                column: "InterestsId",
                principalTable: "interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interests_People_personId",
                table: "interests");

            migrationBuilder.DropForeignKey(
                name: "FK_webbAdresses_interests_InterestsId",
                table: "webbAdresses");

            migrationBuilder.DropIndex(
                name: "IX_webbAdresses_InterestsId",
                table: "webbAdresses");

            migrationBuilder.DropIndex(
                name: "IX_interests_personId",
                table: "interests");

            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "webbAdresses");

            migrationBuilder.DropColumn(
                name: "personId",
                table: "interests");
        }
    }
}
