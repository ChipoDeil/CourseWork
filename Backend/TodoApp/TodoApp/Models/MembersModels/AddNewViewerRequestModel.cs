using System.ComponentModel.DataAnnotations;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.MembersModels
{
    public class AddNewViewerRequestModel
    {
        [Required]
        public Identifier AddingUserId { get; set; }
    }
}
