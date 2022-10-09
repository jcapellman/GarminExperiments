using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Objects.Config;

namespace jcGAI.UnitTests.Managers
{
    [TestClass]
    public class InsightsManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsightsManager_DefaultConstructor()
        {
            _ = new InsightsManager(new WebAPI.Services.MongoDbService(new MongoDbConfig()));
        }
    }
}
