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
        private readonly IMessageBoxService messageBoxService;
        private IMediator mediator;

        public ObservableCollection<GroupModel> Groups { get; set; } = new ObservableCollection<GroupModel>();
        public GroupModel Model { get; set; }
        public TeamModel ModelTeam { get; set; }

        public ICommand AddNewGroupCommand { get; set; }

        public GroupViewModel(IGroupTaskRepository groupTaskRepository, ITeamsRepository teamsRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.groupTaskRepository = groupTaskRepository;
            this.teamsRepository = teamsRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            AddNewGroupCommand = new RelayCommand(CreateNewGroup);

            mediator.Register<GroupNewMessage>(GroupNewAdded);
            mediator.Register<TeamSelectMessage>(TeamSelected);
        }
        private void CreateNewGroup()
        {
            Model = new GroupModel();
            Model.Id = Guid.NewGuid();
            Model.Description = "Put some description here.";
            Model.Name = "Group " + Model.Id;
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
