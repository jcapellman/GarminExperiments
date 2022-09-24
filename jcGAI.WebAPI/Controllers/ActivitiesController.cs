using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/activities")]
    public class ActivitiesController : BaseController
    {
        protected ActivitiesController(ILogger<BaseController> logger, MongoDbService mongo) : base(logger, mongo)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Activities>>> GetAsync(DateTime? startTime = null, DateTime? endTime = null) 
            => await Mongo.GetActivitiesAsync(UserId);
    }
}