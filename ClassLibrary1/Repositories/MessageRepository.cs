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
using Microsoft.EntityFrameworkCore;

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
                dbContext.Messages.Attach(entity.Parent);
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
                dbContext.Users.Attach(entity.User);
                dbContext.Messages.Attach(entity.Parent);
                dbContext.Groups.Attach(entity.Group);
                dbContext.Messages.Add(entity);
                dbContext.SaveChanges();
                return mapper.MessageEntityToMessageModel(entity);
            }
        }

        public void Delete(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = new Message
                {
                    Id = Id
                };
                dbContext.Messages.Attach(entity);
                dbContext.Messages.Remove(entity);
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
                    .Include(t => t.Group)
                    .Include(t => t.User)
                    .Include(t => t.Group.Team)
                    .Select(mapper.MessageEntityToMessageModel);
            }
        }

        public IEnumerable<MediaModel> GetGroupMedia(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Media  /* TODO include */
                    .Select(mapper.MediaEntityToMediaModel)
                    .Where(t => t.Parent.Group.Id == Id);
            }
        }

        public IEnumerable<MessageModel> GetGroupMessages(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Messages
                    .Include(t => t.Group)
                    .Include(t => t.User)
                    .Include(t => t.Group.Team)
                    .Select(mapper.MessageEntityToMessageModel)
                    .Where(t => t.Group.Id == Id);
            }
        }

        public IEnumerable<MediaModel> GetMessageMedias(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Media
                    .Include(t => t.Parent)
                    .Include(t => t.Parent.Group)
                    .Include(t => t.Parent.User)
                    .Include(t => t.Parent.Group.Team)
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
                    .Include(t => t.Group)
                    .Include(t => t.User)
                    .Include(t => t.Group.Team)
                    .Include(t => t.Parent)
                    .FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.MessageEntityToMessageModel(entity);
            }
        }
    }
}