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
        private readonly IMessageBoxService messageBoxService;

        public UserModel TestUser { get; set; }

        public ICommand UserNewCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.mediator = mediator;
            this.messageBoxService = messageBoxService;

            UserNewCommand = new RelayCommand(UserCreate);
            TestUser = new UserModel();

            mediator.Register<UserNewMessage>(UserCreated);
        }

        private void UserCreate()
        {
            if (userRepository.GetByEmail(TestUser.Email) != null)
            {
                messageBoxService.Show($"Email in use!", "Register failed", MessageBoxButton.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(TestUser.Email)
            || string.IsNullOrWhiteSpace(TestUser.Name)
            || string.IsNullOrWhiteSpace(TestUser.Password))
            {
                messageBoxService.Show($"Registration failed!", "Register failed", MessageBoxButton.OK);
                return;
            }
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
