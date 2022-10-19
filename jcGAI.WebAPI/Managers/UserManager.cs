using jcGAI.WebAPI.Common;
using jcGAI.WebAPI.Managers.Base;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Managers
{
    public class UserManager : BaseManager
    {
        public UserManager(MongoDbService mongo) : base(mongo)
        {
        }

        public (bool Success, string ErrorString) Login(string username, string password)
        {
            var user = Mongo.GetOne<Users>(a => a.Username == username && a.Password == password.ToSHA256());

            return (user != null, string.Empty);
        }

        public async Task<(bool Success, string ErrorString)> CreateUserAsync(string username, string password)
        {
            var existingUser = Mongo.GetOne<Users>(a => a.Username == username);

            if (existingUser != null)
            {
                return (false, $"Existing username ({username}) was found");
            }

            var result = await Mongo.InsertUserAsync(new Users
            {
                Username = username,
                Password = password.ToSHA256()
            });

            return (result != Guid.Empty, string.Empty);
        }
    }
}