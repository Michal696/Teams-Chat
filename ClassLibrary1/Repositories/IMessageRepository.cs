using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public interface IMessageRepository
    {
        List<MessageModel> GetAll();
        List<MessageModel> GetGroupMessages(Guid Id);
        List<MediaModel> GetGroupMedia(Guid Id);
        bool CheckMessageMedia(Guid Id);
        List<MediaModel> GetMessageMedias(Guid Id);
        MessageModel GetMessageById(Guid Id);
        MessageModel Create(MessageModel message);
        void Delete(Guid Id);
        void Update(MessageModel Message);
        void AddMedia(Guid Id, MediaModel Media);
        void DeleteMedia(Guid Id);
    }
}
