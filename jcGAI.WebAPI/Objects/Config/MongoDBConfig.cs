namespace jcGAI.WebAPI.Objects.Config
{
    public class MongoDbConfig
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public MongoDbConfig()
        {
            ConnectionString = string.Empty;

            DatabaseName = string.Empty;
        }
    }
}