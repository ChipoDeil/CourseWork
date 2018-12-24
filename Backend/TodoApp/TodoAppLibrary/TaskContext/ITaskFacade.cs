using System.Collections.Generic;
using TodoAppLibrary.TaskContext.Views;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public interface ITaskFacade
    {
        IEnumerable<TaskView> GetTasksForUser(Identifier userId);
        void AddTaskViewer(Identifier taskId, Identifier userId, Identifier addingUserId);
        void AddTaskRedactor(Identifier taskId, Identifier userId, Identifier addingUserId);
        void DeleteTaskMember(Identifier taskId, Identifier userId, Identifier deletingUserId);
        void MakeTaskDone(Identifier taskId, Identifier userId);
        void SwitchTaskImportant(Identifier taskId, Identifier userId);
        Identifier AddTask(Identifier userId, string taskTitle, bool important);
    }
}