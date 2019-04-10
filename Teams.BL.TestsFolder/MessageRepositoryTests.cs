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
    public class MessageRepositoryTests : IClassFixture<MessageRepositoryTestsFixture>
    {
        private readonly MessageRepositoryTestsFixture fixture;

        public MessageRepositoryTests(MessageRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateMessage()
        {
            var teamModel = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "Test Team"
            };
            var teamRepository = new TeamsRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            teamModel = teamRepository.Create(teamModel);

            Assert.NotNull(teamModel);
            Console.WriteLine(teamModel.Id);
            Console.WriteLine(teamModel.Name);

            var groupModel = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "Test Group description",
                Team = teamModel
            };
            var groupRepository = new GroupTaskRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            groupModel = groupRepository.CreateGroup(groupModel);

            var userModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "Test User"
            };
            var userRepository = new UserRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            userModel = userRepository.Create(userModel);

            var model = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "TestMessage - some random data",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };
            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
        }
        [Fact]
        public void DeleteMessage()
        {
            var model = new MessageModel
            {
                Text = "TestMessage - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);
            fixture.Repository.Delete(returnedModel.Id);
            // New Test
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindMessageById_NotNull()
        {
            var model = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "TestMessage - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetMessageById(model.Id);
            // New Test
            Assert.NotNull(foundModel);

            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        [Fact]
        public void FindMessageById_Values()
        {
            var model = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "TestMessage - some random data"
            };

            var returnedModel = fixture.Repository.Create(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetMessageById(model.Id);
            Assert.NotNull(foundModel);
            // New Test
            Assert.Equal(model.Text, foundModel.Text);

            fixture.Repository.Delete(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        [Fact]
        public void MessageGetAll_NotNull()
        {
            var model = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "TestMessage - some random data"
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
            var model = new MessageModel
            {
                Id = testId,
                Text = "FirstName"
            };

            var returnedModelCreated = fixture.Repository.Create(model);
            Assert.NotNull(returnedModelCreated);

            String secondName = "SecondName";
            model.Text = secondName;
            fixture.Repository.Update(model);

            var foundModel = fixture.Repository.GetMessageById(model.Id);
            Assert.NotNull(foundModel);

            // New Test
            Assert.NotEqual(returnedModelCreated.Text, foundModel.Text);
            Assert.Equal(foundModel.Text, secondName);

            fixture.Repository.Delete(returnedModelCreated.Id);
            Assert.Null(returnedModelCreated);


        }







    }
}