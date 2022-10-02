﻿using Microsoft.AspNetCore.Mvc;

using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Objects.Json;
using jcGAI.WebAPI.Services;

using jcGAI.WebAPI.Managers;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : BaseController
    {
        private readonly UserManager _userManager;

        public AccountController(ILogger<AccountController> logger, MongoDbService mongo) : base(logger)
        {
            _userManager = new UserManager(mongo);
        }

        [HttpGet]
        public ActionResult<string> Login(string username, string password)
        {
            var (Success, _) = _userManager.Login(username, password);

            if (!Success)
            {
                return BadRequest("Invalid username or password");
            }

            return string.Empty;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(UserRequestItem userRequestItem)
        {
            var (Success, ErrorString) = await _userManager.CreateUserAsync(userRequestItem.Username, userRequestItem.Password);

            if (Success)
            {
                return true;
            }

            return BadRequest(ErrorString);
        }
    }
}