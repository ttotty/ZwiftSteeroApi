using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ZwiftSteero.Service.Models;

namespace ZwiftSteero.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Ping> Get()
        {
            return Ok(new Ping(){Processed = DateTime.UtcNow});
        }
    }
}
