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
    public class TaskViewModel : ViewModelBase
    {
        private readonly IGroupTaskRepository groupTaskRepository;
        private readonly IUserRepository userRepository;
        private readonly IMessageBoxService messageBoxService;
        private IMediator mediator;

        public ObservableCollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();
        public GroupModel ModelGroup { get; set; }
        public TaskModel ModelTask { get; set; }

        public ICommand TaskAddCommand { get; set; }
        public ICommand TaskDeleteCommand { get; set; }
        public ICommand TaskSelectCommand { get; set; }

        public TaskViewModel(IGroupTaskRepository groupTaskRepository, IUserRepository userRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.groupTaskRepository = groupTaskRepository;
            this.userRepository = userRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            TaskAddCommand = new RelayCommand(TaskAdd);
            TaskDeleteCommand = new RelayCommand(TaskDelete);
            TaskSelectCommand = new RelayCommand<TaskModel>(TaskSelect);

            mediator.Register<GroupSelectMessage>(GroupSelected);
            mediator.Register<TaskNewMessage>(TaskAdded);
            mediator.Register<TaskDeleteMessage>(TaskDeleted);
            mediator.Register<UserLoggedMessage>(UserLogSucces);
            mediator.Register<TaskSelectMessage>(TaskSelected);
            mediator.Register<GroupDeleteMessage>(GroupDeleted);
            mediator.Register<TeamDeleteMessage>(TeamDeleted);
            mediator.Register<TeamSelectMessage>(SeamSelected);
        }

        private void SeamSelected(TeamSelectMessage teamSelectMessage)
        {
            ModelGroup = null;
        }

        private void TeamDeleted(TeamDeleteMessage teamDeleteMessage)
        {
            ModelGroup = null;
        }

        private void GroupDeleted(GroupDeleteMessage groupDeleteMessage)
        {
            ModelGroup = null;
        }

        private void TaskSelect(TaskModel task)
        {
            ModelTask = groupTaskRepository.GetByIdTask(task.Id);
            mediator.Send(new TaskSelectMessage { Id = task.Id});
        }

        private void TaskSelected(TaskSelectMessage taskSelectMessage)
        {
        }

        private void TaskDelete()
        {
            try
            {
                groupTaskRepository.DeleteTask(ModelTask.Id);
            }
            catch
            {
                messageBoxService.Show($"Deleting task failed!", "Deleting failed", MessageBoxButton.OK);
                return;
            }
            ModelTask = null;
            mediator.Send(new TaskDeleteMessage());
        }

        private void TaskDeleted(TaskDeleteMessage taskDeleteMessage)
        {
            Load();
        }

        private void UserLogSucces(UserLoggedMessage userLoggedMessage)
        {
            User = userRepository.GetById(userLoggedMessage.Id);
            Load();
        }

        private void TaskAdd()
        {
            ModelTask = new TaskModel();
            ModelTask.Text = "Text placeholder";
            ModelTask.Id = Guid.NewGuid();
            ModelTask.Group = ModelGroup;
            ModelTask.User = User;
            ModelTask.TimeStamp = DateTime.Now;

            groupTaskRepository.CreateTask(ModelTask);

            mediator.Send(new TaskNewMessage());
        }

        private void TaskAdded(TaskNewMessage taskNewMessage)
        {
            Load();
        }

        private void GroupSelected(GroupSelectMessage groupSelectMessage)
        {
            ModelGroup = groupTaskRepository.GetByIdGroup(groupSelectMessage.Id);
            Load();
        }

        public override void Load()
        {
            if (ModelGroup != null)
            {
                Tasks.Clear();
                var tasks = groupTaskRepository.GetGroupTasks(ModelGroup.Id);
                Tasks.AddRange(tasks);
            }
        }
    }
}
