using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;
using Teams.BL.Services;
using Teams.Services;
using Teams.BL.Factories;
using Teams.BL.Mapper;

namespace Teams.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IMediator mediator;
        private readonly IDbContextFactory dbContextFactory;
        private readonly ITeamsRepository teamsRepository;
        private readonly IMessageBoxService messageBoxService;
        private readonly IMapper mapper;

        public TeamViewModel TeamViewModel => new TeamViewModel(teamsRepository, messageBoxService, mediator);

        public ViewModelLocator()
        {
            mediator = new Mediator();
            dbContextFactory = new DesignDbContextFactory();
            mapper = new Mapper();
            teamsRepository = new TeamsRepository(dbContextFactory, mapper);
            messageBoxService = new MessageBoxService();
        }
    }
}
