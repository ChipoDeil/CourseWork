using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.TasksModels
{
    public class GetAllUsersTasksResponseItemModel
    {
        public IEnumerable<GetAllUsersTasksMemberResponseModel> Members { get; }
        public bool Important { get; }
        public bool Done { get; }
        public string TaskTitle { get; }
        public Identifier TaskId { get; }

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
    }
}
