using jcGAI.WebAPI.Managers.Base;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Managers
{
    public class DataIngestManager : BaseManager
    {
        public DataIngestManager(MongoDbService mongo) : base(mongo)
        {
        }

        public async Task<bool> InsertDataAsync(byte[] gpxFileData, Guid userId)
        {
            var result = await Mongo.InsertAsync(new Activities
            {
                GpxFileData = gpxFileData,
                UserId = userId,
                TimeStamp = DateTime.Now
            });

            return result != Guid.Empty;
        }
    }
}