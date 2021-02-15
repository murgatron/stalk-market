using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.CreateIsland;
using Models.Island;
using Repositories.Interfaces;

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
        [Produces("application/json")]
        public ActionResult<IEnumerable<Island>> Get()
        {
            try
            {
                return Ok(_repository.GetIslands());
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to get islands");
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Island>> Create([FromBody] CreateIsland createIsland)
        {
            try
            {
                return Ok(_repository.CreateIsland(createIsland));
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to create island");
                return Problem(e.Message);
            }
        }

        [HttpPatch("{islandId}")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Island>> Update(
            [FromRoute] Guid islandId, 
            [FromBody] CreateIsland updatePayload)
        {
            try
            {
                return Ok(_repository.UpdateIsland(islandId, updatePayload));
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to update island");
                return Problem(e.Message);
            }
        }

        [HttpDelete("{islandId}")]
        [Produces("application/json")]
        public ActionResult Delete(
            [FromRoute] Guid islandId)
        {
            try
            {
                _repository.DeleteIsland(islandId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to delete island");
                return Problem(e.Message);
            }
        }
    }
}
