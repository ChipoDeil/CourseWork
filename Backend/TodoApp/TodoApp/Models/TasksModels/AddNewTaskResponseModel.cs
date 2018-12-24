using TodoAppLibrary.Tools;

namespace TodoApp.Models.TasksModels
{
    public class AddNewTaskResponseModel
    {
        public AddNewTaskResponseModel(Identifier taskId)
        {
            TaskId = taskId;
        }

        public Identifier TaskId { get; }
    }
}