namespace jcGAI.WebAPI.Objects.Json
{
    public class UserRequestItem
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public UserRequestItem()
        {
            Username = string.Empty;

            Password = string.Empty;
        }
    }
}