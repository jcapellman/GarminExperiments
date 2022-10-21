using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Objects.NonRelational.Base;

using MongoDB.Driver;
using System.Linq.Expressions;

namespace jcGAI.WebAPI.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _mongoDbClient;

        public MongoDbService(MongoDbConfig configuration)
        {
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

        public async Task<List<T>> GetManyAsync<T>(Expression<Func<T, bool>> expression) where T : BaseNonRelational =>
            await (await Collections<T>().FindAsync(expression)).ToListAsync();

        public async Task<Guid> InsertUserAsync(Users users)
        {
            await Collections<Users>().InsertOneAsync(users);

            return users.Id;
        }

        public async Task<T> GetOneAsync<T>(Expression<Func<T, bool>> expression)
        {
            return await(await Collections<T>().FindAsync(expression)).FirstOrDefaultAsync();
        }
    }
}