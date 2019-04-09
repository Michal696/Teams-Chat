using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.DAL.Entities;
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
        
        public MediaModel AddMedia(Guid Id, MediaModel Media)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Media.Id = Id;
                var entity = mapper.MediaModelToMediaEntity(Media);
                dbContext.Media.Add(entity);
                dbContext.SaveChanges();
                return mapper.MediaEntityToMediaModel(entity);
            }
        }

        public bool CheckMessageMedia(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var media = dbContext.Media
                    .Select(mapper.MediaEntityToMediaModel)
                    .Where(t => t.Id == Id);
                return media == null ? false : true;
            }
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
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var media = new Media
                {
                    Id = Id
                };
                dbContext.Media.Attach(media);
                dbContext.Media.Remove(media);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<MessageModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Messages
                    .Select(mapper.MessageEntityToMessageModel);
            }
        }

        public IEnumerable<MediaModel> GetGroupMedia(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Media
                    .Select(mapper.MediaEntityToMediaModel)
                    .Where(t => t.Parent.Group.Id == Id);
            }
        }

        public IEnumerable<MessageModel> GetGroupMessages(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Messages
                    .Select(mapper.MessageEntityToMessageModel)
                    .Where(t => t.Group.Id == Id);
            }
        }

        public IEnumerable<MediaModel> GetMessageMedias(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Media
                    .Select(mapper.MediaEntityToMediaModel)
                    .Where(t => t.Parent.Id == Id);
            }
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
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Messages
                    .FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.MessageEntityToMessageModel(entity);
            }
        }
    }
}