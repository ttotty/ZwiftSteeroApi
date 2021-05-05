using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZwiftSteero.Service.Models;

namespace ZwiftSteero.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;

        public DeviceController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Device> Get()
        {
            return Ok(new Device());
        }
    }
}
