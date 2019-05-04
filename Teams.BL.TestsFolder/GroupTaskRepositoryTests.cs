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
        public void GroupGetAll_Count()
        {
            int expected = 2; // values from beginning, //TODO!!!
            Assert.Equal(expected, fixture.Repository.GetAllGroups().Count());

            var groupModel = new GroupModel()
            {
                Id = Guid.NewGuid(),
                Name = "NameOfGroupModel",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedGroupModel = fixture.Repository.CreateGroup(groupModel);
            expected++;

            Assert.Equal(expected, fixture.Repository.GetAllGroups().Count());
        }

        [Fact]
        public void GroupGetAll_Values()
        {
            var groupModel = new GroupModel()
            {
                Id = Guid.NewGuid(),
                Name = "NameOfGroupModel",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedGroupModel = fixture.Repository.CreateGroup(groupModel);

            IEnumerable<GroupModel> groupModels = fixture.Repository.GetAllGroups();
            var singleGroupModel = groupModels.Single(m => m.Id == groupModel.Id);
            Assert.Equal(groupModel.Id, singleGroupModel.Id);
            Assert.Equal(groupModel.Name, singleGroupModel.Name);
            Assert.Equal(groupModel.Description, singleGroupModel.Description);

            // clean
            fixture.Repository.DeleteGroup(groupModel.Id);
        }

        [Fact]
        public void GetTeamsGroupsTest_notNull()
        {
            var teamModel = fixture.teamModel;
            var returnedTeamModel = fixture.Repository.GetTeamsGroups(teamModel.Id);
            Assert.NotNull(returnedTeamModel);            
        }

        [Fact]
        public void GetTeamsGroupsTest_count()
        {
            int expected = 2; // values from beginning
            TeamModel teamModel = fixture.teamModel;
            int actual = fixture.Repository.GetTeamsGroups(teamModel.Id).Count();
            Assert.Equal(expected, actual);

            var groupModel = new GroupModel()
            {
                Id = Guid.NewGuid(),
                Name = "NameOfGroupModel",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedGroupModel = fixture.Repository.CreateGroup(groupModel);
            expected++;

            Assert.Equal(expected, fixture.Repository.GetTeamsGroups(teamModel.Id).Count());

            // clean
            fixture.Repository.DeleteGroup(groupModel.Id);
        }
        [Fact]
        public void GetTeamsGroupsTest_values()
        {
            var groupModel = new GroupModel()
            {
                Id = Guid.NewGuid(),
                Name = "NameOfGroupModel",
                Description = "TestGroup - description",
                Team = fixture.teamModel
            };
            var returnedGroupModel = fixture.Repository.CreateGroup(groupModel);

            IEnumerable<GroupModel> groupModels = fixture.Repository.GetTeamsGroups(fixture.teamModel.Id);
            var singleGroupModel = groupModels.Single(m => m.Id == groupModel.Id);
            Assert.Equal(groupModel.Id, singleGroupModel.Id);
            Assert.Equal(groupModel.Name, singleGroupModel.Name);
            Assert.Equal(groupModel.Description, singleGroupModel.Description);

            // clean
            fixture.Repository.DeleteGroup(groupModel.Id);

        }

        [Fact]
        public void GetGroupTasksTest_notNull()
        {
            var groupModel = fixture.groupModel;
            var returnedTeamModel = fixture.Repository.GetTeamsGroups(groupModel.Id);
            Assert.NotNull(returnedTeamModel);
        }
        [Fact]
        public void GetGroupTasksTest_count()
        {
            int expected = 0; // values from beginning
            var groupModel = fixture.groupModel;


            int actual = fixture.Repository.GetGroupTasks(groupModel.Id).Count();
            Assert.Equal(expected, actual);

            var taskModel = new TaskModel()
            {
                Id = Guid.NewGuid(),
                Text = "Task",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = groupModel

            };
            var returnedTaskModel = fixture.Repository.CreateTask(taskModel);
            expected++;

            Assert.Equal(expected, fixture.Repository.GetGroupTasks(groupModel.Id).Count());

            // clean
            fixture.Repository.DeleteTask(taskModel.Id);
        }

        [Fact]
        public void GetGroupTasksTest_values()
        {
            var taskModel = new TaskModel()
            {
                Id = Guid.NewGuid(),
                Text = "Task",
                User = fixture.userModel,
                State = TaskState.NEW,
                Group = fixture.groupModel
            };
            var returnedTaskModel = fixture.Repository.CreateTask(taskModel);

            IEnumerable<TaskModel>taskModels = fixture.Repository.GetGroupTasks(fixture.groupModel.Id);
            var singleTaskModel = taskModels.Single(m => m.Id == taskModel.Id);
            Assert.Equal(taskModel.Id, singleTaskModel.Id);
            Assert.Equal(taskModel.Text, singleTaskModel.Text);
            Assert.Equal(taskModel.State, singleTaskModel.State);

            // clean
            fixture.Repository.DeleteTask(taskModel.Id);
        }
        [Fact]
        public void AddUserToGroupTest_NotNull()
        {


            var groupUserPermissionModel = new GroupUserPermissionModel()
            {
                Group = fixture.groupModel,
                User = fixture.userModel,
                Permit = Permission.MANAGE
            };
            var returnedGroupUserPermissionModel = fixture.Repository.AddUserToGroup(groupUserPermissionModel);
            Assert.NotNull(returnedGroupUserPermissionModel);
        }


        [Fact]
        public void GetTaskChangesTest_Notnull()
        {
            Assert.NotNull(fixture.Repository.GetTaskChanges(Guid.NewGuid()));          
        }

        [Fact]
        public void GetTaskChangesTest_Count()
        {
            Assert.False(true);
        }

        [Fact]
        public void GetTaskChangesTest_Values()
        {
            Assert.False(true);
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

            // clean
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

            // clean
            fixture.Repository.DeleteGroup(returnedModel.Id);
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

            // clean
            fixture.Repository.DeleteGroup(returnedModel.Id);
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

            // clean
            fixture.Repository.DeleteGroup(returnedModelCreateGroupd.Id);
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

            // clean
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

            // clean
            fixture.Repository.DeleteTask(returnedModel.Id);
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

            // clean
            fixture.Repository.DeleteTask(returnedModel.Id);
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

            // clean
            fixture.Repository.DeleteTask(returnedModelCreateTaskd.Id);
        }
    }
}