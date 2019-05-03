using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.Commands;
using Teams.BL.Models;
using Teams.BL.Repositories;
using Teams.BL.Services;
using Teams.BL.Messages;
using Teams.BL.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Teams.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        private readonly ITeamsRepository teamsRepository;
        private IMediator mediator;

        public ObservableCollection<TeamModel> Teams { get; set; } = new ObservableCollection<TeamModel>();
        public TeamModel Model { get; set; }

        public ICommand AddNewTeamCommand { get; set; }

        public TeamViewModel(ITeamsRepository teamsRepository, IMediator mediator)
        {
            this.teamsRepository = teamsRepository;
            this.mediator = mediator;

            AddNewTeamCommand = new RelayCommand(CreateNewTeam);

            mediator.Register<TeamNewMessage>(TeamNewAdded);
        }
        private void CreateNewTeam()
        {
            mediator.Send(new TeamNewMessage());
        }

        private void TeamNewAdded(TeamNewMessage teamNewMessage)
        {
            Model = new TeamModel();
            Model.Name = Model.Id + " team";
            teamsRepository.Create(Model);
        }

    }
}
