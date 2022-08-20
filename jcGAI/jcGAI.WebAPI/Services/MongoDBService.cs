using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Objects.NonRelational;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace jcGAI.WebAPI.Services
{
    public class MongoDBService
    {
        private readonly MongoDBConfig _config;
        private readonly IMongoDatabase _mongoDBClient;

        public MongoDBService(IOptions<MongoDBConfig> configuration)
        {
            _config = configuration.Value;
            _mongoDBClient = new MongoClient(_config.ConnectionString).GetDatabase(_config.DatabaseName);
        }

        private IMongoCollection<T> GetCollection<T>(string? collectionName = null)
        {
            var collection = collectionName == null ? _config.CollectionName : collectionName;

            if (!_mongoDBClient.ListCollectionNames().ToEnumerable().Any(c => c == collection))
            {
                _mongoDBClient.CreateCollection(collection);
            }

            return _mongoDBClient.GetCollection<T>(collection);
        }

        public async void InsertActivityAsyncs(byte[] file)
        {
            await _mongoDBClient.GetCollection<Activities>(nameof(Activities)).InsertOneAsync(new Activities
            {
                GPXFileData = file,
                TimeStamp = DateTime.Now
            });
        }
    }
}