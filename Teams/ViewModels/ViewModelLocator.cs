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
        private readonly IMessageRepository messageRepository;

        public TeamViewModel TeamViewModel {
            get
            {
                if (teamViewModel != null)
                    return teamViewModel;

                teamViewModel = new TeamViewModel(teamsRepository, groupTaskRepository, userRepository, messageBoxService, mediator);
                return teamViewModel;
            }
        }
        public TeamViewModel teamViewModel;
        public UserViewModel UserViewModel => new UserViewModel(userRepository, messageBoxService, mediator);
        public MessageViewModel MessageViewModel => new MessageViewModel(userRepository, messageRepository, groupTaskRepository, messageBoxService, mediator);
        public GroupViewModel GroupViewModel => new GroupViewModel(groupTaskRepository, teamsRepository, messageBoxService, mediator);
        public TaskViewModel taskModelView;
        public TaskViewModel TaskViewModel {
            get {
                if (taskModelView != null)
                    return taskModelView;

                taskModelView = new TaskViewModel(groupTaskRepository, userRepository, messageBoxService, mediator);
                return taskModelView;
            }
        }
        public RegisterViewModel RegisterViewModel => new RegisterViewModel(userRepository, messageBoxService, mediator);
        public ViewModelLocator()
        {
            mediator = new Mediator();
            dbContextFactory = new DesignDbContextFactory();
            mapper = new Mapper();
            teamsRepository = new TeamsRepository(dbContextFactory, mapper);
            userRepository = new UserRepository(dbContextFactory, mapper);
            messageRepository = new MessageRepository(dbContextFactory, mapper);
            groupTaskRepository = new GroupTaskRepository(dbContextFactory, mapper);
            messageBoxService = new MessageBoxService();
        }
    }
}
