using TodoAppLibrary.TaskContext;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.TasksModels
{
    public class GetAllUsersTasksMemberResponseModel
    {
        public Identifier MemberId { get; }
        public MemberRole MemberRole { get; }
        public string MemberUserName { get; }

        public GetAllUsersTasksMemberResponseModel(
            Identifier memberId,
            MemberRole memberRole,
            string memberUserName
            )
        {
            MemberId = memberId;
            MemberRole = memberRole;
            MemberUserName = memberUserName;
        }
    }
}
