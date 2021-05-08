using System;
using System.Net;
using System.Net.Mime;
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
        [Consumes( MediaTypeNames.Application.Json )]
        [ProducesResponseType(typeof(Ping), (int)HttpStatusCode.OK ) ]
        public ActionResult<Ping> Get()
        {
            return Ok(new Ping(){Processed = DateTime.UtcNow});
        }
    }
}
