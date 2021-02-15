using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.CreateStalk;
using Models.Stalk;
using Repositories.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/stalks")]
    public class StalkController : ControllerBase
    {
        private readonly ILogger<StalkController> _logger;

        private readonly IStalkRepository _repository;

        public StalkController(ILogger<StalkController> logger, IStalkRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Stalk>> Get()
        {
            try
            {
                return Ok(_repository.GetStalks());
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to get stalks");
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Stalk>> Create([FromBody] CreateStalk createStalk)
        {
            try
            {
                return Ok(_repository.CreateStalk(createStalk));
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to create stalks");
                return Problem(e.Message);
            }
        }

        [HttpPatch("{stalkId}")]
        [Produces("application/json")]
        public ActionResult Delete(
            [FromRoute] Guid stalkId)
        {
            try
            {
                _repository.DeleteStalk(stalkId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to delete stalk");
                return Problem(e.Message);
            }
        }
    }
}
