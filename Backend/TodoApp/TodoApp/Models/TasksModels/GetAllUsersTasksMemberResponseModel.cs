using TodoAppLibrary.TaskContext;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.TasksModels
{
    public class GetAllUsersTasksMemberResponseModel
    {
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

        public Identifier MemberId { get; }
        public MemberRole MemberRole { get; }
        public string MemberUserName { get; }
    }
}