using System;
using System.Collections.Generic;
using System.Text;
using Teams.BL.Models;
using Teams.DAL.Entities;

namespace Teams.BL.Mapper
{
    public class Mapper : IMapper
    {
        public Mapper()
        {

        }

        public GroupModel GroupEntityToGroupModel (Group entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new GroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Team = TeamEntityToTeamModel(entity.Team)
            };
        }

        public GroupUserPermissionModel GroupUserPermissionsEntityToGroupUserPermissionsModel(GroupUserPermission entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new GroupUserPermissionModel
            {
                Id = entity.Id,
                Group = GroupEntityToGroupModel(entity.Group),
                User = UserEntityToUserModel(entity.User),
                Permit = entity.Permit
            };
        }

        public MessageModel MessageEntityToMessageModel(Message entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new MessageModel
            {
                Id = entity.Id,
                Title = entity.Title,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
                User = UserEntityToUserModel(entity.User),
                Parent = entity.Parent == null ? null : MessageEntityToMessageModel(entity.Parent),
                Group = GroupEntityToGroupModel(entity.Group)
            };
        }

        public TaskAssignmentModel TaskAssignmentEntityToTaskAssignmentModel(TaskAssignment entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TaskAssignmentModel
            {
                Id = entity.Id,
                User = UserEntityToUserModel(entity.User),
                Task = TaskEntityToTaskModel(entity.Task)
            };
        }

        public TaskModel TaskEntityToTaskModel(Task entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TaskModel
            {
                Id = entity.Id,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
                User = UserEntityToUserModel(entity.User),
                State = entity.State,
                Group = GroupEntityToGroupModel(entity.Group)
            };
        }

        public TaskStateChangeModel TaskStateChangeEntityToTaskStateChangeModel(TaskStateChange entity)
        {
            return new TaskStateChangeModel
            {
                Id = entity.Id,
                TimeStamp = entity.TimeStamp,
                Text = entity.Text,
                User = UserEntityToUserModel(entity.User),
                State = entity.State,
                Group = GroupEntityToGroupModel(entity.Group),
                Task = TaskEntityToTaskModel(entity.Task)
            };
        }

        public TeamMemberModel TeamMemberEntityToTeamMemberModel(TeamMember entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TeamMemberModel
            {
                Id = entity.Id,
                User = UserEntityToUserModel(entity.User),
                Team = TeamEntityToTeamModel(entity.Team)
            };
        }

        public TeamModel TeamEntityToTeamModel(Team entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TeamModel
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public UserModel UserEntityToUserModel(User entity)
        {
            if (entity == null)
            {
                return null;
            }

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

        public MediaModel MediaEntityToMediaModel(Media entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new MediaModel
            {
                Id = entity.Id,
                Parent = MessageEntityToMessageModel(entity.Parent),
                Data = entity.Data
            };
        }

        public Group GroupModelToGroupEntity(GroupModel model)
        {
            return new Group
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Team = TeamModelToTeamEntity(model.Team)
            };
        }

        public GroupUserPermission GroupUserPermissionsModelToGroupUserPermissionsEntity(GroupUserPermissionModel model)
        {
            return new GroupUserPermission
            {
                Id = model.Id,
                Group = GroupModelToGroupEntity(model.Group),
                User = UserModelToUserEntity(model.User),
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
                User = UserModelToUserEntity(model.User),
                Parent = model.Parent == null ? null : MessageModelToMessageEntity(model.Parent),
                Group = GroupModelToGroupEntity(model.Group)
            };
        }

        public TaskAssignment TaskAssignmentModelToTaskAssignmentEntity(TaskAssignmentModel model)
        {
            return new TaskAssignment
            {
                Id = model.Id,
                User = UserModelToUserEntity(model.User),
                Task = TaskModelToTaskEntity(model.Task)
            };
        }

        public Task TaskModelToTaskEntity(TaskModel model)
        {
            return new Task
            {
                Id = model.Id,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
                User = UserModelToUserEntity(model.User),
                State = model.State,
                Group = GroupModelToGroupEntity(model.Group)
            };
        }

        public TaskStateChange TaskStateChangeModelToTaskStateChangeEntity(TaskStateChangeModel model)
        {
            return new TaskStateChange
            {
                Id = model.Id,
                TimeStamp = model.TimeStamp,
                Text = model.Text,
                User = UserModelToUserEntity(model.User),
                State = model.State,
                Group = GroupModelToGroupEntity(model.Group),
                Task = TaskModelToTaskEntity(model.Task)
            };
        }

        public TeamMember TeamMemberModelToTeamMemberEntity(TeamMemberModel model)
        {
            return new TeamMember
            {
                Id = model.Id,
                User = UserModelToUserEntity(model.User),
                Team = TeamModelToTeamEntity(model.Team)
            };
        }

        public Team TeamModelToTeamEntity(TeamModel model)
        {
            return new Team
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public User UserModelToUserEntity(UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                Image = model.Image,
                Email = model.Email,
                LastLogin = model.LastLogin,
            };
        }

        public Media MediaModelToMediaEntity(MediaModel model)
        {
            return new Media
            {
                Id = model.Id,
                Parent = MessageModelToMessageEntity(model.Parent),
                Data = model.Data
            };
        }
    }
}
