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
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageModel> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public MessageModel GetMessageById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
