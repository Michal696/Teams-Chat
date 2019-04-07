using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public interface ITeamsRepository
    {
        List<TeamModel> GetAll();
        TeamModel GetById(Guid Id);
        List<TeamModel> GetByUser(Guid Id);
        TeamModel Create(TeamModel Team);
        void Delete(Guid Id);
        void Update(TeamModel Team);
        void AddUserToGroup(Guid GroupId, Guid UserId); /* TODO add permision */
    }
}
