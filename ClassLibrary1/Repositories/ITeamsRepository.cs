using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    interface ITeamsRepository
    {
        IEnumerable<TeamModel> GetAll();
        TeamModel GetById(Guid Id);
        IEnumerable<TeamModel> GetByUser(Guid Id);
        void Create(TeamModel Team);
        void Delete(Guid Id);
        void Update(TeamModel Team);
        void AddUserToGroup(Guid GroupId, Guid UserId); /* TODO add permision */
    }
}
