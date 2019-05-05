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
using Microsoft.EntityFrameworkCore;


namespace Teams.BL.Repositories
{
    public class TeamsRepository : RepositoryBase,  ITeamsRepository
    {
        public TeamsRepository(IDbContextFactory dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {
        }

        public TeamMemberModel AddUserToTeam(TeamMemberModel TeamMember)
        {
           
                var entity = mapper.TeamMemberModelToTeamMemberEntity(TeamMember);
                if (entity.Id == null)
                {
                    entity.Id = Guid.NewGuid();
                }
                if (entity.Team.Id != null)
                {
                    dbContext.Team.Attach(entity.Team);
                }
                else
                {
                    entity.Team.Id = Guid.NewGuid();

                }

                if (entity.User.Id != null)
                {
                    dbContext.Users.Attach(entity.User);
                }
                else
                {
                    entity.User.Id = Guid.NewGuid();

                }

                dbContext.TeamMembers.Add(entity);
                dbContext.SaveChanges();
                return mapper.TeamMemberEntityToTeamMemberModel(entity);
            
        }

        public  TeamModel Create(TeamModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                if (model.Id == null)
                {
                    model.Id = Guid.NewGuid();
                }

                var entity = mapper.TeamModelToTeamEntity(model);

                
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

        
        public void DeleteTeamMember(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var team = new TeamMember
                {
                    Id = Id
                };
                dbContext.TeamMembers.Attach(team);
                dbContext.TeamMembers.Remove(team);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<TeamModel> GetAll()
        {
            
            return dbContext.Team.Select(mapper.TeamEntityToTeamModel);
        }

        public TeamModel GetById(Guid Id)
        {
         
            var entity = dbContext.Team.FirstOrDefault(t => t.Id == Id);
            return entity == null ? null : mapper.TeamEntityToTeamModel(entity);
           
        }

        public IEnumerable<TeamModel> GetByUser(Guid Id)
          {
              //using (var dbContext = dbContextFactory.CreateDbContext())
              {

                  var teamMemberEntity = dbContext.TeamMembers
                      .Include(t => t.Team)
                      .Include(t => t.User)
                      .Select(mapper.TeamMemberEntityToTeamMemberModel)
                      .Where(t => t.User.Id == Id);



                  List<TeamModel> teamEntity = new List<TeamModel>();
                  foreach (TeamMemberModel entity in teamMemberEntity.ToList())
                  {
                      teamEntity.AddRange(dbContext.Team
                          .Select(mapper.TeamEntityToTeamModel)
                          .Where(t => t.Id == entity.Team.Id).ToList());
                  }



                  return teamEntity == null ? null : teamEntity;
              }
          }

        public IEnumerable<TeamMemberModel> GetMembershipsByUser(Guid Id)
        {
           
            var teamMemberEntities = dbContext.TeamMembers
                .Include(t => t.Team)
                .Select(mapper.TeamMemberEntityToTeamMemberModel)
                .Where(t => t.User.Id == Id);


            return teamMemberEntities;
            
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
