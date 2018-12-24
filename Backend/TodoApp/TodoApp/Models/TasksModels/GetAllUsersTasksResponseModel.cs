using System.Collections.Generic;

namespace TodoApp.Models.TasksModels
{
    public class GetAllUsersTasksResponseModel
    {
        public IEnumerable<GetAllUsersTasksResponseItemModel> Tasks { get; }

        public GetAllUsersTasksResponseModel(
            IEnumerable<GetAllUsersTasksResponseItemModel> tasks)
        {
            Tasks = tasks;
        }
    }
}
