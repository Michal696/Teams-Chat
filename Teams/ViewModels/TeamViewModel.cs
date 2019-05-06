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
    public class TeamViewModel : ViewModelBase
    {
        private readonly ITeamsRepository teamsRepository;
        private readonly IGroupTaskRepository groupTaskRepository;
        private readonly IUserRepository userRepository;
        private readonly IMessageBoxService messageBoxService;
        private readonly IMediator mediator;

        public ObservableCollection<TeamModel> Teams { get; set; } = new ObservableCollection<TeamModel>();
        public ObservableCollection<GroupModel> Groups { get; set; } = new ObservableCollection<GroupModel>();
        public ObservableCollection<UserModel> AddedUsers { get; set; } = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> OtherUsers { get; set; } = new ObservableCollection<UserModel>();
        public TeamModel Model { get; set; }

        public ICommand AddNewTeamCommand { get; set; }
        public ICommand TeamSelectedCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand TeamUserAddCommand { get; set; }
        public ICommand TeamUserRemoveCommand { get; set; }

        public TeamViewModel(ITeamsRepository teamsRepository, IGroupTaskRepository groupTaskRepository, IUserRepository userRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.teamsRepository = teamsRepository;
            this.groupTaskRepository = groupTaskRepository;
            this.userRepository = userRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            AddNewTeamCommand = new RelayCommand(CreateNewTeam);
            TeamSelectedCommand = new RelayCommand<TeamModel>(TeamSelect);
            TeamUserAddCommand = new RelayCommand<UserModel>(TeamUserAdd);
            TeamUserRemoveCommand = new RelayCommand<UserModel>(TeamUserRemove);
            UpdateCommand = new RelayCommand(TeamUpdate);
            DeleteCommand = new RelayCommand(TeamDelete);

            mediator.Register<TeamNewMessage>(TeamNewAdded);
            mediator.Register<TeamUpdateMessage>(TeamUpdated);
            mediator.Register<TeamDeleteMessage>(TeamDeleted);
            mediator.Register<UserLoggedMessage>(UserLogSucces);
            mediator.Register<TeamUserAddMessage>(TeamUserAdded);
            mediator.Register<TeamUserRemoveMessage>(TeamUserRemoved);
        }

        private void TeamUserRemove(UserModel user)
        {
            teamsRepository.DeleteUserFromTeam(user.Id, Model.Id);
            mediator.Send(new TeamUserRemoveMessage { Id = user.Id });
        }

        private void TeamUserRemoved(TeamUserRemoveMessage teamUserRemoveMessage)
        {
            Load();
        }

        private void TeamUserAdd(UserModel user)
        {
            TeamMemberModel member = new TeamMemberModel();
            member.Id = Guid.NewGuid();
            member.User = user;
            member.Team = Model;
            teamsRepository.AddUserToTeam(member);

            mediator.Send(new TeamUserAddMessage { Id = user.Id});
        }

        private void TeamUserAdded(TeamUserAddMessage teamUserAddMessage)
        {
            Load();
        }

        private void UserLogSucces(UserLoggedMessage userLoggedMessage)
        {
            User = userRepository.GetById(userLoggedMessage.Id);
            Load();
        }

        private void CreateNewTeam()
        {
            var count = teamsRepository.GetAll().Count();
           
            Model = new TeamModel();
            Model.Id = Guid.NewGuid();
            Model.Name = "Team " + count;

            teamsRepository.Create(Model);

            TeamMemberModel TeamMember = new TeamMemberModel();
            TeamMember.Id = Guid.NewGuid();
            TeamMember.Team = Model;
            TeamMember.User = User;

            teamsRepository.AddUserToTeam(TeamMember);

            mediator.Send(new TeamNewMessage());
        }

        private void TeamNewAdded(TeamNewMessage teamNewMessage)
        {
            Load();
        }

        private void TeamSelect(TeamModel team)
        { 
           
            Model = teamsRepository.GetById(team.Id);
            
            mediator.Send(new TeamSelectMessage { Id = team.Id });
        }
        
        private void TeamUpdate()
        {
            
            teamsRepository.Update(Model);
            mediator.Send(new TeamUpdateMessage { Id = Model.Id });
            Load();
        }

        private void TeamUpdated(TeamUpdateMessage team)
        {
            Load();
        }

        private void TeamDelete()
        {
            try
            {
                teamsRepository.DeleteTeamMember(Model.Id);
                teamsRepository.Delete(Model.Id);
            }
            catch
            {
                messageBoxService.Show($"Deleting of '{Model?.Name}' failed!", "Deleting failed", MessageBoxButton.OK);
                return;
            }

            mediator.Send(new TeamDeleteMessage { Id = Model.Id });

            Model = null;
        }

        private void TeamDeleted(TeamDeleteMessage team)
        {
            Load();
        }

        public override void Load()
        {
            if(User != null)
            {
                Teams.Clear();
                var teams = teamsRepository.GetByUser(User.Id);
                Teams.AddRange(teams);
            }
            if (Model != null)
            {
                AddedUsers.Clear();
                var users = teamsRepository.GetTeamUsers(Model.Id);
                AddedUsers.AddRange(users);

                OtherUsers.Clear();
                users = teamsRepository.GetTeamNotUsers(Model.Id);
                OtherUsers.AddRange(users);
            }
        }
    }
}
