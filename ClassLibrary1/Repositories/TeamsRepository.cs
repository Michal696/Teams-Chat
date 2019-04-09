using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.DAL.Entities;
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

        public TeamMemberModel AddUserToTeam(TeamMemberModel TeamMember)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TeamMemberModelToTeamMemberEntity(TeamMember);
                dbContext.TeamMember.Add(entity);
                dbContext.SaveChanges();
                return mapper.TeamMemberEntityToTeamMemberModel(entity);
            }
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

        public void Delete(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var team = new Team
                {
                    Id = Id
                };
                dbContext.Team.Attach(team);
                dbContext.Team.Remove(team);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<TeamModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Team
                    .Select(mapper.TeamEntityToTeamModel);
            }
        }

        public TeamModel GetById(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Team.FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.TeamEntityToTeamModel(entity);
            }
        }

        public IEnumerable<TeamModel> GetByUser(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var teamMemberEntity = dbContext.TeamMember
                    .Select(mapper.TeamMemberEntityToTeamMemberModel)
                    .Where(t => t.User.Id == Id);

                List<TeamModel> teamEntity = null;
                foreach(TeamMemberModel entity in teamMemberEntity.ToList())
                {
                    teamEntity.Concat(dbContext.Team
                        .Select(mapper.TeamEntityToTeamModel)
                        .Where(t => t.Id == entity.Team.Id));
                }

                return teamEntity == null ? null : teamEntity;
            }
        }

        public void Update(TeamModel Team)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TeamModelToTeamEntity(Team);
                dbContext.Team.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
