using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.TasksModels
{
    public class AddNewTaskRequestModel
    {
        [Required] public bool Important { get; set; }

        [Required] public string TaskTitle { get; set; }
    }
}