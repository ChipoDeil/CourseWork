using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoAppLibrary.Tools;

namespace TodoApp.Models.SearchingModels
{
    public class GetUsersByNameItemResponseModel
    {
        [Required]
        public string UserName { get; }
        [Required]
        public string Email { get; }
        [Required]
        public Identifier Identifier { get; }

        public GetUsersByNameItemResponseModel(
            string userName,
            string email,
            Identifier identifier)
        {
            UserName = userName;
            Email = email;
            Identifier = identifier;
        }
    }
}
