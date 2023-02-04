using jcGAI.WebAPI.Attributes;

namespace jcGAI.WebAPI.Objects.Json
{
    public class UserRequestItem
    {
        [RequiredPropertyAttribute]
        public string Username { get; set; }

        [RequiredPropertyAttribute]
        public string Password { get; set; }

        public UserRequestItem()
        {
            Username = string.Empty;

            Password = string.Empty;
        }
    }
}