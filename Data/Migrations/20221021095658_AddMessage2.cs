using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Data.Migrations
{
    public partial class AddMessage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Message_MessageId",
                table: "TravelPackages");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_MessageId",
                table: "TravelPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "TravelPackages");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "TravelPackageId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TravelPackageId",
                table: "Messages",
                column: "TravelPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_TravelPackages_TravelPackageId",
                table: "Messages",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_TravelPackages_TravelPackageId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TravelPackageId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TravelPackageId",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "TravelPackages",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_MessageId",
                table: "TravelPackages",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Message_MessageId",
                table: "TravelPackages",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }
    }
}
