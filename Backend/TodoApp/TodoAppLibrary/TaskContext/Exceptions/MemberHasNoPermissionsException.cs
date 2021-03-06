﻿using System;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext.Exceptions
{
    public class MemberHasNoPermissionsException : Exception
    {
        public MemberHasNoPermissionsException(Identifier memberId) : base(
            $"Member with id {memberId.Id} has no permission to do that")
        {
        }
    }
}