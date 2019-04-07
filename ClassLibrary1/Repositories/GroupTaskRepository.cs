using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Repositories;

namespace Teams.BL.Repositories
{
    public class GroupTaskRepository : IGroupTaskRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public GroupTaskRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public void AddUserToGroup(Guid UserId, Guid GroupId)
        {
            throw new NotImplementedException();
        }

        public void CreateGroup(GroupModel Group)
        {
            throw new NotImplementedException();
        }

        public void CreateTask(TaskModel Id)
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

        public IEnumerable<GroupModel> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskModel> GetGroupTasks(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskStateChangeModel> GetTaskChanges(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupModel> GetTeamsGroups(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetUserGroupTasks(Guid UserId, Guid GroupId)
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
    }
}
