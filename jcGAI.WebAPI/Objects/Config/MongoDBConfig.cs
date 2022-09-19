namespace jcGAI.WebAPI.Objects.Config
{
    public class MongoDBConfig
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }

        public MongoDBConfig()
        {
            ConnectionString = string.Empty;

            DatabaseName = string.Empty;

            CollectionName = string.Empty;
        }
    }
}