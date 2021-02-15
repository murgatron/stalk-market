using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Island;
using Repositories.Interfaces.IIslandRepository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/islands")]
    public class IslandController : ControllerBase
    {
        private readonly ILogger<IslandController> _logger;
        private readonly IIslandRepository _repository;

        public IslandController(ILogger<IslandController> logger, IIslandRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Island> Get()
        {
            _logger.LogInformation("Getting Island Information");
            var islandList = _repository.GetIslands();
            return islandList;
        }
    }
}
