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

        public async Task<IEnumerable<Activities>> GetActivitiesAsync(Guid userId, DateTime? startTime = null, DateTime? endTime = null) => 
            await Mongo.GetManyAsync<Activities>(a => a.UserId == userId &&
            (!startTime.HasValue || a.TimeStamp >= startTime.Value) &&
            (!endTime.HasValue || a.TimeStamp <= endTime.Value));
    }
}