﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    interface IMessageRepository
    {
        IEnumerable<MessageModel> GetAll();
        IEnumerable<MessageModel> GetGroupMessages(Guid Id);
        IEnumerable<MediaModel> GetGroupMedia(Guid Id);
        bool CheckMessageMedia(Guid Id);
        IEnumerable<MediaModel> GetMessageMedias(Guid Id);
        void Create(MessageModel message);
        void Delete(Guid Id);
        void Update(MessageModel Message);
        void AddMedia(Guid Id, MediaModel Media);
        void DeleteMedia(Guid Id);
    }
}
