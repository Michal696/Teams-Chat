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
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMediator mediator;

        public UserModel TestUser { get; set; }

        public ICommand UserNewCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.mediator = mediator;

            UserNewCommand = new RelayCommand(UserCreate);

            mediator.Register<UserNewMessage>(UserCreated);
        }

        private void UserCreate()
        {
            TestUser = new UserModel();
            TestUser.Id = Guid.NewGuid();

            userRepository.Create(TestUser);

            mediator.Send(new UserNewMessage());
        }

        private void UserCreated(UserNewMessage userNewMessage)
        {
            User = TestUser;
        }
    }
}
