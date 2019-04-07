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
                Name = "TestTeams - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);
            // New Test
            Assert.NotNull(returnedModel);
            fixture.Repository.Delete(returnedModel.Id);
        }
        [Fact]
        public void DeleteTeams()
        {
            var model = new TeamModel
            {
                Name = "TestTeams - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
            fixture.Repository.Delete(returnedModel.Id);
            // New Test
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
            // New Test
            Assert.NotNull(foundModel);

            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);


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
            // New Test
            Assert.Equal(model.Name, foundModel.Name);

            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        [Fact]
        public void TeamsGetAll_NotNull()
        {
            var model = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeams - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);
            // New Test
            Assert.NotNull(fixture.Repository.GetAll());

            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);
        }


        [Fact]
        public void UpdateWithModel()
        {

            Guid testId = Guid.NewGuid();
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

            // New Test
            Assert.NotEqual(returnedModelCreated.Name, foundModel.Name);
            Assert.Equal(foundModel.Name, secondName);

            fixture.Repository.Delete(returnedModelCreated.Id);
            Assert.Null(returnedModelCreated);


        }





    }
}