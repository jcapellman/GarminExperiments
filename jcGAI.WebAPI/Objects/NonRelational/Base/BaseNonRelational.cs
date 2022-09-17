using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace jcGAI.WebAPI.Objects.NonRelational.Base
{
    public class BaseNonRelational
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
