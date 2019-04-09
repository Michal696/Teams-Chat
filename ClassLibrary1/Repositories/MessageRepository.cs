using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Mapper;
using Teams.BL.Repositories;

namespace Teams.BL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;

        public MessageRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
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
                var entity = mapper.MessageModelToMessageEntity(message);
                dbContext.Messages.Add(entity);
                dbContext.SaveChanges();
                return mapper.MessageEntityToMessageModel(entity);
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

        public IEnumerable<MessageModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Messages
                    .Select(e => mapper.MessageEntityToMessageModel(e)).ToList();
            }
        }

        public IEnumerable<MediaModel> GetGroupMedia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageModel> GetGroupMessages(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MediaModel> GetMessageMedias(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Update(MessageModel Message)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MessageModelToMessageEntity(Message);
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