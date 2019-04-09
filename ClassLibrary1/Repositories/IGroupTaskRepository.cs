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
        List<GroupModel> GetAllGroups();
        List<GroupModel> GetTeamsGroups(Guid Id);
        List<TaskModel> GetGroupTasks(Guid Id);
        GroupModel CreateGroup(GroupModel Group);
        GroupModel GetByIdGroup(Guid Id);
        TaskModel GetByIdTask(Guid Id);
        void DeleteGroup(Guid Id);
        void UpdateGroup(GroupModel Group);
        TaskModel CreateTask(TaskModel Task);
        void DeleteTask(Guid Id);
        void UpdateTask(TaskModel Task);
        void AddUserToGroup(Guid UserId, Guid GroupId);
        List<TaskStateChangeModel> GetTaskChanges(Guid Id);
        List<Task> GetUserGroupTasks(Guid UserId, Guid GroupId);

    }
}
