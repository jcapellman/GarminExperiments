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
        public async Task<ActionResult<Guid>> CreateUser(UserRequestItem userRequestItem) =>
            await Mongo.InsertUserAsync(new Users
            {
                Username = userRequestItem.Username,
                Password = userRequestItem.Password
            });
    }
}