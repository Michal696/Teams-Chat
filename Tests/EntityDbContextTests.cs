using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Teams.DAL.Entities;
using Xunit.Abstractions;

namespace Tests
{
    public class EntityDbContextTests : IClassFixture<EntityDbContextTestsClassSetupFixture>
    {
        private readonly ITestOutputHelper output;
        private readonly EntityDbContextTestsClassSetupFixture _testContext;
        public EntityDbContextTests(EntityDbContextTestsClassSetupFixture testContext, ITestOutputHelper output)
        {
            _testContext = testContext;
            this.output = output;
        }

        [Fact]
        public void AddMessageTest()
        {
            //Arrange
            var messageEntity = new Message
            {
                Title = "testsMessage",
                Text = "testText"
            };

            //Act
            _testContext.EntityDbContextSUT.Messages.Add(messageEntity);
            _testContext.EntityDbContextSUT.SaveChanges();


            //Assert
            using (var dbx = _testContext.CreateEntityDbContext())
            {
                var retrievedMessage = dbx.Messages.First(entity => entity.Id == messageEntity.Id);

                Assert.Equal(messageEntity, retrievedMessage, Message.DescriptionNameIdComparer);                  
            }
        }

        [Fact]
        public void AddMessageWithUser()
        {
            //Arrange
            var messageEntity = new Message
            {
                Title = "testTitle",
                Member = new User()
                {
                    Name = "testTitleForUser",
                    Password = "NotEncryptedPassword"
                }


                
            };

            //Act
            _testContext.EntityDbContextSUT.Messages.Add(messageEntity);
            _testContext.EntityDbContextSUT.SaveChanges();


            //Assert
            using (var dbx = _testContext.CreateEntityDbContext())
            {
                var retrievedMessage = dbx.Messages
                                    .First(entity => entity.Id == messageEntity.Id);
                

                Assert.Equal(messageEntity, retrievedMessage, Message.DescriptionNameIdComparer);
            }
        }

    }
}
