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

        // TODO DELETE WHEN YOU SEE THIS and it is after 6.4.2019
        //[Fact]
        //public void SuccessfulTest()
        //{
        //    output.WriteLine("This should work");
        //    Assert.Equal(10, 5 + 5);
        //}

        //[Fact]
        //public void UnSuccessfulTest()
        //{
        //    Assert.Equal(10, 4 + 5);
        //}

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

    }
}
