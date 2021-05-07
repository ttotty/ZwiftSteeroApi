using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ZwiftSteero.BleUDevice;
using ZwiftSteero.Service.Extensions;
using ZwiftSteero.Service.Models;

namespace ZwiftSteero.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {

        private readonly ILogger<DevicesController> _logger;
        private readonly IPortInfo portInfo;

        public DevicesController(ILogger<DevicesController> logger, IPortInfo portInfo)
        {
            _logger = logger;
            this.portInfo = portInfo;
        }

        [HttpGet("{port}")]
        public ActionResult<Device> Get([FromRoute] string port)
        {
            return Ok(new Device());
        }

        [HttpGet]
        public async Task<ActionResult<Device>> GetList()
        {
            IPortInfo[] ports = await portInfo.SearchForNewPortAsync();
            IEnumerable<Device> devices = ports.Select(p => new Device()
            {
                Port = p.Port
            });

            if(devices.Count() == 1)
            {
                return Ok(devices);
            }
            else if(devices.Count() > 1)
            {
                //There can only be one! Unable to pick which is the correct new device that was just added
                return this.StatusCode(HttpStatusCode.Conflict);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
