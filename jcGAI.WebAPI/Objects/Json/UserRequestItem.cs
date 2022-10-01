using System.ComponentModel.DataAnnotations;

namespace jcGAI.WebAPI.Objects.Json
{
    public class UserRequestItem
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRequestItem()
        {
            Username = string.Empty;

            Password = string.Empty;
        }
    }
}