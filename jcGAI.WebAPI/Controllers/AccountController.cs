using Microsoft.AspNetCore.Mvc;

using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Services;

using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Common;
using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Attributes;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    [ServiceFilter(typeof(ValidateModelFilterAttribute))]
    public class AccountController : BaseController<UserManager>
    {
        private readonly JWTConfig _jwtConfig;

        public AccountController(ILogger<AccountController> logger, MongoDbService mongo, JWTConfig jwtConfig) : base(logger, mongo)
        {
            _jwtConfig = jwtConfig;
        }

        [HttpGet]        
        public async Task<ActionResult<string>> LoginAsync(string username, string password)
        {
            var result = await _manager.LoginAsync(username, password);

            if (result.Value is null)
            {
                return BadRequest("Invalid username or password");
            }

            return JWTIO.GenerateToken(result.Value.Value, _jwtConfig);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUserAsync(UserRequestItem userRequestItem)
        {
            var result = await _manager.CreateUserAsync(userRequestItem.Username, userRequestItem.Password);

            if (result.Value)
            {
                return true;
            }

            return BadRequest(result.AdditionalErrorInformation);
        }
    }
}