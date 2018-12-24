using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public class TaskMember
    {
        public TaskMember(Identifier memberId, MemberRole role)
        {
            MemberId = memberId;
            Role = role;
        }

        public Identifier MemberId { get; internal set; }
        public MemberRole Role { get; internal set; }
    }
}