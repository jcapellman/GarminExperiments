using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/dataingest")]
    public class DataIngestController : ControllerBase
    {
        private readonly ILogger<DataIngestController> _logger;

        private readonly MongoDBService _mongo;

        public DataIngestController(ILogger<DataIngestController> logger, MongoDBService mongo)
        {
            _logger = logger;
            _mongo = mongo;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(List<IFormFile> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (file == null)
                    {
                        continue;
                    }

                    var stream = new MemoryStream((int)file.Length);
                    file.CopyTo(stream);

                    _mongo.InsertActivityAsyncs(stream.ToArray());
                }

                return Ok();
            } catch (Exception ex)
            {
                _logger.LogError($"Failure to upload {ex}");

                return BadRequest("Failed to upload");
            }
        }
    }
}