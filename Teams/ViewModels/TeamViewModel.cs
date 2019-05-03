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
        private readonly IMessageBoxService messageBoxService;
        private readonly IMediator mediator;

        public ObservableCollection<TeamModel> Teams { get; set; } = new ObservableCollection<TeamModel>();
        public TeamModel Model { get; set; }

        public ICommand AddNewTeamCommand { get; set; }
        public ICommand TeamSelectedCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TeamViewModel(ITeamsRepository teamsRepository, IMediator mediator)
        {
            this.teamsRepository = teamsRepository;
            this.mediator = mediator;

            AddNewTeamCommand = new RelayCommand(CreateNewTeam);
            TeamSelectedCommand = new RelayCommand<TeamModel>(TeamSelect);
            UpdateCommand = new RelayCommand(TeamUpdate);
            DeleteCommand = new RelayCommand(TeamDelete);

            mediator.Register<TeamNewMessage>(TeamNewAdded);
            mediator.Register<TeamSelectMessage>(IngredientSelected);
            mediator.Register<TeamUpdateMessage>(TeamUpdated);
            mediator.Register<TeamDeleteMessage>(TeamDeleted);
        }

        private void CreateNewTeam()
        {
            mediator.Send(new TeamNewMessage());
        }

        private void TeamNewAdded(TeamNewMessage teamNewMessage)
        {
            Model = new TeamModel
            {
                Name = Model.Id + " team"
            };
        }

        private void TeamSelect(TeamModel team)
        {
            mediator.Send(new TeamSelectMessage { Id = team.Id });
        }

        private void IngredientSelected(TeamSelectMessage teamSelectMessage)
        {
            Model = teamsRepository.GetById(teamSelectMessage.Id);
        }

        private void TeamUpdate()
        {
            teamsRepository.Update(Model);
            mediator.Send(new TeamUpdateMessage { Id = Model.Id });
        }

        private void TeamUpdated(TeamUpdateMessage team)
        {
            Load();
        }

        private void TeamDelete()
        {
            try
            {
                teamsRepository.Delete(Model.Id);
            }
            catch
            {
                messageBoxService.Show($"Deleting of {Model?.Name} failed!", "Deleting failed", MessageBoxButton.OK);
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
            Teams.Clear();
            var teams = teamsRepository.GetAll();
            Teams.AddRange(teams);
        }
    }
}
