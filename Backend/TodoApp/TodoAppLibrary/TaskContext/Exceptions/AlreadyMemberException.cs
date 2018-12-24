using System;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext.Exceptions
{
    public class AlreadyMemberException : Exception
    {
        public AlreadyMemberException(Identifier memberId) : base($"User with id {memberId} is already member")
        {
        }
    }
}