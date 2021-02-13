using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models.Island;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/islands")]
    public class IslandController : ControllerBase
    {
        private readonly ILogger<IslandController> _logger;

        public IslandController(ILogger<IslandController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Island> Get()
        {
            _logger.LogInformation("Getting Island Information");

            var islandList = new List<Island>();
            islandList.Add(new Island
            {
                id = new Guid(),
                name = "Teatime",
                owner = new Guid()
            });
            return islandList;
        }
    }
}
