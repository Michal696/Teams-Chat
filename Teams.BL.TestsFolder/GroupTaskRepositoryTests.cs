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
    public class GroupRepositoryTests : IClassFixture<GroupTaskRepositoryTestsFixture>
    {
        private readonly GroupTaskRepositoryTestsFixture fixture;       


        public GroupRepositoryTests(GroupTaskRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateGroupGroup()
        {
            var model = new GroupModel
            {
                Name = "TestGroup - some random data"
            };

            var returnedModel = fixture.Repository.CreateGroup(model);
            // New Test
            Assert.NotNull(returnedModel);
            fixture.Repository.DeleteGroup(returnedModel.Id);
        }
        [Fact]
        public void DeleteGroupGroup()
        {
            var model = new GroupModel
            {
                Name = "TestGroup - some random data"
            };

            var returnedModel = fixture.Repository.CreateGroup(model);

            Assert.NotNull(returnedModel);
            fixture.Repository.DeleteGroup(returnedModel.Id);
            // New Test
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindGroupById_NotNull()
        {
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data"
            };

            var returnedModel = fixture.Repository.CreateGroup(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdGroup(model.Id);
            // New Test
            Assert.NotNull(foundModel);

            fixture.Repository.DeleteGroup(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        [Fact]
        public void FindGroupById_Values()
        {
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data"
            };

            var returnedModel = fixture.Repository.CreateGroup(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdGroup(model.Id);
            Assert.NotNull(foundModel);
            // New Test
            Assert.Equal(model.Name, foundModel.Name);

            fixture.Repository.DeleteGroup(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        [Fact]
        public void GroupGetAll_NotNull()
        {
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data"
            };

            var returnedModel = fixture.Repository.CreateGroup(model);
            // New Test
            Assert.NotNull(fixture.Repository.GetAllGroups());

            fixture.Repository.DeleteGroup(returnedModel.Id);
            Assert.Null(returnedModel);
        }


        [Fact]
        public void UpdateWithModel()
        {

            Guid testId = Guid.NewGuid();
            var model = new GroupModel
            {
                Id = testId,
                Name = "FirstName"
            };

            var returnedModelCreateGroupd = fixture.Repository.CreateGroup(model);
            Assert.NotNull(returnedModelCreateGroupd);

            String secondName = "SecondName";
            model.Name = secondName;
            fixture.Repository.UpdateGroup(model);

            var foundModel = fixture.Repository.GetByIdGroup(model.Id);
            Assert.NotNull(foundModel);

            // New Test
            Assert.NotEqual(returnedModelCreateGroupd.Name, foundModel.Name);
            Assert.Equal(foundModel.Name, secondName);

            fixture.Repository.DeleteGroup(returnedModelCreateGroupd.Id);
            Assert.Null(returnedModelCreateGroupd);


        }













        [Fact]
        public void CreateTaskTask()
        {
            var model = new TaskModel
            {
                Text = "TestTask - some random data"
            };

            var returnedModel = fixture.Repository.CreateTask(model);
            // New Test
            Assert.NotNull(returnedModel);
            fixture.Repository.DeleteTask(returnedModel.Id);
        }
        [Fact]
        public void DeleteTaskTask()
        {
            var model = new TaskModel
            {
                Text = "TestTask - some random data"
            };

            var returnedModel = fixture.Repository.CreateTask(model);

            Assert.NotNull(returnedModel);
            fixture.Repository.DeleteTask(returnedModel.Id);
            // New Test
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindTaskById_NotNull()
        {
            var model = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "TestTask - some random data"
            };

            var returnedModel = fixture.Repository.CreateTask(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdTask(model.Id);
            // New Test
            Assert.NotNull(foundModel);

            fixture.Repository.DeleteTask(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        [Fact]
        public void FindTaskById_Values()
        {
            var model = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "TestTask - some random data"
            };

            var returnedModel = fixture.Repository.CreateTask(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdTask(model.Id);
            Assert.NotNull(foundModel);
            // New Test
            Assert.Equal(model.Text, foundModel.Text);

            fixture.Repository.DeleteTask(returnedModel.Id);
            Assert.Null(returnedModel);


        }

        

        [Fact]
        public void UpdateWithTaskModel()
        {

            Guid testId = Guid.NewGuid();
            var model = new TaskModel
            {
                Id = testId,
                Text = "FirstText"
            };

            var returnedModelCreateTaskd = fixture.Repository.CreateTask(model);
            Assert.NotNull(returnedModelCreateTaskd);

            String secondText = "SecondText";
            model.Text = secondText;
            fixture.Repository.UpdateTask(model);

            var foundModel = fixture.Repository.GetByIdTask(model.Id);
            Assert.NotNull(foundModel);

            // New Test
            Assert.NotEqual(returnedModelCreateTaskd.Text, foundModel.Text);
            Assert.Equal(foundModel.Text, secondText);

            fixture.Repository.DeleteTask(returnedModelCreateTaskd.Id);
            Assert.Null(returnedModelCreateTaskd);


        }
    }
}