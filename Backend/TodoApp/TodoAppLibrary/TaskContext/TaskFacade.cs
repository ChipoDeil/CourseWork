using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using TodoAppLibrary.TaskContext.Views;
using TodoAppLibrary.Tools;
using TodoAppLibrary.UserContext;

namespace TodoAppLibrary.TaskContext
{
    public class TaskFacade : ITaskFacade
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public TaskFacade(
            IUserRepository userRepository,
            ITaskRepository taskRepository)
        {
            _userRepository = Ensure.Any.IsNotNull(userRepository);
            _taskRepository = Ensure.Any.IsNotNull(taskRepository);
        }

        public IEnumerable<TaskView> GetTasksForUser(Identifier userId)
        {
            Ensure.Any.IsNotNull(userId);

            var currentUser = _userRepository.GetUserById(userId);

            var availableTasks = _taskRepository.GetAllTasksForUser(userId);

            var result = new List<TaskView>();

            availableTasks.ToList().ForEach(t =>
            {
                var memberViewList = new List<MemberView>();
                t.Members.ForEach(m =>
                {
                    var currentMember = _userRepository.GetUserById(m.MemberId);
                    memberViewList.Add(new MemberView(m.MemberId, m.Role,
                        currentMember.UserInfo.Username));
                });

                result.Add(new TaskView(memberViewList, t.Important, t.Done,
                    t.TaskTitle, t.Identifier));
            });

            return result;
        }

        public void AddTaskViewer(Identifier taskId, Identifier userId, Identifier addingUserId)
        {
            Ensure.Any.IsNotNull(taskId);
            Ensure.Any.IsNotNull(userId);
            Ensure.Any.IsNotNull(addingUserId);

            var currentUser = _userRepository.GetUserById(userId);
            var currentAddingUser = _userRepository.GetUserById(addingUserId);
            var currentTask = _taskRepository.GetTaskById(taskId);

            currentTask.AddViewer(userId, addingUserId);
        }

        public void AddTaskRedactor(Identifier taskId, Identifier userId, Identifier addingUserId)
        {
            Ensure.Any.IsNotNull(taskId);
            Ensure.Any.IsNotNull(userId);
            Ensure.Any.IsNotNull(addingUserId);

            var currentUser = _userRepository.GetUserById(userId);
            var currentAddingUser = _userRepository.GetUserById(addingUserId);
            var currentTask = _taskRepository.GetTaskById(taskId);

            currentTask.AddRedactor(userId, addingUserId);
        }

        public void DeleteTaskMember(Identifier taskId, Identifier userId, Identifier deletingUserId)
        {
            Ensure.Any.IsNotNull(taskId);
            Ensure.Any.IsNotNull(userId);
            Ensure.Any.IsNotNull(deletingUserId);

            var currentUser = _userRepository.GetUserById(userId);
            var currentDeletingUser = _userRepository.GetUserById(deletingUserId);
            var currentTask = _taskRepository.GetTaskById(taskId);

            currentTask.DeleteMember(userId, deletingUserId);
        }

        public void MakeTaskDone(Identifier taskId, Identifier userId)
        {
            Ensure.Any.IsNotNull(taskId);
            Ensure.Any.IsNotNull(userId);

            var currentUser = _userRepository.GetUserById(userId);
            var currentTask = _taskRepository.GetTaskById(taskId);

            currentTask.MakeDone(userId);
        }

        public void SwitchTaskImportant(Identifier taskId, Identifier userId)
        {
            Ensure.Any.IsNotNull(taskId);
            Ensure.Any.IsNotNull(userId);

            var currentUser = _userRepository.GetUserById(userId);
            var currentTask = _taskRepository.GetTaskById(taskId);

            currentTask.SwitchImportant(userId);
        }

        public Identifier AddTask(Identifier userId, string taskTitle, bool important)
        {
            Ensure.Any.IsNotNull(userId);

            var currentUser = _userRepository.GetUserById(userId);

            return _taskRepository.AddTask(new Task(taskTitle, userId, important));
        }
    }
}