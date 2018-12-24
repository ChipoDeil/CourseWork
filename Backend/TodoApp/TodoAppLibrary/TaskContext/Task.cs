using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using TodoAppLibrary.TaskContext.Exceptions;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.TaskContext
{
    public class Task
    {
        internal Task(Identifier identifier, bool done, bool important,
            string taskTitle, List<TaskMember> members)
        {
            Identifier = identifier;
            Done = done;
            Important = important;
            TaskTitle = Ensure.String.IsNotEmptyOrWhitespace(taskTitle);
            Members = Ensure.Any.IsNotNull(members);
        }

        public Task(string taskTitle, Identifier creatorId, bool important)
        {
            Done = false;
            Important = important;
            Identifier = new Identifier();
            TaskTitle = Ensure.String.IsNotNullOrWhiteSpace(taskTitle);
            Members = new List<TaskMember>
            {
                new TaskMember(creatorId, MemberRole.Creator)
            };
        }

        internal Identifier Identifier { get; set; }
        internal bool Done { get; set; }
        internal bool Important { get; set; }
        internal string TaskTitle { get; set; }
        internal List<TaskMember> Members { get; }

        internal void MakeDone(Identifier memberId)
        {
            Ensure.Any.IsNotNull(memberId);

            var currentMember = Members.FirstOrDefault(m => m.MemberId.Id == memberId.Id);

            Ensure.Any.IsNotNull(currentMember, nameof(currentMember),
                opt => opt.WithException(new MemberNotFoundException(memberId)));
            Ensure.Bool.IsTrue(currentMember.Role == MemberRole.Creator ||
                               currentMember.Role == MemberRole.Redactor,
                nameof(memberId),
                opt => opt.WithException(new MemberHasNoPermissionsException(memberId)));

            Done = true;
        }

        internal void SwitchImportant(Identifier memberId)
        {
            Ensure.Any.IsNotNull(memberId);

            var currentMember = Members.FirstOrDefault(m => m.MemberId.Id == memberId.Id);

            Ensure.Any.IsNotNull(currentMember, nameof(currentMember),
                opt => opt.WithException(new MemberNotFoundException(memberId)));
            Ensure.Bool.IsTrue(currentMember.Role == MemberRole.Creator ||
                               currentMember.Role == MemberRole.Redactor,
                nameof(memberId),
                opt => opt.WithException(new MemberHasNoPermissionsException(memberId)));

            Important = !Important;
        }

        internal void AddViewer(Identifier inviterId, Identifier invitedId)
        {
            Ensure.Any.IsNotNull(inviterId);
            Ensure.Any.IsNotNull(invitedId);

            var currentMember = Members.FirstOrDefault(m => m.MemberId.Id == inviterId.Id);

            Ensure.Any.IsNotNull(currentMember, nameof(currentMember),
                opt => opt.WithException(new MemberNotFoundException(inviterId)));
            Ensure.Bool.IsTrue(Members.FirstOrDefault(m => m.MemberId.Id == invitedId.Id) == default(TaskMember),
                nameof(invitedId), opt => opt.WithException(new AlreadyMemberException(invitedId)));
            Ensure.Bool.IsTrue(
                currentMember.Role == MemberRole.Creator ||
                currentMember.Role == MemberRole.Redactor,
                nameof(inviterId),
                opt => opt.WithException(new MemberHasNoPermissionsException(inviterId)));

            Members.Add(new TaskMember(invitedId, MemberRole.Viewer));
        }

        internal void AddRedactor(Identifier inviterId, Identifier invitedId)
        {
            Ensure.Any.IsNotNull(inviterId);
            Ensure.Any.IsNotNull(invitedId);

            var currentMember = Members.FirstOrDefault(m => m.MemberId.Id == inviterId.Id);

            Ensure.Any.IsNotNull(currentMember, nameof(currentMember),
                opt => opt.WithException(new MemberNotFoundException(inviterId)));
            Ensure.Bool.IsTrue(Members.FirstOrDefault(m => m.MemberId.Id == invitedId.Id) == default(TaskMember),
                nameof(invitedId), opt => opt.WithException(new AlreadyMemberException(invitedId)));
            Ensure.Bool.IsTrue(currentMember.Role == MemberRole.Creator, nameof(inviterId),
                opt => opt.WithException(new MemberHasNoPermissionsException(inviterId)));

            Members.Add(new TaskMember(invitedId, MemberRole.Redactor));
        }

        internal void DeleteMember(Identifier initiator, Identifier deleting)
        {
            Ensure.Any.IsNotNull(initiator);
            Ensure.Any.IsNotNull(deleting);

            var initiatorMember = Members.FirstOrDefault(m => m.MemberId.Id == initiator.Id);
            var deletingMember = Members.FirstOrDefault(m => m.MemberId.Id == deleting.Id);

            Ensure.Any.IsNotNull(initiatorMember, nameof(initiatorMember),
                opt => opt.WithException(new MemberNotFoundException(initiator)));
            Ensure.Any.IsNotNull(deletingMember, nameof(deletingMember),
                opt => opt.WithException(new MemberNotFoundException(deleting)));
            Ensure.Bool.IsTrue(initiator.Id == deleting.Id ||
                               initiatorMember.Role == MemberRole.Creator,
                nameof(initiatorMember),
                opt => opt.WithException(new MemberHasNoPermissionsException(initiator)));

            Members.RemoveAll(m => m.MemberId.Id == deleting.Id);
        }
    }
}