using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;
using Teams.BL.Mapper;

namespace Teams.BL.Tests

{
    public class UserRepositoryTestsFixture
    {
        private readonly IUserRepository repository;
        public UserRepositoryTestsFixture()
        {
            repository = new UserRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
        }

        public IUserRepository Repository => repository;
    }
}