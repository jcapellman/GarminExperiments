using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Objects.Config;

namespace jcGAI.UnitTests.Managers
{
    [TestClass]
    internal class UserManagerTest
    {
        [TestMethod]
        public void UserManager_DefaultConstructor()
        {
            var manager = new UserManager(new WebAPI.Services.MongoDbService(new MongoDbConfig()));

        }
    }
}
