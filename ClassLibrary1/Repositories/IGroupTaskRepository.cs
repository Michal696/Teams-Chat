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
        GroupModel CreateGroup(GroupModel Group);
        GroupModel GetByIdGroup(Guid Id);
        TaskModel GetByIdTask(Guid Id);
        void DeleteGroup(Guid Id);
        void UpdateGroup(GroupModel Group);
        TaskModel CreateTask(TaskModel Id);
        void DeleteTask(Guid Id);
        void UpdateTask(TaskModel Id);
        void AddUserToGroup(Guid UserId, Guid GroupId);
        IEnumerable<TaskStateChangeModel> GetTaskChanges(Guid Id);
        IEnumerable<Task> GetUserGroupTasks(Guid UserId, Guid GroupId);

    }
}
