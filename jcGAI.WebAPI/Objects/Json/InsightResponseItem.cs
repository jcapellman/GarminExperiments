namespace jcGAI.WebAPI.Objects.Json
{
    public class InsightResponseItem
    {
        public string InsightType { get; set; }

        public string InsightJson { get; set; }

        public InsightResponseItem()
        {
            InsightType = string.Empty;

            InsightJson = string.Empty;
        }
    }
}