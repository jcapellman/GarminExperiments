using jcGAI.WebAPI.Attributes;

namespace jcGAI.WebAPI.Objects.Json
{
    public class InsightResponseItem
    {
        [RequiredProperty]
        public Guid Id { get; set; }

        [RequiredProperty]
        public string InsightType { get; set; }

        [RequiredProperty]
        public string InsightJson { get; set; }

        public InsightResponseItem()
        {
            InsightType = string.Empty;

            InsightJson = string.Empty;
        }
    }
}