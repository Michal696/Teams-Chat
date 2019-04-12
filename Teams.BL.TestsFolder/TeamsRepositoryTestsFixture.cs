using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;
using Teams.BL.Models;

namespace Teams.BL.Tests

{
    public class TeamsRepositoryTestsFixture
    {
        private readonly ITeamsRepository repository;
        public TeamsRepositoryTestsFixture()
        {
            repository = new TeamsRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            var model = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeams - some random data"
            };
            repository.Create(model);
        }

        public ITeamsRepository Repository => repository;
    }
}