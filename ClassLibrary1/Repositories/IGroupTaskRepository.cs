using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.DAL.Entities;
using Teams.DAL.Entities.Enums;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public interface IGroupTaskRepository : IRepository
    {
        IEnumerable<GroupModel> GetAllGroups();
        IEnumerable<GroupModel> GetTeamsGroups(Guid Id);
        IEnumerable<TaskModel> GetGroupTasks(Guid Id);
        GroupModel CreateGroup(GroupModel Group);
        GroupModel GetByIdGroup(Guid Id);
        TaskModel GetByIdTask(Guid Id);
        void DeleteGroup(Guid Id);
        void UpdateGroup(GroupModel Group);
        TaskModel CreateTask(TaskModel Task);
        void DeleteTask(Guid Id);
        void UpdateTask(TaskModel Task);
        GroupUserPermissionModel AddUserToGroup(GroupUserPermissionModel groupUserPermission);
        IEnumerable<TaskStateChangeModel> GetTaskChanges(Guid Id);

    }
}
