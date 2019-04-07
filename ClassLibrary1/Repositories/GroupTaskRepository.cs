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
        public Mapper mapper = new Mapper();

        public GroupTaskRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public GroupTaskRepository()
        {

        }
        public void AddUserToGroup(Guid UserId, Guid GroupId)
        {
            throw new NotImplementedException();
        }

        public GroupModel CreateGroup(GroupModel Group)
        {
            throw new NotImplementedException();
        }

        public TaskModel CreateTask(TaskModel Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<GroupModel> GetAllGroups()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var groupEntities = dbContext.Groups.ToList();
                return groupEntities.Select(mapper.GroupEntityToGroupModel).ToList();
            }
        }

        public List<TaskModel> GetGroupTasks(Guid Id)
        {
            //throw new NotImplementedException();
            using (var dbContext = dbContextFactory.CreateDbContext())
            {

            }
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
            throw new NotImplementedException();
        }

        public void UpdateTask(TaskModel Id)
        {
            throw new NotImplementedException();
        }

        public GroupModel GetByIdGroup(Guid Id)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetByIdTask(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
