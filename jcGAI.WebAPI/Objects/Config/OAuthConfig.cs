namespace jcGAI.WebAPI.Objects.Config
{
    public class OAuthConfig
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public OAuthConfig()
        {
            ClientId = string.Empty;

            Secret = string.Empty;
        }
    }
}