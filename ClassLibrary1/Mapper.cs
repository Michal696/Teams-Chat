using System;
using System.Collections.Generic;
using System.Text;
using Teams.BL.Models;
using Teams.DAL.Entities;

namespace Teams.BL
{
    public class Mapper
    {
        public GroupModel GroupEntityToGroupModel (Group entity)
        {
            return new GroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        public GroupUserPermissionModel GroupUserPermissionsEntityToGroupUserPermissionsModel(GroupUserPermission entity)
        {
            return new GroupUserPermissionModel
            {
                Id = entity.Id,
                Permit = entity.Permit
            };
        }

        public MessageModel MessageEntityToMessageModel(Message entity)
        {
            return new MessageModel
            {
                Id = entity.Id,
                Title = entity.Title,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
            };
        }

        public TaskAssignmentModel TaskAssignmentEntityToTaskAssignmentModel(TaskAssignment entity)
        {
            return new TaskAssignmentModel
            {
                Id = entity.Id,
            };
        }

        public TaskModel TaskEntityToTaskModel(Task entity)
        {
            return new TaskModel
            {
                Id = entity.Id,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
            };
        }

        public TaskStateChangeModel TaskStateChangeEntityToTaskStateChangeModel(TaskStateChange entity)
        {
            return new TaskStateChangeModel
            {
                Id = entity.Id,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
            };
        }

        public TeamMemberModel TeamMemberEntityToTeamMemberModel(TeamMember entity)
        {
            return new TeamMemberModel
            {
                Id = entity.Id,
            };
        }

        public TeamModel TeamEntityToTeamModel(Team entity)
        {
            return new TeamModel
            {
                Id = entity.Id,
                Name = entity.Name,
           };
        }

        public UserModel UserEntityToUserModel(User entity)
        {
            return new UserModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password,
                Image = entity.Image,
                Email = entity.Email,
                LastLogin = entity.LastLogin,
            };
        }

        public Group GroupModelToGroupEntity(GroupModel model)
        {
            return new Group
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }

        public GroupUserPermission GroupUserPermissionsModelToGroupUserPermissionsEntity(GroupUserPermissionModel model)
        {
            return new GroupUserPermission
            {
                Id = model.Id,
                Permit = model.Permit
            };
        }

        public Message MessageModelToMessageEntity(MessageModel model)
        {
            return new Message
            {
                Id = model.Id,
                Title = model.Title,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
            };
        }

        public TaskAssignment TaskAssignmentModelToTaskAssignmentEntity(TaskAssignmentModel model)
        {
            return new TaskAssignment
            {
                Id = model.Id,
            };
        }

        public Task TaskModelToTaskEntity(TaskModel model)
        {
            return new Task
            {
                Id = model.Id,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
            };
        }

        public TaskStateChange TaskStateChangeModelToTaskStateChangeEntity(TaskStateChangeModel model)
        {
            return new TaskStateChange
            {
                Id = model.Id,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
            };
        }

        public static TeamMember TeamMemberModelToTeamMemberEntity(TeamMemberModel entity)
        {
            return new TeamMember
            {
                Id = entity.Id,
            };
        }

        public Team TeamModelToTeamEntity(TeamModel entity)
        {
            return new Team
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public User UserModelToUserEntity(UserModel entity)
        {
            return new User
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password,
                Image = entity.Image,
                Email = entity.Email,
                LastLogin = entity.LastLogin,
            };
        }
    }
}
