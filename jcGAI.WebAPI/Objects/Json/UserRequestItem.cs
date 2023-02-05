using jcGAI.WebAPI.Attributes;

namespace jcGAI.WebAPI.Objects.Json
{
    public class UserRequestItem
    {
        [RequiredProperty]
        public string Username { get; set; }

        [RequiredProperty]
        public string Password { get; set; }

        public UserRequestItem()
        {
            Username = string.Empty;

            Password = string.Empty;
        }
    }
}