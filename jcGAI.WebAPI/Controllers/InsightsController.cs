using System.Globalization;
using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/insights")]
    public class InsightsController : BaseController<InsightsManager>
    {
        public InsightsController(ILogger<InsightsController> logger, MongoDbService mongo) : base(logger, mongo)
        {
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<InsightResponseItem>> GetInsights(DateTime? startTime = null, DateTime? endTime = null)
        {
            var insights = _manager.GetActivities(UserId, startTime, endTime);

            return insights.Select(a => new InsightResponseItem {
                InsightJson = a.UserId.ToString(), 
                InsightType = a.TimeStamp.ToString(CultureInfo.InvariantCulture) 
            }).ToList();
        }
    }
}