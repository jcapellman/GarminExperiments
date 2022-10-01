using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Objects.NonRelational.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace jcGAI.WebAPI.Services
{
    public class MongoDbService
    {
        private readonly MongoDbConfig _config;
        private readonly IMongoDatabase _mongoDbClient;

        public MongoDbService(IOptions<MongoDbConfig> configuration)
        {
            _config = configuration.Value;
            _mongoDbClient = new MongoClient(_config.ConnectionString).GetDatabase(_config.DatabaseName);
        }

        private IMongoCollection<T> Collections<T>()
        {
                var collection = nameof(T);

                if (_mongoDbClient.ListCollectionNames().ToEnumerable().All(c => c != collection))
                {
                    _mongoDbClient.CreateCollection(collection);
                }

                return _mongoDbClient.GetCollection<T>(collection);
        }

        public async Task<Guid> InsertAsync<T>(T obj) where T : BaseNonRelational
        {
            await Collections<T>().InsertOneAsync(obj);

            return obj.Id;
        }

        public async Task<List<T>> GetManyAsync<T>(Guid userId) where T : BaseNonRelational =>
            await (await Collections<T>().FindAsync(a => a.UserId == userId)).ToListAsync();

        public async Task<Guid> InsertUserAsync(Users users)
        {
            await Collections<Users>().InsertOneAsync(users);

            return users.Id;
        }
    }
}