using Teams.BL.Models;
using Teams.DAL.Entities;

namespace Teams.BL.Mapper
{
    public interface IMapper
    {
        GroupModel GroupEntityToGroupModel(Group entity);
        GroupUserPermissionModel GroupUserPermissionsEntityToGroupUserPermissionsModel(GroupUserPermission entity);
        MessageModel MessageEntityToMessageModel(Message entity);
        TaskAssignmentModel TaskAssignmentEntityToTaskAssignmentModel(TaskAssignment entity);
        TaskModel TaskEntityToTaskModel(Task entity);
        TaskStateChangeModel TaskStateChangeEntityToTaskStateChangeModel(TaskStateChange entity);
        TeamMemberModel TeamMemberEntityToTeamMemberModel(TeamMember entity);
        TeamModel TeamEntityToTeamModel(Team entity);
        UserModel UserEntityToUserModel(User entity);
        MediaModel MediaEntityToMediaModel(Media entity);
        Group GroupModelToGroupEntity(GroupModel model);
        GroupUserPermission GroupUserPermissionsModelToGroupUserPermissionsEntity(GroupUserPermissionModel model);
        Message MessageModelToMessageEntity(MessageModel model);
        TaskAssignment TaskAssignmentModelToTaskAssignmentEntity(TaskAssignmentModel model);
        Task TaskModelToTaskEntity(TaskModel model);
        TaskStateChange TaskStateChangeModelToTaskStateChangeEntity(TaskStateChangeModel model);
        TeamMember TeamMemberModelToTeamMemberEntity(TeamMemberModel model);
        Team TeamModelToTeamEntity(TeamModel model);
        User UserModelToUserEntity(UserModel model);
        Media MediaModelToMediaEntity(MediaModel model);
    }
}
