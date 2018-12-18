﻿using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext.Views
{
    public class MemberView
    {
        public Identifier MemberId { get; }
        public MemberRole MemberRole { get; }
        public string MemberUserName { get; }

        public MemberView(Identifier memberId, MemberRole memberRole, string memberUserName)
        {
            MemberId = memberId;
            MemberRole = memberRole;
            MemberUserName = memberUserName;
        }
    }
}
