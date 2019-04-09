using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.DAL.Migrations
{
    public partial class DbFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_MemberId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_Users_MemberId",
                table: "TaskAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_MemberId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChange_Users_MemberId",
                table: "TaskStateChange");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Users_MemberId",
                table: "TeamMember");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "TeamMember",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_MemberId",
                table: "TeamMember",
                newName: "IX_TeamMember_UserId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "TaskStateChange",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChange_MemberId",
                table: "TaskStateChange",
                newName: "IX_TaskStateChange_UserId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Tasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_MemberId",
                table: "Tasks",
                newName: "IX_Tasks_UserId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "TaskAssignments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignments_MemberId",
                table: "TaskAssignments",
                newName: "IX_TaskAssignments_UserId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MemberId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Media",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_ParentId",
                table: "Media",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Messages_ParentId",
                table: "Media",
                column: "ParentId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_Users_UserId",
                table: "TaskAssignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChange_Users_UserId",
                table: "TaskStateChange",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Users_UserId",
                table: "TeamMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Messages_ParentId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_Users_UserId",
                table: "TaskAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChange_Users_UserId",
                table: "TaskStateChange");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Users_UserId",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_Media_ParentId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TeamMember",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMember",
                newName: "IX_TeamMember_MemberId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskStateChange",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChange_UserId",
                table: "TaskStateChange",
                newName: "IX_TaskStateChange_MemberId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tasks",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                newName: "IX_Tasks_MemberId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskAssignments",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignments_UserId",
                table: "TaskAssignments",
                newName: "IX_TaskAssignments_MemberId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_MemberId");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Users",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_MemberId",
                table: "Messages",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_Users_MemberId",
                table: "TaskAssignments",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_MemberId",
                table: "Tasks",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChange_Users_MemberId",
                table: "TaskStateChange",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Users_MemberId",
                table: "TeamMember",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
