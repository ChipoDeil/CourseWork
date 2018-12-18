using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public class TaskMember
    {
        public Identifier MemberId { get; internal set; }
        public MemberRole Role { get; internal set; }

        public TaskMember(Identifier memberId, MemberRole role)
        {
            MemberId = memberId;
            Role = role;
        }
    }
}
