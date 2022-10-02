using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/activities")]
    public class ActivitiesController : BaseController
    {
        private readonly InsightsManager _manager;

        protected ActivitiesController(ILogger<ActivitiesController> logger, MongoDbService mongo) : base(logger)
        {
            _manager = new InsightsManager(mongo);
        }

        [HttpGet]
        public IEnumerable<Activities> Get(DateTime? startTime = null, DateTime? endTime = null) 
            => _manager.GetActivities(UserId, startTime, endTime);
    }
}