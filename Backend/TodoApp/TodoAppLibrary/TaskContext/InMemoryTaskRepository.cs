using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using TodoAppLibrary.TaskContext.Exceptions;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        public InMemoryTaskRepository()
        {
            _tasks = new List<Task>();
        }

        public IEnumerable<Task> GetAllTasksForUser(Identifier userId)
        {
            return _tasks.Where(t => t.Members.Any(m => m.MemberId.Id == userId.Id));
        }

        public Task GetTaskById(Identifier taskId)
        {
            var currentTask = _tasks.FirstOrDefault(t => t.Identifier.Id == taskId.Id);
            Ensure.Any.IsNotNull(currentTask, nameof(taskId),
                opt => opt.WithException(new TaskNotFoundException(taskId)));

            return currentTask;
        }

        public Identifier AddTask(Task task)
        {
            Ensure.Any.IsNotNull(task);

            var newTaskId = new Identifier(IntIterator.GetNextInt());
            task.Identifier = newTaskId;
            _tasks.Add(task);

            return newTaskId;
        }

        private readonly List<Task> _tasks;
    }
}
