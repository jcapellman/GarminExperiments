using MongoDB.Bson.Serialization.Attributes;

namespace jcGAI.WebAPI.Objects.NonRelational.Base
{
    public class BaseNonRelational
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public Guid UserId { get; set; }
    }
}