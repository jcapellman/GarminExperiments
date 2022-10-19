using jcGAI.WebAPI.Managers.Base;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Managers
{
    public class InsightsManager : BaseManager
    {
        public InsightsManager(MongoDbService mongo) : base(mongo)
        {
        }

        public IEnumerable<Activities> GetActivities(Guid userId, DateTime? startTime = null, DateTime? endTime = null) => 
            Mongo.GetMany<Activities>(a => a.UserId == userId &&
            (!startTime.HasValue || a.TimeStamp >= startTime.Value) &&
            (!endTime.HasValue || a.TimeStamp <= endTime.Value));
    }
}