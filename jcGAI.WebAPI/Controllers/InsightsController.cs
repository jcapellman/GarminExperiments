using System.Globalization;
using jcGAI.WebAPI.Attributes;
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
    [ServiceFilter(typeof(ValidateModelFilterAttribute))]
    public class InsightsController : BaseController<InsightsManager>
    {
        public InsightsController(ILogger<InsightsController> logger, MongoDbService mongo) : base(logger, mongo)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<InsightResponseItem>>> GetInsightsAsync(DateTime? startTime = null, DateTime? endTime = null)
        {
            var insights = await _manager.GetActivitiesAsync(UserId, startTime, endTime);

            return insights.Select(a => new InsightResponseItem {
                InsightJson = a.UserId.ToString(), 
                InsightType = a.TimeStamp.ToString(CultureInfo.InvariantCulture) 
            }).ToList();
        }
    }
}