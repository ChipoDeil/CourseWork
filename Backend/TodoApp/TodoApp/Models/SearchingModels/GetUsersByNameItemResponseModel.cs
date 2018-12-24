using System.ComponentModel.DataAnnotations;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.SearchingModels
{
    public class GetUsersByNameItemResponseModel
    {
        public GetUsersByNameItemResponseModel(
            string userName,
            string email,
            Identifier identifier)
        {
            UserName = userName;
            Email = email;
            Identifier = identifier;
        }

        [Required] public string UserName { get; }

        [Required] public string Email { get; }

        [Required] public Identifier Identifier { get; }
    }
}