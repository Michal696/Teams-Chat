using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;
using Teams.BL.Models;
using Teams.DAL.Entities.Enums;

namespace Teams.BL.Tests

{
    public class GroupTaskRepositoryTestsFixture
    {
        private readonly IGroupTaskRepository repository;
        public readonly TeamModel teamModel;
        public readonly GroupModel groupModel;
        public readonly UserModel userModel;
        public GroupTaskRepositoryTestsFixture()
        {
            repository = new GroupTaskRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());

            teamModel = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "TestTeamModel"
            };
            var teamRepository = new TeamsRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            teamModel = teamRepository.Create(teamModel);

            groupModel = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "TestGroupExample - some random data",
                Description = "TestGroupExample - description",
                Team = teamModel
            };
            groupModel = Repository.CreateGroup(groupModel);

            userModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "TestUser - some random data"
            };
            var userRepository = new UserRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            userModel = userRepository.Create(userModel);

            /*var taskModel = new TaskModel
            {
                Id = Guid.NewGuid(),
                Text = "Task",
                User = userModel,
                State = TaskState.NEW,
                Group = groupModel
            };
            taskModel = Repository.CreateTask(taskModel);*/
        }

        public IGroupTaskRepository Repository => repository;
    }
}