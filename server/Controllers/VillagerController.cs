using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.CreateVillager;
using Models.Villager;
using Repositories.Interfaces;

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
                return Ok(_repository.GetVillagers());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured trying to get villagers");
                // this is stupid
                return Problem(e.Message, null, int.Parse(System.Net.HttpStatusCode.InternalServerError.ToString()));
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Villager>> Create([FromBody] CreateVillager villagerToCreate)
        {
            try
            {
                return Ok(_repository.CreateVillager(villagerToCreate));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured trying to create villager");
                return Problem(e.Message);
            }
        }

        [HttpPatch("{villagerId}")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Villager>> Update(
            [FromRoute] Guid villagerId,
            [FromBody] CreateVillager updatePayload)
        {
            try
            {
                return Ok(_repository.UpdateVillager(villagerId, updatePayload));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured trying to update villager");
                return Problem(e.Message);
            }
        }

        [HttpDelete("{villagerId}")]
        [Produces("application/json")]
        public ActionResult Delete([FromRoute] Guid villagerId)
        {
            try
            {
                _repository.DeleteVillager(villagerId);
                return Ok(); // 204 pls
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured trying to delete villager");
                return Problem(e.Message);
            }
        }
    }
}