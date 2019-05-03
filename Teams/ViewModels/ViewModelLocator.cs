using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;
using Teams.BL.Services;

namespace Teams.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IMediator mediator;
        private readonly ITeamsRepository teamsRepository;

        public TeamViewModel TeamViewModel => new TeamViewModel(teamsRepository, mediator);

        public ViewModelLocator()
        {
            mediator = new Mediator();
        }
    }
}
