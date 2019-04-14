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
            fixture.Repository.Delete(returnedModel.Id);

            returnedModel = fixture.Repository.GetMessageById(returnedModel.Id);
            Assert.Null(returnedModel);
            Assert.Empty(fixture.Repository.GetAll());
        }
       
        [Fact]
        public void FindMessageById_NotNull()
        {
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

            var foundModel = fixture.Repository.GetMessageById(model.Id);
            // New Test
            Assert.NotNull(foundModel);

            fixture.Repository.Delete(returnedModel.Id);

            foundModel = fixture.Repository.GetMessageById(returnedModel.Id);
            Assert.Null(foundModel);
            Assert.Empty(fixture.Repository.GetAll());

        }

        [Fact]
        public void FindMessageById_Values()
        {
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

            var foundModel = fixture.Repository.GetMessageById(model.Id);
            Assert.NotNull(foundModel);
            // New Test
            Assert.Equal(model.Text, foundModel.Text);

            fixture.Repository.Delete(returnedModel.Id);
            foundModel = fixture.Repository.GetMessageById(model.Id);

            Assert.Null(foundModel);
            Assert.Empty(fixture.Repository.GetAll());

        }

        [Fact]
        public void MessageGetAll_NotNull()
        {
            var model = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "TestMessage - some random data",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };

            var returnedModel = fixture.Repository.Create(model);
            // New Test
            Assert.NotEmpty(fixture.Repository.GetAll());

            fixture.Repository.Delete(returnedModel.Id);

            //     Assert.Equal(fixture.Repository.GetAll().First().Id, returnedModel.Id);
            Assert.Empty(fixture.Repository.GetAll());




        }


        [Fact]
        public void UpdateWithModel()
        {

            Guid testId = Guid.NewGuid();
            var model = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "FirstName",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
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
      

        }

    }
}