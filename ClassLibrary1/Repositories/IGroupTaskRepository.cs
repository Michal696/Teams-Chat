using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public interface IGroupTaskRepository
    {
        IEnumerable<GroupModel> GetAllGroups();
        IEnumerable<GroupModel> GetTeamsGroups(Guid Id);
        IEnumerable<TaskModel> GetGroupTasks(Guid Id);
        void CreateGroup(GroupModel Group);
        void DeleteGroup(Guid Id);
        void UpdateGroup(GroupModel Group);
        void CreateTask(TaskModel Id);
        void DeleteTask(Guid Id);
        void UpdateTask(TaskModel Id);
        void AddUserToGroup(Guid UserId, Guid GroupId);
        IEnumerable<TaskStateChangeModel> GetTaskChanges(Guid Id);
        IEnumerable<Task> GetUserGroupTasks(Guid UserId, Guid GroupId);

    }
}
