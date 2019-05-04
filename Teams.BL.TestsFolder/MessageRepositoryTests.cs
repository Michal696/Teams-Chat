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

            // clean
            fixture.Repository.Delete(returnedModel.Id);

        }


        [Fact]
        public void DeleteMessage()
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
            
            Assert.Empty(fixture.Repository.GetAll());

        }


        [Fact]
        public void MessageGetAll_NotNullWithNoModel()
        {
            Assert.NotNull(fixture.Repository.GetAll());
            Assert.Empty(fixture.Repository.GetAll());
        }


        [Fact]
        public void UpdateWithModel()
        {
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

            Assert.Empty(fixture.Repository.GetAll());
        }

        [Fact]
        public void GetGroupMessagesById_values()
        { 
            var messageModel1 = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "FirstText",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };

            var messageModel2 = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "SecondText",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };
            

            var returnedMessageModel1 = fixture.Repository.Create(messageModel1);
            var returnedMessageModel2 = fixture.Repository.Create(messageModel2);

            IEnumerable<MessageModel> messageModels = fixture.Repository.GetGroupMessages(fixture.groupModel.Id);

            var singleReturnMessageModel1 = messageModels.Single(m => m.Id == messageModel1.Id);
            Assert.Equal(messageModel1.Id, singleReturnMessageModel1.Id);
            Assert.Equal(messageModel1.Text, singleReturnMessageModel1.Text);

            var singleReturnMessageModel2 = messageModels.Single(m => m.Id == messageModel2.Id);
            Assert.Equal(messageModel2.Id, singleReturnMessageModel2.Id);
            Assert.Equal(messageModel2.Text, singleReturnMessageModel2.Text);


            // clean
            fixture.Repository.Delete(returnedMessageModel1.Id);
            fixture.Repository.Delete(returnedMessageModel2.Id);
        }


        [Fact]
        public void GetGroupMessagesById_count()
        {            
            var messageModel1 = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "FirstText",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };

            var messageModel2 = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "SecondText",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };


            var returnedMessageModel1 = fixture.Repository.Create(messageModel1);
            var returnedMessageModel2 = fixture.Repository.Create(messageModel2);

            IEnumerable<MessageModel> messageModels = fixture.Repository.GetGroupMessages(fixture.groupModel.Id);
            int expected = 2;
            Assert.Equal(expected, messageModels.Count());


            // clean
            fixture.Repository.Delete(returnedMessageModel1.Id);
            fixture.Repository.Delete(returnedMessageModel2.Id);
        }

        [Fact]
        public void AddMediaTest()
        {
            Guid id = Guid.NewGuid();

            MessageModel messageModel = new MessageModel()
            {
                Id = Guid.NewGuid(),
                Title = "Message Title"
            };
        

            MediaModel mediaModel = new MediaModel()
            {
                Parent = messageModel,
                Data = "TestData"
            };

            MediaModel returnedMediaModel = fixture.Repository.AddMedia(id, mediaModel);
            Assert.NotNull(returnedMediaModel);

            //clean
            fixture.Repository.DeleteMedia(returnedMediaModel.Id);

        }

        [Fact]
        public void DeleteMediaTest()
        {
            Guid id = Guid.NewGuid();

            MessageModel messageModel = new MessageModel()
            {
                Id = Guid.NewGuid(),
                Title = "Message Title"
            };


            MediaModel mediaModel = new MediaModel()
            {
                Parent = messageModel,
                Data = "TestData"
            };

            MediaModel returnedMediaModel = fixture.Repository.AddMedia(id, mediaModel);
            Assert.NotNull(returnedMediaModel);

            fixture.Repository.DeleteMedia(returnedMediaModel.Id);
            Assert.Null(returnedMediaModel);
        }

        [Fact]
        public void GetGroupMediaById_values()
        {
            var mediaModel1 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data"                
            };

            var mediaModel2 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data2",
                Parent = null
            };


            var returnedMediaModel1 = fixture.Repository.AddMedia(mediaModel1.Id, mediaModel1);
            var returnedMediaModel2 = fixture.Repository.AddMedia(mediaModel2.Id, mediaModel2);

            IEnumerable<MediaModel> mediaModels = fixture.Repository.GetGroupMedia(fixture.groupModel.Id);

            var singleReturnMediaModel1 = mediaModels.Single(m => m.Id == mediaModel1.Id);
            Assert.Equal(mediaModel1.Id, singleReturnMediaModel1.Id);
            Assert.Equal(mediaModel1.Data, singleReturnMediaModel1.Data);

            var singleReturnMediaModel2 = mediaModels.Single(m => m.Id == mediaModel2.Id);
            Assert.Equal(mediaModel2.Id, singleReturnMediaModel2.Id);
            Assert.Equal(mediaModel2.Data, singleReturnMediaModel2.Data);


            // clean
            fixture.Repository.DeleteMedia(returnedMediaModel1.Id);
            fixture.Repository.DeleteMedia(returnedMediaModel2.Id);
        }


        [Fact]
        public void GetGroupMediaById_Count()
        {
            var mediaModel1 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data"
            };

            var mediaModel2 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data2",
                Parent = null
            };


            var returnedMediaModel1 = fixture.Repository.AddMedia(mediaModel1.Id, mediaModel1);
            var returnedMediaModel2 = fixture.Repository.AddMedia(mediaModel2.Id, mediaModel2);

            IEnumerable<MediaModel> mediaModels = fixture.Repository.GetGroupMedia(fixture.groupModel.Id);
            int expected = 2;
            Assert.Equal(expected, mediaModels.Count());


            // clean
            fixture.Repository.DeleteMedia(returnedMediaModel1.Id);
            fixture.Repository.DeleteMedia(returnedMediaModel2.Id);
        }

        [Fact]
        public void CheckMessageMedia_ById()
        {
            Guid id = Guid.NewGuid();
            bool check = fixture.Repository.CheckMessageMedia(id);
            Assert.False(check);

            var mediaModel1 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data"
            };

            var returnedMediaModel1 = fixture.Repository.AddMedia(mediaModel1.Id, mediaModel1);

            check = fixture.Repository.CheckMessageMedia(returnedMediaModel1.Id);
            Assert.True(check);

            // clean
            fixture.Repository.DeleteMedia(returnedMediaModel1.Id);
        }

        [Fact]
        public void GetMessageMedias_ByMessageId()
        {

            var mediaModel1 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data"
            };

            var mediaModel2 = new MediaModel
            {
                Id = Guid.NewGuid(),
                Data = "random data2",
                Parent = null
            };

            var messageModel = new MessageModel
            {
                Id = Guid.NewGuid(),
                Text = "FirstName",
                User = fixture.userModel,
                Group = fixture.groupModel,
                Parent = null
            };


            var returnedMediaModel1 = fixture.Repository.AddMedia(mediaModel1.Id, mediaModel1);
            var returnedMediaModel2 = fixture.Repository.AddMedia(mediaModel2.Id, mediaModel2);
            Assert.NotNull(returnedMediaModel1);
            Assert.NotNull(returnedMediaModel2);

            var returnedMessageModelCreated = fixture.Repository.Create(messageModel);
            Assert.NotNull(returnedMessageModelCreated);



        }
    }
}