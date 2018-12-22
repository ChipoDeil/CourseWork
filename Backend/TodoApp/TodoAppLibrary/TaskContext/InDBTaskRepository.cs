using System;
using System.Collections.Generic;
using System.Text;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public class InDBTaskRepository : ITaskRepository
    {
        public IEnumerable<Task> GetAllTasksForUser(Identifier userId)
        {
            throw new NotImplementedException();
        }

        public Task GetTaskById(Identifier taskId)
        {
            throw new NotImplementedException();
        }

        public Identifier AddTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
