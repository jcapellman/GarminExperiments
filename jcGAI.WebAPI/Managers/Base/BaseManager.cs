using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Managers.Base
{
    public class BaseManager
    {
        protected readonly MongoDbService Mongo;

        protected BaseManager(MongoDbService mongo)
        {
            Mongo = mongo;
        }
    }
}