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
    public class UserViewModel : ViewModelBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMessageBoxService messageBoxService;
        private readonly IMediator mediator;

        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();
        public UserModel Model { get; set; }

        public ICommand AddNewUserCommand { get; set; }

        public UserViewModel(IUserRepository userRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            AddNewUserCommand = new RelayCommand(CreateNewUser);

            mediator.Register<UserNewMessage>(UserNewAdded);
        }

        private void CreateNewUser()
        {
            mediator.Send(new UserNewMessage());
        }

        private void UserNewAdded(UserNewMessage userNewMessage)
        {
            Model = new UserModel();
            Model.Id = Guid.NewGuid();
            Model.Name = "User name " + Model.Id;
            userRepository.Create(Model);
            Load();
        }

        public override void Load()
        {
            Users.Clear();
            var users = userRepository.GetAll();
            Users.AddRange(users);
        }
    }
}
