using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/dataingest")]
    public class DataIngestController : BaseController
    {
        public DataIngestController(ILogger<DataIngestController> logger, MongoDBService mongo) : base(logger, mongo)
        {
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(List<IFormFile> files)
        {
            try
            {
                foreach (var file in files)
                {
                    var stream = new MemoryStream((int)file.Length);
                    file.CopyTo(stream);

                    Mongo.InsertActivityAsync(UserId, stream.ToArray());
                }

                return Ok();
            } catch (Exception ex)
            {
                Logger.LogError($"Failure to upload {ex}");

                return BadRequest("Failed to upload");
            }
        }
    }
}