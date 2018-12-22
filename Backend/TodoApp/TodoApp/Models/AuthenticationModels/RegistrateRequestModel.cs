using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.AuthenticationModels
{
    public class RegistrateRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
