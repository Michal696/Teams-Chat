using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Repositories;

namespace Teams.BL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        Mapper Mapper = new Mapper();

        public MessageRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public MessageRepository()
        {

        }


        public void AddMedia(Guid Id, MediaModel Media)
        {
            throw new NotImplementedException();
        }

        public bool CheckMessageMedia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public MessageModel Create(MessageModel message)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.MessageModelToMessageEntity(message);
                dbContext.Messages.Add(entity);
                dbContext.SaveChanges();
                return Mapper.MessageEntityToMessageModel(entity);
            }
        }

        public void Delete(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == Id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteMedia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<MessageModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Messages
                    .Select(e => Mapper.MessageEntityToMessageModel(e)).ToList();
            }
        }

        public List<MediaModel> GetGroupMedia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<MessageModel> GetGroupMessages(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<MediaModel> GetMessageMedias(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Update(MessageModel Message)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.MessageModelToMessageEntity(Message);
                dbContext.Messages.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public MessageModel GetMessageById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}