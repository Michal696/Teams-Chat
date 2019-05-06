using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;
using Teams.BL.Repositories;
using Teams.BL.Tests;
using Xunit;

namespace Teams.BL.Tests
{
    public class TeamsRepositoryTests : IClassFixture<TeamsRepositoryTestsFixture>
    {
        private readonly TeamsRepositoryTestsFixture fixture;

        public TeamsRepositoryTests(TeamsRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateTeams()
        {
            var model = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeams - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);
            
            Assert.NotNull(returnedModel);
            fixture.Repository.Delete(returnedModel.Id);
        }
        [Fact]
        public void DeleteTeams()
        {
            var model = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeams - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
            
            fixture.Repository.Delete(returnedModel.Id);
            returnedModel = fixture.Repository.GetById(returnedModel.Id);
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindTeamsById_NotNull()
        {
            var model = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeams - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
            
            var foundModel = fixture.Repository.GetById(model.Id);
            Assert.NotNull(foundModel);
            
            fixture.Repository.Delete(model.Id);
        }

        [Fact]
        public void FindTeamsById_Values()
        {
            var model = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeams - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetById(model.Id);
            Assert.NotNull(foundModel);
            Assert.Equal(model.Name, foundModel.Name);
            fixture.Repository.Delete(model.Id);

        }

        [Fact]
        public void TeamsGetAll_NotNull()
        {
            Assert.NotNull(fixture.Repository.GetAll());
        }


        [Fact]
        public void UpdateWithModel()
        {
            var testId = Guid.NewGuid();
            var model = new TeamModel
            {
                Id = testId,
                Name = "FirstName"
            };

            var returnedModelCreated = fixture.Repository.Create(model);
            Assert.NotNull(returnedModelCreated);

            String secondName = "SecondName";
            model.Name = secondName;
            fixture.Repository.Update(model);

            var foundModel = fixture.Repository.GetById(model.Id);
            Assert.NotNull(foundModel);
            
            Assert.NotEqual(returnedModelCreated.Name, foundModel.Name);
            Assert.Equal(foundModel.Name, secondName);
            fixture.Repository.Delete(foundModel.Id);

        }

        [Fact]
        public void AddUserToTeam_value()
        {
         
            UserModel userModel = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = "UserName"
            };

            TeamModel teamModel = new TeamModel()
            {
                Name = "TeamName"
            };

            var teamMemberModel = new TeamMemberModel()
            {
                User = userModel,
                Team = teamModel
                    
            };

            TeamMemberModel returnedTeamMemberModel = fixture.Repository.AddUserToTeam(teamMemberModel);

            //Assert.Equal(teamMemberModel.Id, returnedTeamMemberModel.Id);
            //Assert.Equal(teamMemberModel.Team.Id, returnedTeamMemberModel.Team.Id);
            Assert.Equal(teamMemberModel.Team.Name, returnedTeamMemberModel.Team.Name);
            //Assert.Equal(teamMemberModel.User.Id, returnedTeamMemberModel.User.Id);
            Assert.Equal(teamMemberModel.User.Name, returnedTeamMemberModel.User.Name);
            fixture.Repository.DeleteTeamMember(returnedTeamMemberModel.Id);
           
        }


        [Fact]
        public void FindingTeamsByUserId_BasedOnUserId()
        {
            var teamModel1 = new TeamModel
            {
                Name = "TestTeamModel1"
            };

            var teamModel2 = new TeamModel
            {
                Name = "TestTeamModel2"
            };

            var teamModel3 = new TeamModel
            {
                Name = "TestTeamModel3"
            };


            var returnedModel1 = fixture.Repository.Create(teamModel1);
            var returnedModel2 = fixture.Repository.Create(teamModel2);
            var returnedModel3 = fixture.Repository.Create(teamModel3);

            Assert.NotNull(returnedModel1);
            Assert.NotNull(returnedModel2);
            Assert.NotNull(returnedModel3);
            
            //fixture.Repository.Delete(teamModel1.id);
            //fixture.Repository.Delete(teamModel2.id);
            //fixture.Repository.Delete(teamModel3.id);

            UserModel userModel = new UserModel()
            {
                Name = "UserName"
            };


            var teamMemberModel1 = new TeamMemberModel()
            {
                User = userModel,
                Team = returnedModel1

            };

            TeamMemberModel returnedTeamMemberModel1 = fixture.Repository.AddUserToTeam(teamMemberModel1);
           
            var teamMemberModel2 = new TeamMemberModel()
            {
                User = userModel,
                Team = returnedModel2

            };

            TeamMemberModel returnedTeamMemberModel2 = fixture.Repository.AddUserToTeam(teamMemberModel2);

            
            IEnumerable<TeamModel> teamMemberModels = fixture.Repository.GetByUser(userModel.Id);


            // clean
            fixture.Repository.Delete(returnedModel1.Id);
            fixture.Repository.Delete(returnedModel2.Id);
            fixture.Repository.Delete(returnedModel3.Id);

            fixture.Repository.DeleteTeamMember(returnedTeamMemberModel1.Id);
            fixture.Repository.DeleteTeamMember(returnedTeamMemberModel2.Id);


        }


 

        [Fact]
        public void TeamsGetAll_countOfValues()
        {
            var teamModel1 = new TeamModel
            {
                Name = "TestTeamModel1"
            };

            var teamModel2 = new TeamModel
            {
                Name = "TestTeamModel2"
            };

            var teamModel3 = new TeamModel
            {
                Name = "TestTeamModel3"
            };


            var returnedModel1 = fixture.Repository.Create(teamModel1);
            var returnedModel2 = fixture.Repository.Create(teamModel2);
            var returnedModel3 = fixture.Repository.Create(teamModel3);

            Assert.NotNull(returnedModel1);
            Assert.NotNull(returnedModel2);
            Assert.NotNull(returnedModel3);

            UserModel userModel = new UserModel()
            {
                Name = "UserName"
            };


            var teamMemberModel1 = new TeamMemberModel()
            {
                User = userModel,
                Team = teamModel1
            };

            TeamMemberModel returnedTeamMemberModel1 = fixture.Repository.AddUserToTeam(teamMemberModel1);

            var teamMemberModel2 = new TeamMemberModel()
            {
                User = userModel,
                Team = teamModel2

            };

            TeamMemberModel returnedTeamMemberModel2 = fixture.Repository.AddUserToTeam(teamMemberModel2);

            // clean
            fixture.Repository.Delete(returnedModel1.Id);
            fixture.Repository.Delete(returnedModel2.Id);
            fixture.Repository.Delete(returnedModel3.Id);

            fixture.Repository.DeleteTeamMember(returnedTeamMemberModel1.Id);
            fixture.Repository.DeleteTeamMember(returnedTeamMemberModel2.Id);

         
        }
    }
}