using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;

namespace Teams.BL.Tests

{
    public class GroupTaskRepositoryTestsFixture
    {
        private readonly IGroupTaskRepository repository;
        public GroupTaskRepositoryTestsFixture()
        {
            repository = new GroupTaskRepository(new InMemoryDbContextFactory());
        }

        public IGroupTaskRepository Repository => repository;
    }
}