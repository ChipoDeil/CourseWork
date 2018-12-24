using System.Collections.Generic;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext.Views
{
    public class TaskView
    {
        public TaskView(
            IEnumerable<MemberView> members,
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

        public IEnumerable<MemberView> Members { get; }
        public bool Important { get; }
        public bool Done { get; }
        public string TaskTitle { get; }
        public Identifier TaskId { get; }
    }
}