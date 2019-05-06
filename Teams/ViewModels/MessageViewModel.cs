using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.Commands;
using Teams.Services;
using Teams.BL.Models;
using Teams.BL.Repositories;
using Teams.BL.Services;
using Teams.BL.Messages;
using Teams.BL.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace Teams.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IGroupTaskRepository groupTaskRepository;
        private readonly IMessageBoxService messageBoxService;
        private readonly IMediator mediator;

        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        public MessageModel ModelMessage { get; set; }
        public GroupModel ModelGroup { get; set; }

        public ICommand MessageNewCommand { get; set; }

        public MessageViewModel(IUserRepository userRepository, IMessageRepository messageRepository,IGroupTaskRepository groupTaskRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.messageRepository = messageRepository;
            this.groupTaskRepository = groupTaskRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            ModelMessage = new MessageModel();

            MessageNewCommand = new RelayCommand(MessageCreate);
            
            mediator.Register<UserLoggedMessage>(UserLogSucces);
            mediator.Register<MessageNewMessage>(MessageCreated);
            mediator.Register<GroupSelectMessage>(GroupSelected);
            mediator.Register<GroupDeleteMessage>(GroupDeleted);
        }

        private void GroupDeleted(GroupDeleteMessage groupDeleteMessage)
        {
            Load();
            ModelGroup = null;
        }

        private void GroupSelected(GroupSelectMessage groupSelectMessage)
        {
            ModelGroup = groupTaskRepository.GetByIdGroup(groupSelectMessage.Id);
            Load();
        }

        private void MessageCreate()
        {
            if(ModelGroup == null)
            {
                return;
            }
            ModelMessage.Id = Guid.NewGuid();
            ModelMessage.User = User;
            ModelMessage.Group = ModelGroup;
            ModelMessage.TimeStamp = DateTime.Now;

            messageRepository.Create(ModelMessage);

            mediator.Send(new MessageNewMessage());
        }

        private void MessageCreated(MessageNewMessage messageNewMessage)
        {
            Load();
        }

        private void UserLogSucces(UserLoggedMessage userLoggedMessage)
        {
            User = userRepository.GetById(userLoggedMessage.Id);
            Load();
        }

        public override void Load()
        {
            if (ModelGroup != null)
            {
                Messages.Clear();
                var messages = messageRepository.GetGroupMessages(ModelGroup.Id);
                Messages.AddRange(messages);
            }
        }
    }
}
