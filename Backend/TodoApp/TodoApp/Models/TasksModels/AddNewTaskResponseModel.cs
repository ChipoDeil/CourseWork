using TodoAppLibrary.Tools;

namespace TodoApp.Models.TasksModels
{
    public class AddNewTaskResponseModel
    {
        public Identifier TaskId { get; }

        public AddNewTaskResponseModel(Identifier taskId)
        {
            TaskId = taskId;
        }
    }
}
