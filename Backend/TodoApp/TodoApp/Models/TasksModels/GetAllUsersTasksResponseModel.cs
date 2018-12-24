using System.Collections.Generic;

namespace TodoApp.Models.TasksModels
{
    public class GetAllUsersTasksResponseModel
    {
        public GetAllUsersTasksResponseModel(
            IEnumerable<GetAllUsersTasksResponseItemModel> tasks)
        {
            Tasks = tasks;
        }

        public IEnumerable<GetAllUsersTasksResponseItemModel> Tasks { get; }
    }
}