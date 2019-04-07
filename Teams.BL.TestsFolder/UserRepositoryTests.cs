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
    public class UserRepositoryTests : IClassFixture<UserRepositoryTestsFixture>
    {
        private readonly UserRepositoryTestsFixture fixture;
        private UserRepository userRepositorySUT = new UserRepository();


        public UserRepositoryTests(UserRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateUser()
        {
            var model = new UserModel
            {
                Name = "TestUser - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);
            
            Assert.NotNull(returnedModel);
            fixture.Repository.Delete(returnedModel.Id);
        }
        [Fact]
        public void DeleteUser()
        {
            var model = new UserModel
            {
                Name = "TestUser - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindUserById()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "TestUser - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetById(model.Id);

            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);
        }



        [Fact]
        public void CreateUserSUT()
        {
            var model = new UserModel
            {
                Name = "TestUser - some random data"
            };
            
            Assert.NotNull(userRepositorySUT.Create(model));
        }

        
    }
}