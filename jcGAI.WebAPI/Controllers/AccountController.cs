using Microsoft.AspNetCore.Mvc;

using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Services;

using jcGAI.WebAPI.Managers;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : BaseController<UserManager>
    {
        public AccountController(ILogger<AccountController> logger, MongoDbService mongo) : base(logger, mongo)
        {
        }

        [HttpGet]
        public async Task<ActionResult<string>> LoginAsync(string username, string password)
        {
            var result = await _manager.LoginAsync(username, password);

            if (!result.Value)
            {
                return BadRequest("Invalid username or password");
            }

            return string.Empty;
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