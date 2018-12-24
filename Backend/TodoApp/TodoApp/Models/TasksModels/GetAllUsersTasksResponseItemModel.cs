using System.Collections.Generic;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.TasksModels
{
    public class GetAllUsersTasksResponseItemModel
    {
        public GetAllUsersTasksResponseItemModel(
            IEnumerable<GetAllUsersTasksMemberResponseModel> members,
            bool important,
            bool done,
            string taskTitle,
            Identifier taskId)
        {
            Members = members;
            Important = important;
            Done = done;
            TaskTitle = taskTitle;
            TaskId = taskId;
        }

        public IEnumerable<GetAllUsersTasksMemberResponseModel> Members { get; }
        public bool Important { get; }
        public bool Done { get; }
        public string TaskTitle { get; }
        public Identifier TaskId { get; }
    }
}