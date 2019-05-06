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
    public class MessageRepository : RepositoryBase, IMessageRepository
    {
        public MessageRepository(IDbContextFactory dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {
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
                return media.Count() == 0 ? false : true;
            }
        }

        protected void AttachEntity(String type, EntityBase entity)
        {
            if (entity == null)
            {
                return;
            }
            
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
            
                switch (type)
                {
                    case "Users": dbContext.Users.Attach((User) entity); break;
                    case "Messages": dbContext.Messages.Attach((Message) entity); break;
                    case "Groups": dbContext.Groups.Attach((Group) entity); break;
                    case "Media": dbContext.Media.Attach((Media) entity); break;
                    case "Teams": dbContext.Team.Attach((Team) entity); break;
                    case "Tasks": dbContext.Tasks.Attach((DAL.Entities.Task) entity); break;

                }
            }
        }

        public MessageModel Create(MessageModel message)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MessageModelToMessageEntity(message);
               
                if (entity.Parent != null)
                {
                    dbContext.Messages.Attach(entity.Parent);
                    if (entity.Parent.User.Id != entity.User.Id)
                    {
                        dbContext.Users.Attach(entity.User);
                    }
                }
                else
                {
                    dbContext.Users.Attach(entity.User);
                    dbContext.Groups.Attach(entity.Group);
                }
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
        public void DeleteGroupMesages(Guid Id)
        {
            var TeamMessages = GetParentMessage(Id);
            IEnumerable<MessageModel> childs;
            foreach (MessageModel message in TeamMessages)
            {
                childs = GetChildMessage(Id, message.Id);
                foreach(MessageModel child in childs)
                {
                    Delete(child.Id);
                }
                Delete(message.Id);
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
            
            return dbContext.Messages
                .Include(t => t.Group)
                .Include(t => t.User)
                .Include(t => t.Group.Team)
                .Select(mapper.MessageEntityToMessageModel);   
        }

        public IEnumerable<MediaModel> GetGroupMedia(Guid Id)
        {
          
            return dbContext.Media
                .Include(t => t.Parent)
                .Include(t => t.Parent.Group)
                .Select(mapper.MediaEntityToMediaModel)
                .Where(t => t.Parent.Group.Id == Id);

        }

        public IEnumerable<MessageModel> GetParentMessage(Guid Id)
        {
            return dbContext.Messages
                .Include(t => t.Group)
                .Include(t => t.User)
                .Include(t => t.Group.Team)
                .Select(mapper.MessageEntityToMessageModel)
                .Where(t => t.Group.Id == Id)
                .Where(t => t.Parent == null)
                .OrderBy(t => t.TimeStamp.TimeOfDay)
                                .ThenBy(t => t.TimeStamp.Date)
                                .ThenBy(t => t.TimeStamp.Year);
        }

        public IEnumerable<MessageModel> GetChildMessage(Guid GId, Guid MId)
        {
            return dbContext.Messages
                .Include(t => t.Group)
                .Include(t => t.User)
                .Include(t => t.Group.Team)
                .Select(mapper.MessageEntityToMessageModel)
                .Where(t => t.Group.Id == GId)
                .Where(t => t.Parent != null)
                .Where(t => t.Parent.Id == MId)
                .OrderBy(t => t.TimeStamp.TimeOfDay)
                                .ThenBy(t => t.TimeStamp.Date)
                                .ThenBy(t => t.TimeStamp.Year);
        }

        public IEnumerable<MessageModel> GetGroupMessages(Guid Id)
        {

            return dbContext.Messages
                .Include(t => t.Group)
                .Include(t => t.User)
                .Include(t => t.Group.Team)
                .Select(mapper.MessageEntityToMessageModel)
                .Where(t => t.Group.Id == Id)
                .OrderBy(t => t.TimeStamp.TimeOfDay)
                                .ThenBy(t => t.TimeStamp.Date)
                                .ThenBy(t => t.TimeStamp.Year);
                                
          
        }

        public IEnumerable<MediaModel> GetMessageMedias(Guid Id)
        {
           
            return dbContext.Media
                .Include(t => t.Parent)
                .Include(t => t.Parent.Group)
                .Include(t => t.Parent.User)
                .Include(t => t.Parent.Group.Team)
                .Select(mapper.MediaEntityToMediaModel)
                .Where(t => t.Parent.Id == Id);
            
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