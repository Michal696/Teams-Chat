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
    public class GroupViewModel : ViewModelBase
    {
        private readonly IGroupTaskRepository groupTaskRepository;
        private readonly ITeamsRepository teamsRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IMessageBoxService messageBoxService;
        private IMediator mediator;

        public ObservableCollection<GroupModel> Groups { get; set; } = new ObservableCollection<GroupModel>();
        public GroupModel Model { get; set; }
        public TeamModel ModelTeam { get; set; }

        public ICommand AddNewGroupCommand { get; set; }
        public ICommand DeleteGroupCommand { get; set; }
        public ICommand GroupSelectedCommand { get; set; }

        public GroupViewModel(IGroupTaskRepository groupTaskRepository, ITeamsRepository teamsRepository, IMessageRepository messageRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.groupTaskRepository = groupTaskRepository;
            this.teamsRepository = teamsRepository;
            this.messageRepository = messageRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            AddNewGroupCommand = new RelayCommand(CreateNewGroup);
            DeleteGroupCommand = new RelayCommand(DeleteGroup);
            GroupSelectedCommand = new RelayCommand<GroupModel>(GroupSelect);

            mediator.Register<GroupNewMessage>(GroupNewAdded);
            mediator.Register<TeamSelectMessage>(TeamSelected);
            mediator.Register<GroupDeleteMessage>(GroupDeleted);
            mediator.Register<TeamDeleteMessage>(TeamDeleted);
        }

        private void TeamDeleted(TeamDeleteMessage obj)
        {
            ModelTeam = null;
        }

        private void GroupSelect(GroupModel group)
        {
            Model = groupTaskRepository.GetByIdGroup(group.Id);
            mediator.Send(new GroupSelectMessage { Id = group.Id });
        }

        private void CreateNewGroup()
        {
            var count = groupTaskRepository.GetAllGroups().Count();

            Model = new GroupModel();
            Model.Id = Guid.NewGuid();
            Model.Description = "Put some description here.";
            Model.Name = "Group " + count;
            Model.Team = ModelTeam;
            groupTaskRepository.CreateGroup(Model);
            mediator.Send(new GroupNewMessage());
        }

        private void GroupNewAdded(GroupNewMessage groupNewMessage)
        {
            Load();
        }

        private void TeamSelected(TeamSelectMessage teamSelectMessage)
        {
            ModelTeam = teamsRepository.GetById(teamSelectMessage.Id);
            Model = null;
            Load();
        }

        private void DeleteGroup()
        {
            try
            {
                messageRepository.DeleteGroupMesages(Model.Id);
                groupTaskRepository.DeleteGroup(Model.Id);
            }
            catch
            {
                messageBoxService.Show($"Deleting of '{Model?.Name}' failed!", "Deleting failed", MessageBoxButton.OK);
                return;
            }

            mediator.Send(new GroupDeleteMessage { Id = Model.Id });

            Model = null;
        }

        private void GroupDeleted(GroupDeleteMessage groupDeleteMessage)
        {
            Load();
        }

        public override void Load()
        {
            if(ModelTeam != null)
            {
                Groups.Clear();
                var groups = groupTaskRepository.GetTeamsGroups(ModelTeam.Id);
                Groups.AddRange(groups);
            }
        }

    }
}
