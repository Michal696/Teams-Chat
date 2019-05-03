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
    class GroupViewModel : ViewModelBase
    {
        private readonly IGroupTaskRepository groupTaskRepository;
        private IMediator mediator;

        public ObservableCollection<GroupModel> Groups { get; set; } = new ObservableCollection<GroupModel>();

        public ICommand AddNewGroupCommand { get; set; }

        public GroupViewModel(IGroupTaskRepository groupTaskRepository, IMediator mediator)
        {
            this.groupTaskRepository = groupTaskRepository;
            this.mediator = mediator;

            AddNewGroupCommand = new RelayCommand(CreateNewGroup);

            mediator.Register<GroupNewMessage>(GroupNewAdded);
        }
        private void CreateNewGroup()
        {
            mediator.Send(new GroupNewMessage());
        }

        private void GroupNewAdded(GroupNewMessage groupNewMessage)
        {
            throw new NotImplementedException();
        }

    }
}
