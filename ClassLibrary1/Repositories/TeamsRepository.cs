using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Mapper;
using Teams.BL;

namespace Teams.BL.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;

        public TeamsRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        void ITeamsRepository.AddUserToGroup(Guid GroupId, Guid UserId)
        {
            throw new NotImplementedException();
        }

        public  TeamModel Create(TeamModel Team)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TeamModelToTeamEntity(Team);
                dbContext.Team.Add(entity);
                dbContext.SaveChanges();
                return mapper.TeamEntityToTeamModel(entity);
            }
        }

        void ITeamsRepository.Delete(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Team.First(t => t.Id == Id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        IEnumerable<TeamModel> ITeamsRepository.GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Team
                    .Select(e => mapper.TeamEntityToTeamModel(e)).ToList();
            }
        }

        TeamModel ITeamsRepository.GetById(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Team.First(t => t.Id == Id);
                return mapper.TeamEntityToTeamModel(entity);
            }
        }

        IEnumerable<TeamModel> ITeamsRepository.GetByUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        void ITeamsRepository.Update(TeamModel Team)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.TeamModelToTeamEntity(Team);
                dbContext.Team.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
