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
        private readonly IMessageBoxService messageBoxService;
        private IMediator mediator;

        public ObservableCollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();
        public GroupModel ModelGroup { get; set; }
        public TaskModel ModelTask { get; set; }

        public ICommand TaskAddCommand { get; set; }

        public TaskViewModel(IGroupTaskRepository groupTaskRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.groupTaskRepository = groupTaskRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            TaskAddCommand = new RelayCommand(TaskAdd);

            mediator.Register<GroupSelectMessage>(GroupSelected);
            mediator.Register<TaskNewMessage>(TaskAdded);
        }

        private void TaskAdd()
        {
            ModelTask = new TaskModel();
            ModelTask.Text = "Text placeholder";
            ModelTask.Group = ModelGroup;
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
