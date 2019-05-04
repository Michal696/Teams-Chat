using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.DAL.Migrations
{
    public partial class renameTeamsToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsUserPermissions_Users_MemberId",
                table: "GroupsUserPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_TaskStateChange_TaskStateChangeId",
                table: "TaskAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChange_Groups_GroupId",
                table: "TaskStateChange");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChange_Tasks_TaskId",
                table: "TaskStateChange");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChange_Users_UserId",
                table: "TaskStateChange");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Team_TeamId",
                table: "TeamMember");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Users_UserId",
                table: "TeamMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStateChange",
                table: "TaskStateChange");

            migrationBuilder.RenameTable(
                name: "TeamMember",
                newName: "TeamMembers");

            migrationBuilder.RenameTable(
                name: "TaskStateChange",
                newName: "TaskStateChanges");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "GroupsUserPermissions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupsUserPermissions_MemberId",
                table: "GroupsUserPermissions",
                newName: "IX_GroupsUserPermissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChange_UserId",
                table: "TaskStateChanges",
                newName: "IX_TaskStateChanges_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChange_TaskId",
                table: "TaskStateChanges",
                newName: "IX_TaskStateChanges_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChange_GroupId",
                table: "TaskStateChanges",
                newName: "IX_TaskStateChanges_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStateChanges",
                table: "TaskStateChanges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUserPermissions_Users_UserId",
                table: "GroupsUserPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_TaskStateChanges_TaskStateChangeId",
                table: "TaskAssignments",
                column: "TaskStateChangeId",
                principalTable: "TaskStateChanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChanges_Groups_GroupId",
                table: "TaskStateChanges",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChanges_Tasks_TaskId",
                table: "TaskStateChanges",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChanges_Users_UserId",
                table: "TaskStateChanges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Team_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Users_UserId",
                table: "TeamMembers",
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

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_TaskStateChanges_TaskStateChangeId",
                table: "TaskAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChanges_Groups_GroupId",
                table: "TaskStateChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChanges_Tasks_TaskId",
                table: "TaskStateChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStateChanges_Users_UserId",
                table: "TaskStateChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Team_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Users_UserId",
                table: "TeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStateChanges",
                table: "TaskStateChanges");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "TeamMember");

            migrationBuilder.RenameTable(
                name: "TaskStateChanges",
                newName: "TaskStateChange");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GroupsUserPermissions",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupsUserPermissions_UserId",
                table: "GroupsUserPermissions",
                newName: "IX_GroupsUserPermissions_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMember",
                newName: "IX_TeamMember_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMember",
                newName: "IX_TeamMember_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChanges_UserId",
                table: "TaskStateChange",
                newName: "IX_TaskStateChange_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChanges_TaskId",
                table: "TaskStateChange",
                newName: "IX_TaskStateChange_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStateChanges_GroupId",
                table: "TaskStateChange",
                newName: "IX_TaskStateChange_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStateChange",
                table: "TaskStateChange",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUserPermissions_Users_MemberId",
                table: "GroupsUserPermissions",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_TaskStateChange_TaskStateChangeId",
                table: "TaskAssignments",
                column: "TaskStateChangeId",
                principalTable: "TaskStateChange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChange_Groups_GroupId",
                table: "TaskStateChange",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStateChange_Tasks_TaskId",
                table: "TaskStateChange",
                column: "TaskId",
                principalTable: "Tasks",
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
                name: "FK_TeamMember_Team_TeamId",
                table: "TeamMember",
                column: "TeamId",
                principalTable: "Team",
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
    }
}
