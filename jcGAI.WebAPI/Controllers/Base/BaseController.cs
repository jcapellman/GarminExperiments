using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected Guid UserId;

        protected readonly ILogger<BaseController> Logger;

        protected BaseController(ILogger<BaseController> logger)
        {
            Logger = logger;
        }
    }
}