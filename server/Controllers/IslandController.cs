using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Island;

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

            var islandList = new List<Island>
            {
                new Island
                {
                    Id = new Guid(),
                    Name = "Teatime",
                    Owner = new Guid()
                }
            };

            _logger.LogInformation(islandList.ToString());
            return islandList;
        }
    }
}
