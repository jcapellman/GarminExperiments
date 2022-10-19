using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Objects.Config;

namespace jcGAI.UnitTests.Managers
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UserManager_DefaultConstructor()
        {
            _ = new UserManager(new WebAPI.Services.MongoDbService(new MongoDbConfig()));
        }
    }
}