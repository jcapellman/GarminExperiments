using Microsoft.AspNetCore.Mvc;

using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Objects.NonRelational;
using jcGAI.WebAPI.Services;

using MongoDB.Bson;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : BaseController
    {
        public AccountController(ILogger<AccountController> logger, MongoDbService mongo) : base(logger, mongo)
        {
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(UserRequestItem userRequestItem)
        {
            var existingUser = await Mongo.GetOneAsync<Users>(a => a.Username == userRequestItem.Username);

            if (existingUser != null)
            {
                return BadRequest($"Existing username ({userRequestItem.Username}) was found");
            }

            var result = await Mongo.InsertUserAsync(new Users
            {
                Username = userRequestItem.Username,
                Password = userRequestItem.Password
            });

            return result != Guid.Empty;
        }
    }
}