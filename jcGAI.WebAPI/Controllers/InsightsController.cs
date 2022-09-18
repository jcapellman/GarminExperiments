using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/insights")]
    public class InsightsController : BaseController
    {
        public InsightsController(ILogger<InsightsController> logger, MongoDBService mongo) : base(logger, mongo)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<InsightResponseItem>> GetInsightsAsync(DateTime? startTime = null, DateTime? endTime = null)
        {
            var insights = await Mongo.GetActivitiesAsync(UserId);

            return new InsightResponseItem();
        }
    }
}