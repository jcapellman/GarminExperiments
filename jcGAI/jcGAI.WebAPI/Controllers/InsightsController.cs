using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/insights")]
    public class InsightsController : ControllerBase
    {
        private readonly ILogger<InsightsController> _logger;

        private readonly MongoDBService _mongo;

        public InsightsController(ILogger<InsightsController> logger, MongoDBService mongo)
        {
            _logger = logger;
            _mongo = mongo;
        }
    }
}
