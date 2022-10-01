using System.Globalization;
using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/insights")]
    public class InsightsController : BaseController
    {
        public InsightsController(ILogger<InsightsController> logger, MongoDbService mongo) : base(logger, mongo)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<InsightResponseItem>>> GetInsightsAsync(DateTime? startTime = null, DateTime? endTime = null)
        {
            var insights = await Mongo.GetManyAsync<Activities>(a => a.UserId == UserId);

            return insights.Select(a => new InsightResponseItem {
                Id = a.Id,
                InsightJson = a.UserId.ToString(), 
                InsightType = a.TimeStamp.ToString(CultureInfo.InvariantCulture) 
            }).ToList();
        }
    }
}