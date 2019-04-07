using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public TeamsRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public TeamsRepository()
        {

        }

        void ITeamsRepository.AddUserToGroup(Guid GroupId, Guid UserId)
        {
            throw new NotImplementedException();
        }

        void ITeamsRepository.Create(TeamModel Team)
        {
            throw new NotImplementedException();
        }

        void ITeamsRepository.Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TeamModel> ITeamsRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        TeamModel ITeamsRepository.GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TeamModel> ITeamsRepository.GetByUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        void ITeamsRepository.Update(TeamModel Team)
        {
            throw new NotImplementedException();
        }
    }
}
