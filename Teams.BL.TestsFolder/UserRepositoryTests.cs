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
        
        public UserRepositoryTests(UserRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateUser()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "TestUser - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
        }
        [Fact]
        public void DeleteUser()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "TestUser - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.Delete(returnedModel.Id);
            returnedModel = fixture.Repository.GetById(returnedModel.Id);
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindUserById_NotNull()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "TestUser - some random data"
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetById(model.Id);
            Assert.NotNull(foundModel);
        }

        [Fact]
        public void FindUserById_Values()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "TestUser - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetById(model.Id);
            Assert.NotNull(foundModel);

            Assert.Equal(model.Name, foundModel.Name);
        }

        [Fact]
        public void UserGetAll_NotNull()
        {
            Assert.NotNull(fixture.Repository.GetAll());
        }


        [Fact]
        public void UpdateWithModel()
        {

            Guid testId = Guid.NewGuid();
            var model = new UserModel
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
        }

        [Fact]
        public void GetAllUsers_CountOfValues()
        {
            var model1 = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "FirstTestUser"
            };
            var returnedModel1 = fixture.Repository.Create(model1);

            Assert.NotNull(returnedModel1);

            var model2 = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "SecondTestUser"
            };
            var returnedModel2 = fixture.Repository.Create(model2);

            Assert.NotNull(returnedModel2);


            IEnumerable<UserModel> userModelList = fixture.Repository.GetAll();

            // uncomment when repaired: "userModelList.Count()"
            //int count =
            userModelList.Count(); // expecting "2"

            // uncomment when repaired: "userModelList.Count()"
            // int expect = 2;            
            // Assert.Equal(count, expect);

            // delete this assert when repaired: "userModelList.Count()"
            Assert.False(true);
        }


        [Fact]
        public void GetAllUsers_ByValues()
        {
            var model1 = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "FirstTestUser"
            };
            var returnedModel1 = fixture.Repository.Create(model1);

            Assert.NotNull(returnedModel1);

            var model2 = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "SecondTestUser"
            };
            var returnedModel2 = fixture.Repository.Create(model2);

            Assert.NotNull(returnedModel2);

            IEnumerable<UserModel> userModelList = fixture.Repository.GetAll();

            var returnedModel = userModelList.Single(m => m.Name == "FirstTestUser");
            Assert.Equal(returnedModel1.Id, returnedModel.Id);
            Assert.Equal(returnedModel1.Name, returnedModel.Name);

            returnedModel = userModelList.Single(m => m.Name == "SecondTestUser");
            Assert.Equal(returnedModel2.Id, returnedModel.Id);
            Assert.Equal(returnedModel2.Name, returnedModel.Name);
        }

        [Fact]
        public void GetAllUsers_ById()
        {
            var model1 = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "FirstTestUser"
            };
            var returnedModel1 = fixture.Repository.Create(model1);

            Assert.NotNull(returnedModel1);

            var model2 = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "SecondTestUser"
            };
            var returnedModel2 = fixture.Repository.Create(model2);

            Assert.NotNull(returnedModel2);

            IEnumerable<UserModel> userModelList = fixture.Repository.GetAll();

            var returnedModel = userModelList.Single(m => m.Id == returnedModel1.Id);
            Assert.Equal(returnedModel1.Id, returnedModel.Id);
            Assert.Equal(returnedModel1.Name, returnedModel.Name);

            returnedModel = userModelList.Single(m => m.Id == returnedModel2.Id);
            Assert.Equal(returnedModel2.Id, returnedModel.Id);
            Assert.Equal(returnedModel2.Name, returnedModel.Name);
        }
    }
}