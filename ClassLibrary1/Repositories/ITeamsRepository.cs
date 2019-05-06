using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public interface ITeamsRepository : IRepository
    {
        IEnumerable<TeamModel> GetAll();
        TeamModel GetById(Guid Id);
        IEnumerable<TeamModel> GetByUser(Guid Id);
        IEnumerable<TeamMemberModel> GetMembershipsByUser(Guid Id);
        
        TeamModel Create(TeamModel Team);
        
        void DeleteTeamMember(Guid Id);
        void DeleteUserFromTeam(Guid userId, Guid teamId);
        void Delete(Guid Id);
        void Update(TeamModel Team);
        IEnumerable<UserModel> GetTeamUsers(Guid Id);
        IEnumerable<UserModel> GetTeamNotUsers(Guid Id);
        TeamMemberModel AddUserToTeam(TeamMemberModel TeamMember);
        
    }
}
