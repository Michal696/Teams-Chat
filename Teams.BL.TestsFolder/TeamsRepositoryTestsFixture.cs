using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;

namespace Teams.BL.Tests

{
    public class TeamsRepositoryTestsFixture
    {
        private readonly ITeamsRepository repository;
        public TeamsRepositoryTestsFixture()
        {
            repository = new TeamsRepository(new InMemoryDbContextFactory());
        }

        public ITeamsRepository Repository => repository;
    }
}