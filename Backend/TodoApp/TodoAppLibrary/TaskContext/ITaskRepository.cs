using System.Collections.Generic;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTasksForUser(Identifier userId);
        Task GetTaskById(Identifier taskId);
        Identifier AddTask(Task task);
    }
}