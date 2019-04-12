using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;
using Teams.BL.Repositories;

namespace Teams.BL.Tests

{
    public class MessageRepositoryTestsFixture
    {
        private readonly IMessageRepository repository;
        public readonly UserModel userModel;
        public readonly GroupModel groupModel;
        public MessageRepositoryTestsFixture()
        {
            repository = new MessageRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            
            var teamModel = new TeamModel
            {
                Id = Guid.NewGuid(),
                Name = "Test Team"
            };
            var teamRepository = new TeamsRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            teamModel = teamRepository.Create(teamModel);

            groupModel = new GroupModel
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "Test Group description",
                Team = teamModel
            };
            var groupRepository = new GroupTaskRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            groupModel = groupRepository.CreateGroup(groupModel);

            userModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "Test User"
            };
            var userRepository = new UserRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
            userModel = userRepository.Create(userModel);

            /*var messageModel = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "Test Message text",
                User = userModel,
                Parent = null,
                Group = groupModel
            };
            repository.Create(messageModel);*/
        }

        public IMessageRepository Repository => repository;
    }
}