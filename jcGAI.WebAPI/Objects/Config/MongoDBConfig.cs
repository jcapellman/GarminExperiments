﻿namespace jcGAI.WebAPI.Objects.Config
{
    public class MongoDBConfig
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}