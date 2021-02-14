using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models.Stalk;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/stalks")]
    public class StalkController : ControllerBase
    {
        private readonly ILogger<StalkController> _logger;

        public StalkController(ILogger<StalkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Stalk>> Get()
        {
            _logger.LogInformation("STALKS");
            var stalkList = new List<Stalk> {
                new Stalk
                {
                    Id = new Guid(),
                    IslandId = new Guid(),
                    Meridian = Meridian.AM,
                    BellPrice = 120,
                    Date = new DateTime(),
                    EnteredBy = new Guid()
                }
            };
            return Ok(stalkList);
        }
    }
}
