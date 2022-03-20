using Microsoft.EntityFrameworkCore.Migrations;

namespace LAbb_4_API.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interests_People_personId",
                table: "interests");

            migrationBuilder.DropForeignKey(
                name: "FK_webbAdresses_interests_InterestsId",
                table: "webbAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_webbAdresses",
                table: "webbAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interests",
                table: "interests");

            migrationBuilder.RenameTable(
                name: "webbAdresses",
                newName: "WebbAdresses");

            migrationBuilder.RenameTable(
                name: "interests",
                newName: "Interests");

            migrationBuilder.RenameColumn(
                name: "webbAdress",
                table: "WebbAdresses",
                newName: "Webbadress");

            migrationBuilder.RenameIndex(
                name: "IX_webbAdresses_InterestsId",
                table: "WebbAdresses",
                newName: "IX_WebbAdresses_InterestsId");

            migrationBuilder.RenameIndex(
                name: "IX_interests_personId",
                table: "Interests",
                newName: "IX_Interests_personId");

            migrationBuilder.AddColumn<int>(
                name: "FInterestId",
                table: "WebbAdresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FPersonId",
                table: "Interests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebbAdresses",
                table: "WebbAdresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interests",
                table: "Interests",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                column: "FPersonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                column: "FPersonId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                column: "FPersonId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                column: "FPersonId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "WebbAdresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "FInterestId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WebbAdresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "FInterestId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "WebbAdresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "FInterestId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "WebbAdresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "FInterestId",
                value: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_People_personId",
                table: "Interests",
                column: "personId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WebbAdresses_Interests_InterestsId",
                table: "WebbAdresses",
                column: "InterestsId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_People_personId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_WebbAdresses_Interests_InterestsId",
                table: "WebbAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebbAdresses",
                table: "WebbAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interests",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "FInterestId",
                table: "WebbAdresses");

            migrationBuilder.DropColumn(
                name: "FPersonId",
                table: "Interests");

            migrationBuilder.RenameTable(
                name: "WebbAdresses",
                newName: "webbAdresses");

            migrationBuilder.RenameTable(
                name: "Interests",
                newName: "interests");

            migrationBuilder.RenameColumn(
                name: "Webbadress",
                table: "webbAdresses",
                newName: "webbAdress");

            migrationBuilder.RenameIndex(
                name: "IX_WebbAdresses_InterestsId",
                table: "webbAdresses",
                newName: "IX_webbAdresses_InterestsId");

            migrationBuilder.RenameIndex(
                name: "IX_Interests_personId",
                table: "interests",
                newName: "IX_interests_personId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_webbAdresses",
                table: "webbAdresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_interests",
                table: "interests",
                column: "Id");

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
    }
}
