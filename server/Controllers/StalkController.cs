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
        public IEnumerable<Stalk> Get()
        {
            var stalkList = new List<Stalk>();

            stalkList.Add(new Stalk
            {
                id = new Guid(),
                islandId = new Guid(),
                meridian = Meridian.AM,
                bellPrice = 120,
                date = new DateTime(),
                enteredBy = new Guid()
            });

            return stalkList;
        }
    }
}
