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
        TeamModel Create(TeamModel Team);
        void Delete(Guid Id);
        void Update(TeamModel Team);
        TeamMemberModel AddUserToTeam(TeamMemberModel TeamMember);
    }
}
