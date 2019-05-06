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
        public ICommand UserLoggedCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.mediator = mediator;
            this.messageBoxService = messageBoxService;

            UserNewCommand = new RelayCommand(UserCreate);
            UserLoggedCommand = new RelayCommand(UserLogged);
            TestUser = new UserModel();

            mediator.Register<UserNewMessage>(UserCreated);
            mediator.Register<UserLoggedMessage>(UserLogSuccess);
        }

        private void UserLogSuccess(UserLoggedMessage userLoggedMessage)
        {
            User = userRepository.GetById(userLoggedMessage.Id);
        }

        private void UserLogged()
        {
            if (string.IsNullOrWhiteSpace(TestUser.Email)
            || string.IsNullOrWhiteSpace(TestUser.Password))
            {
                messageBoxService.Show($"Login failed!", "Login failed", MessageBoxButton.OK);
                return;
            }
            if (userRepository.GetByEmail(TestUser.Email) == null)
            {
                messageBoxService.Show($"User does not exist!", "Login failed", MessageBoxButton.OK);
                return;
            }

            UserModel LogCheck = new UserModel();
            LogCheck = userRepository.GetByEmail(TestUser.Email);
            if (SecurePasswordHasher.Verify(LogCheck.Password, TestUser.Password))
            {
                messageBoxService.Show($"Wrong password!", "Login failed", MessageBoxButton.OK);
                return;
            }

            mediator.Send(new UserLoggedMessage { Id = LogCheck.Id});
        }

        private void UserCreate()
        {
            if (string.IsNullOrWhiteSpace(TestUser.Email)
            || string.IsNullOrWhiteSpace(TestUser.Name)
            || string.IsNullOrWhiteSpace(TestUser.Password))
            {
                messageBoxService.Show($"Registration failed!", "Register failed", MessageBoxButton.OK);
                return;
            }
            if (userRepository.GetByEmail(TestUser.Email) != null)
            {
                messageBoxService.Show($"Email in use!", "Register failed", MessageBoxButton.OK);
                return;
            }
            TestUser.Id = Guid.NewGuid();
            
            userRepository.Create(TestUser);

            mediator.Send(new UserNewMessage());
            mediator.Send(new UserLoggedMessage { Id = TestUser.Id });
        }

        private void UserCreated(UserNewMessage userNewMessage)
        {
            User = TestUser;
        }
    }
}
