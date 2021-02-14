using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models.Villager;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/villagers")]
    public class VillagerController : ControllerBase
    {
        private readonly ILogger<VillagerController> _logger;

        public VillagerController(ILogger<VillagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Villager> Get()
        {
            _logger.LogInformation("Get villager info");

            var villagerList = new List<Villager>
            {
                new Villager
                {
                    Id = new Guid(),
                    Name = "Murg"
                }
            };
            return villagerList;
        }
    }
}