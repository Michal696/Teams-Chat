using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.DAL.Entities;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Repositories;
using Teams.BL.Mapper;
using Teams.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Teams.BL.Repositories
{
    public class GroupTaskRepository : IGroupTaskRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;

        public GroupTaskRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public GroupUserPermissionModel AddUserToGroup(GroupUserPermissionModel groupUserPermission)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.GroupUserPermissionsModelToGroupUserPermissionsEntity(groupUserPermission);
                dbContext.GroupsUserPermissions.Add(entity);
                dbContext.SaveChanges();
                return mapper.GroupUserPermissionsEntityToGroupUserPermissionsModel(entity);
            }
        }
        
        public GroupModel CreateGroup(GroupModel Group)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.GroupModelToGroupEntity(Group);
                dbContext.Team.Attach(entity.Team);
                dbContext.Groups.Add(entity);
                dbContext.SaveChanges();
                return mapper.GroupEntityToGroupModel(entity);
            }
        }

        public TaskModel CreateTask(TaskModel Task)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TaskModelToTaskEntity(Task);
                dbContext.Tasks.Add(entity);
                dbContext.SaveChanges();
                return mapper.TaskEntityToTaskModel(entity);
            }
        }

        public void DeleteGroup(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var group = new Group
                {
                    Id = Id
                };
                dbContext.Groups.Attach(group);
                dbContext.Groups.Remove(group);
                dbContext.SaveChanges();
            }
        }

        public void DeleteTask(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Tasks.First(t => t.Id == Id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<GroupModel> GetAllGroups()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Groups
                    .Select(mapper.GroupEntityToGroupModel);
            }
        }

        public IEnumerable<TaskModel> GetGroupTasks(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Tasks
                    .Select(mapper.TaskEntityToTaskModel)
                    .Where(t => t.Group.Id == Id);
            }
        }

        public IEnumerable<TaskStateChangeModel> GetTaskChanges(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.TaskStateChange
                    .Select(mapper.TaskStateChangeEntityToTaskStateChangeModel)
                    .Where(t => t.Task.Id == Id);
            }
        }

        public IEnumerable<GroupModel> GetTeamsGroups(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Groups
                    .Select(mapper.GroupEntityToGroupModel)
                    .Where(t => t.Team.Id == Id);
            }
        }

        public void UpdateGroup(GroupModel Group)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.GroupModelToGroupEntity(Group);
                dbContext.Groups.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void UpdateTask(TaskModel Task)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TaskModelToTaskEntity(Task);
                dbContext.Tasks.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public GroupModel GetByIdGroup(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Groups
                    .Include(g => g.Team)
                    .FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.GroupEntityToGroupModel(entity);
            }
        }

        public TaskModel GetByIdTask(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Tasks
                    .FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.TaskEntityToTaskModel(entity);
            }
        }
    }
}
