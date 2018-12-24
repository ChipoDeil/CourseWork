using System.ComponentModel.DataAnnotations;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.MembersModels
{
    public class DeleteTaskMemberRequestModel
    {
        [Required]
        public Identifier DeletingUserId { get; set; }
    }
}
