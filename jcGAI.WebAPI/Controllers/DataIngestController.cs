using jcGAI.WebAPI.Controllers.Base;
using jcGAI.WebAPI.Managers;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jcGAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/dataingest")]
    public class DataIngestController : BaseController
    {
        private readonly DataIngestManager _manager;

        public DataIngestController(ILogger<DataIngestController> logger, MongoDbService mongo) : base(logger)
        {
            _manager = new DataIngestManager(mongo);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UploadAsync(List<IFormFile> files)
        {
            try
            {
                foreach (var file in files)
                {
                    var stream = new MemoryStream((int)file.Length);
                    await file.CopyToAsync(stream);

                    var result = await _manager.InsertDataAsync(stream.ToArray(), UserId);

                    if (!result)
                    {
                        Logger.LogDebug("Failed to insert {file}", file);
                    }
                }

                return Ok();
            } catch (Exception ex)
            {
                Logger.LogError("Failure to upload {ex}", ex);

                return BadRequest("Failed to upload");
            }
        }
    }
}