using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Objects.NonRelational;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using System.Linq;

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
            var collection = collectionName ?? _config.CollectionName;

            if (_mongoDBClient.ListCollectionNames().ToEnumerable().All(c => c != collection))
            {
                _mongoDBClient.CreateCollection(collection);
            }

            return _mongoDBClient.GetCollection<T>(collection);
        }

        public async Task<bool> InsertActivityAsync(int UserId, byte[] file)
        {
            await GetCollection<Activities>(nameof(Activities)).InsertOneAsync(new Activities
            {
                GPXFileData = file,
                TimeStamp = DateTime.Now,
                UserId = UserId
            });

            return true;
        }

        public async Task<List<Activities>> GetActivitiesAsync(int UserId) => 
            await GetCollection<Activities>(nameof(Activities)).FindSync(a => a.UserId == UserId).ToListAsync();
    }
}