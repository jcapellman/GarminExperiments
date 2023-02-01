using jcGAI.WebAPI.Common;
using jcGAI.WebAPI.Managers.Base;
using jcGAI.WebAPI.Objects.Common;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Managers
{
    public class UserManager : BaseManager
    {
        public UserManager(MongoDbService mongo) : base(mongo)
        {
        }

        public async Task<ReturnSet<Guid?>> LoginAsync(string username, string password)
        {
            var user = await Mongo.GetOneAsync<Users>(a => a.Username == username && a.Password == password.ToSHA256());

            return new ReturnSet<Guid?>(user?.Id);
        }

        public async Task<ReturnSet<bool>> CreateUserAsync(string username, string password)
        {
            var existingUser = await Mongo.GetOneAsync<Users>(a => a.Username == username);

            if (existingUser is not null)
            {
                return new ReturnSet<bool>(false, $"Existing username ({username}) was found");
            }

            var result = await Mongo.InsertUserAsync(new Users
            {
                Username = username,
                Password = password.ToSHA256()
            });

            return new ReturnSet<bool>(result != Guid.Empty);
        }
    }
}