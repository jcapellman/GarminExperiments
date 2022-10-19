using jcGAI.WebAPI.Managers.Base;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers.Base
{
    public class BaseController<T> : ControllerBase where T : BaseManager
    {
        protected Guid UserId;

        protected readonly ILogger<BaseController<T>> Logger;

        protected readonly T _manager;

        protected BaseController(ILogger<BaseController<T>> logger, MongoDbService mongo)
        {
            Logger = logger;

            _manager = Activator.CreateInstance(typeof(T), mongo) as T ?? throw new NullReferenceException(nameof(_manager));
        }
    }
}