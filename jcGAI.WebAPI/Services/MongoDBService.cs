using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Objects.NonRelational.Base;

using MongoDB.Driver;

namespace jcGAI.WebAPI.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _mongoDbClient;

        public MongoDbService(MongoDbConfig configuration)
        {
            if (string.IsNullOrEmpty(configuration.DatabaseName))
            {
                throw new ArgumentOutOfRangeException(nameof(configuration));
            }

            if (string.IsNullOrEmpty(configuration.ConnectionString))
            {
                throw new ArgumentOutOfRangeException(nameof(configuration));
            }

            _mongoDbClient = new MongoClient(configuration.ConnectionString).GetDatabase(configuration.DatabaseName);
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

        public T? GetOne<T>(Func<T, bool> expression) => Collections<T>().AsQueryable().FirstOrDefault(expression);
    }
}