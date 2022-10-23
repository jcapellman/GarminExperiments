namespace jcGAI.WebAPI.Objects.Config
{
    public class JWTConfig
    {
        public string Secret { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public string Subject { get; set; }

        public JWTConfig()
        {
            Subject = string.Empty;

            Issuer = string.Empty;

            Audience = string.Empty;

            Secret = string.Empty;
        }
    }
}