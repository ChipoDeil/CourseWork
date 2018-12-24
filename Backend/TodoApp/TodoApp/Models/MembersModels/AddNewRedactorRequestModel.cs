using System.ComponentModel.DataAnnotations;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.MembersModels
{
    public class AddNewRedactorRequestModel
    {
        [Required] public Identifier RedactorId { get; set; }
    }
}