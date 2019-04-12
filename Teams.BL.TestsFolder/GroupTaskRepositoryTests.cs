using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;
using Teams.BL.Repositories;
using Teams.BL.Tests;
using Teams.DAL.Entities.Enums;
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
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedModel = fixture.Repository.CreateGroup(model);
            
            Assert.NotNull(returnedModel);
            Assert.Equal(model.Id, returnedModel.Id);
            Assert.Equal(model.Name, returnedModel.Name);
            Assert.Equal(model.Description, returnedModel.Description);

            fixture.Repository.DeleteGroup(returnedModel.Id);
        }
        [Fact]
        public void DeleteGroupGroup()
        {
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedModel = fixture.Repository.CreateGroup(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.DeleteGroup(returnedModel.Id);
            returnedModel = fixture.Repository.GetByIdGroup(returnedModel.Id);
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindGroupById_NotNull()
        {
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedModel = fixture.Repository.CreateGroup(model);

            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdGroup(returnedModel.Id);
            Assert.NotNull(foundModel);
        }

        [Fact]
        public void FindGroupById_Values()
        {
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroup - some random data",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedModel = fixture.Repository.CreateGroup(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdGroup(model.Id);
            Assert.NotNull(foundModel);

            Assert.Equal(model.Name, foundModel.Name);
            Assert.Equal(model.Description, foundModel.Description);
        }

        [Fact]
        public void GroupGetAll_NotNull()
        {
            Assert.NotNull(fixture.Repository.GetAllGroups());
        }


        [Fact]
        public void UpdateWithModel()
        {

            Guid testId = Guid.NewGuid();
            var model = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "Firstname",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedModelCreateGroupd = fixture.Repository.CreateGroup(model);

            Assert.NotNull(returnedModelCreateGroupd);

            String secondName = "SecondName";
            model.Name = secondName;
            fixture.Repository.UpdateGroup(model);

            var foundModel = fixture.Repository.GetByIdGroup(model.Id);
            Assert.NotNull(foundModel);
            
            Assert.NotEqual(returnedModelCreateGroupd.Name, foundModel.Name);
            Assert.Equal(foundModel.Name, secondName);
        }
        
        [Fact]
        public void CreateTaskTask()
        {
            var model = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "Random task test",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = fixture.groupModel
            };
            var returnedModel = fixture.Repository.CreateTask(model);

            Assert.NotNull(returnedModel);
            fixture.Repository.DeleteTask(returnedModel.Id);
        }
        [Fact]
        public void DeleteTaskTask()
        {
            var model = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "Random task test",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = fixture.groupModel
            };
            var returnedModel = fixture.Repository.CreateTask(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.DeleteTask(returnedModel.Id);

            returnedModel = fixture.Repository.GetByIdTask(returnedModel.Id);
            Assert.Null(returnedModel);
        }

        [Fact]
        public void FindTaskById_NotNull()
        {
            var model = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "Random task test",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = fixture.groupModel
            };
            var returnedModel = fixture.Repository.CreateTask(model);

            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdTask(model.Id);
            Assert.NotNull(foundModel);
        }

        [Fact]
        public void FindTaskById_Values()
        {
            var model = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "Random task test",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = fixture.groupModel
            };

            var returnedModel = fixture.Repository.CreateTask(model);
            Assert.NotNull(returnedModel);

            var foundModel = fixture.Repository.GetByIdTask(model.Id);
            Assert.NotNull(foundModel);

            Assert.Equal(model.Text, foundModel.Text);
            Assert.Equal(model.State, foundModel.State);
        }

        

        [Fact]
        public void UpdateWithTaskModel()
        {

            Guid testId = Guid.NewGuid();
            var model = new TaskModel
            {
                Id = testId,
                Text = "Random task test",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = fixture.groupModel
            };

            var returnedModelCreateTaskd = fixture.Repository.CreateTask(model);
            Assert.NotNull(returnedModelCreateTaskd);

            String secondText = "SecondText";
            model.Text = secondText;
            fixture.Repository.UpdateTask(model);

            var foundModel = fixture.Repository.GetByIdTask(model.Id);
            Assert.NotNull(foundModel);

            Assert.NotEqual(returnedModelCreateTaskd.Text, foundModel.Text);
            Assert.Equal(foundModel.Text, secondText);
        }
    }
}