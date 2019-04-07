using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Repositories;
using Teams.BL;

namespace Teams.BL.Repositories
{
    public class GroupTaskRepository : IGroupTaskRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        public Mapper Mapper = new Mapper();

        public GroupTaskRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public GroupTaskRepository()
        {
            throw new NotImplementedException();
        }
        public void AddUserToGroup(Guid UserId, Guid GroupId)
        {
            throw new NotImplementedException();
        }

        public GroupModel CreateGroup(GroupModel Group)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.GroupModelToGroupEntity(Group);
                dbContext.Groups.Add(entity);
                dbContext.SaveChanges();
                return Mapper.GroupEntityToGroupModel(entity);
            }
        }

        public TaskModel CreateTask(TaskModel Task)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.TaskModelToTaskEntity(Task);
                dbContext.Tasks.Add(entity);
                dbContext.SaveChanges();
                return Mapper.TaskEntityToTaskModel(entity);
            }
        }

        public void DeleteGroup(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Groups.First(t => t.Id == Id);
                dbContext.Remove(entity);
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

        public List<GroupModel> GetAllGroups()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Groups
                    .Select(e => Mapper.GroupEntityToGroupModel(e)).ToList();
            }
        }

        public List<TaskModel> GetGroupTasks(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<TaskStateChangeModel> GetTaskChanges(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<GroupModel> GetTeamsGroups(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetUserGroupTasks(Guid UserId, Guid GroupId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GroupModel Group)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.GroupModelToGroupEntity(Group);
                dbContext.Groups.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void UpdateTask(TaskModel Task)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.TaskModelToTaskEntity(Task);
                dbContext.Tasks.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
