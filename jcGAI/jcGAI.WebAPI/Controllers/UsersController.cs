using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly MongoDBService _mongo;

        public UsersController(ILogger<UsersController> logger, MongoDBService mongo)
        {
            _logger = logger;
            _mongo = mongo;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUserAsync(string username, string password)
        {
            return Guid.NewGuid(); 
        }
    }
}