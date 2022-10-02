using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Objects.NonRelational.Base;

using Microsoft.Extensions.Options;

using MongoDB.Driver;
using System.Linq.Expressions;

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
            var collection = typeof(T).Name;

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

        public IEnumerable<T> GetMany<T>(Func<T, bool> expression) where T : BaseNonRelational =>
            Collections<T>().AsQueryable().Where(expression);

        public async Task<Guid> InsertUserAsync(Users users)
        {
            await Collections<Users>().InsertOneAsync(users);

            return users.Id;
        }

        public T GetOne<T>(Func<T, bool> expression) =>
            Collections<T>().AsQueryable().FirstOrDefault(expression);
    }
}