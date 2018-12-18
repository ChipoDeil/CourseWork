using System;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(Identifier taskId) : base($"task with id {taskId.Id} not found")
        {

        }
    }
}
