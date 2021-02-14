using System;
using System.Collections.Generic;
using Interfaces.IVillagerRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Villager;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/villagers")]
    public class VillagerController : ControllerBase
    {
        private readonly IVillagerRepository _repository;
        public VillagerController(IVillagerRepository repository)
        {
            _repository = repository;
        }
        private readonly ILogger<VillagerController> _logger;

        public VillagerController(ILogger<VillagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Villager> Get()
        {
            _logger.LogInformation("Get villager info");

            return _repository.GetVillagers();
        }
    }
}