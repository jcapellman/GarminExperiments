﻿using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public int UserId => Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

        protected readonly ILogger<BaseController> Logger;

        protected readonly MongoDBService Mongo;
        
        protected BaseController(ILogger<BaseController> logger, MongoDBService mongo)
        {
            Logger = logger;
            Mongo = mongo;
        }
    }
}