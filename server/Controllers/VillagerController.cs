using System;
using System.Collections.Generic;
using Repositories.Interfaces.IVillagerRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.CreateVillager;
using Models.Villager;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/villagers")]
    public class VillagerController : ControllerBase
    {
        private readonly ILogger<VillagerController> _logger;
        private readonly IVillagerRepository _repository;
        public VillagerController(ILogger<VillagerController> logger, IVillagerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]

        public ActionResult<IEnumerable<Villager>> Get()
        {
            try
            {
                _logger.LogInformation("Get villager info");
                return Ok(_repository.GetVillagers());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured trying to get villagers");
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public IEnumerable<Villager> Create([FromBody] CreateVillager villagerToCreate)
        {
            return _repository.CreateVillager(villagerToCreate);
        }

        [HttpPatch]
        [Produces("application/json")]
        public IEnumerable<Villager> Update(
            [FromRoute] Guid villagerId,
            [FromBody] CreateVillager updatePayload)
        {
            return _repository.UpdateVillager(villagerId, updatePayload);
        }
    }
}