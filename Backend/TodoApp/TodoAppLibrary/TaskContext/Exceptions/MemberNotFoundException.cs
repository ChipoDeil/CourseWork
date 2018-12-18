using System;
using System.Collections.Generic;
using System.Text;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext.Exceptions
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(Identifier memberId) : base($"Member with id {memberId.Id} not found")
        {

        }
    }
}
