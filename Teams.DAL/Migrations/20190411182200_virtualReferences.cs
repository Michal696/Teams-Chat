using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.DAL.Migrations
{
    public partial class virtualReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsUserPermissions_Users_MemberId",
                table: "GroupsUserPermissions");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "GroupsUserPermissions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupsUserPermissions_MemberId",
                table: "GroupsUserPermissions",
                newName: "IX_GroupsUserPermissions_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUserPermissions_Users_UserId",
                table: "GroupsUserPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsUserPermissions_Users_UserId",
                table: "GroupsUserPermissions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GroupsUserPermissions",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupsUserPermissions_UserId",
                table: "GroupsUserPermissions",
                newName: "IX_GroupsUserPermissions_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUserPermissions_Users_MemberId",
                table: "GroupsUserPermissions",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
