using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;
using Teams.BL;

namespace Teams.BL.Repositories
{
    public interface IGroupTaskRepository
    {
        List<GroupModel> GetAllGroups();
        List<GroupModel> GetTeamsGroups(Guid Id);
        List<TaskModel> GetGroupTasks(Guid Id);
        void CreateGroup(GroupModel Group);
        void DeleteGroup(Guid Id);
        void UpdateGroup(GroupModel Group);
        void CreateTask(TaskModel Id);
        void DeleteTask(Guid Id);
        void UpdateTask(TaskModel Id);
        void AddUserToGroup(Guid UserId, Guid GroupId);
        List<TaskStateChangeModel> GetTaskChanges(Guid Id);
        List<Task> GetUserGroupTasks(Guid UserId, Guid GroupId);

    }
}
