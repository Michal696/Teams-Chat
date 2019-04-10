using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;
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
            var model = new UserModel
            {
                Name = "TestUser - some random data"
            };
            repository.Create(model);
        }

        public IUserRepository Repository => repository;
    }
}