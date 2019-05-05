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
        private readonly IGroupTaskRepository groupTaskRepository;
        private readonly IMessageBoxService messageBoxService;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public TeamViewModel TeamViewModel => new TeamViewModel(teamsRepository, groupTaskRepository,userRepository, messageBoxService, mediator);
        public UserViewModel UserViewModel => new UserViewModel(userRepository, messageBoxService, mediator);
        public GroupViewModel GroupViewModel => new GroupViewModel(groupTaskRepository , teamsRepository, messageBoxService, mediator);
        public TaskViewModel TaskViewModel => new TaskViewModel(groupTaskRepository, userRepository, messageBoxService, mediator);
        public RegisterViewModel RegisterViewModel => new RegisterViewModel(userRepository, messageBoxService, mediator);
        public ViewModelLocator()
        {
            mediator = new Mediator();
            dbContextFactory = new DesignDbContextFactory();
            mapper = new Mapper();
            teamsRepository = new TeamsRepository(dbContextFactory, mapper);
            userRepository = new UserRepository(dbContextFactory, mapper);
            groupTaskRepository = new GroupTaskRepository(dbContextFactory, mapper);
            messageBoxService = new MessageBoxService();
        }
    }
}
