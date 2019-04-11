using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;
using Teams.BL.Models;

namespace Teams.BL.Tests

{
    public class GroupTaskRepositoryTestsFixture
    {
        private readonly IGroupTaskRepository repository;
        public readonly TeamModel teamModel;
        public GroupTaskRepositoryTestsFixture()
        {
            repository = new GroupTaskRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());

            teamModel = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeamModel"
            };
            var teamRepository = new TeamsRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            teamModel = teamRepository.Create(teamModel);

            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroupExample - some random data",
                Description = "TestGroupExample - description",
                Team = teamModel
            };

            var returnedModel = Repository.CreateGroup(model);
        }

        public IGroupTaskRepository Repository => repository;
    }
}