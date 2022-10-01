using Microsoft.AspNetCore.Mvc;

using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public Guid UserId;

        protected readonly ILogger<BaseController> Logger;

        protected readonly MongoDbService Mongo;
        
        protected BaseController(ILogger<BaseController> logger, MongoDbService mongo)
        {
            Logger = logger;
            Mongo = mongo;
        }
    }
}