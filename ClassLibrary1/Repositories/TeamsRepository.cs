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
    public class TeamsRepository : RepositoryBase,  ITeamsRepository
    {
        public TeamsRepository(IDbContextFactory dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {
        }

        public TeamMemberModel AddUserToTeam(TeamMemberModel TeamMember)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TeamMemberModelToTeamMemberEntity(TeamMember);
                dbContext.TeamMembers.Add(entity);
                dbContext.SaveChanges();
                return mapper.TeamMemberEntityToTeamMemberModel(entity);
            }
        }

        public  TeamModel Create(TeamModel Team)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.TeamModelToTeamEntity(Team);
                dbContext.Teams.Add(entity);
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
                dbContext.Teams.Attach(team);
                dbContext.Teams.Remove(team);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<TeamModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Teams
                    .Select(mapper.TeamEntityToTeamModel);
            }
        }

        public TeamModel GetById(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Teams.FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.TeamEntityToTeamModel(entity);
            }
        }

        public IEnumerable<TeamModel> GetByUser(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var teamMemberEntity = dbContext.TeamMembers
                    .Select(mapper.TeamMemberEntityToTeamMemberModel)
                    .Where(t => t.User.Id == Id);

                List<TeamModel> teamEntity = null;
                foreach(TeamMemberModel entity in teamMemberEntity.ToList())
                {
                    teamEntity.Concat(dbContext.Teams
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
                dbContext.Teams.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
