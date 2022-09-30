namespace jcGAI.WebAPI.Objects.NonRelational
{
    public class Users
    {
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}