using System;
using System.Collections.Generic;
using System.Text;
using Teams.BL.Models;
using Teams.DAL.Entities;

namespace Teams.BL.Mapper
{
    internal static class Mapper
    {
        public static GroupModel GroupEntityToGroupModel (Group entity)
        {
            return new GroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        public static GroupUserPermissionModel GroupUserPermissionsEntityToGroupUserPermissionsModel(GroupUserPermission entity)
        {
            return new GroupUserPermissionModel
            {
                Id = entity.Id,
                Permit = entity.Permit
            };
        }

        public static MessageModel MessageEntityToMessageModel(Message entity)
        {
            return new MessageModel
            {
                Id = entity.Id,
                Title = entity.Title,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
            };
        }

        public static TaskAssignmentModel TaskAssignmentEntityToTaskAssignmentModel(TaskAssignment entity)
        {
            return new TaskAssignmentModel
            {
                Id = entity.Id,
            };
        }

        public static TaskModel TaskEntityToTaskModel(Task entity)
        {
            return new TaskModel
            {
                Id = entity.Id,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
            };
        }

        public static TaskStateChangeModel TaskStateChangeEntityToTaskStateChangeModel(TaskStateChange entity)
        {
            return new TaskStateChangeModel
            {
                Id = entity.Id,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
            };
        }

        public static TeamMemberModel TeamMemberEntityToTeamMemberModel(TeamMember entity)
        {
            return new TeamMemberModel
            {
                Id = entity.Id,
            };
        }

        public static TeamModel TeamEntityToTeamModel(Team entity)
        {
            return new TeamModel
            {
                Id = entity.Id,
                Name = entity.Name,
           };
        }

        public static UserModel TeamEntityToTeamModel(User entity)
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

        public static Group GroupModelToGroupEntity(GroupModel model)
        {
            return new Group
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }

        public static GroupUserPermission GroupUserPermissionsModelToGroupUserPermissionsEntity(GroupUserPermissionModel model)
        {
            return new GroupUserPermission
            {
                Id = model.Id,
                Permit = model.Permit
            };
        }

        public static Message MessageModelToMessageEntity(MessageModel model)
        {
            return new Message
            {
                Id = model.Id,
                Title = model.Title,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
            };
        }

        public static TaskAssignment TaskAssignmentModelToTaskAssignmentEntity(TaskAssignmentModel model)
        {
            return new TaskAssignment
            {
                Id = model.Id,
            };
        }

        public static Task TaskModelToTaskEntity(TaskModel model)
        {
            return new Task
            {
                Id = model.Id,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
            };
        }

        public static TaskStateChange TaskStateChangeModelToTaskStateChangeEntity(TaskStateChangeModel model)
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

        public static Team TeamModelToTeamEntity(TeamModel entity)
        {
            return new Team
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public static User TeamModelToTeamEntity(UserModel entity)
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
