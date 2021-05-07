using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ZwiftSteero.Application;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Service.Extensions;
using ZwiftSteero.Service.Mappers;
using ZwiftSteero.Service.Models;

namespace ZwiftSteero.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {

        private readonly ILogger<DevicesController> _logger;
        private readonly IPortApplication portApplication;

        public DevicesController(ILogger<DevicesController> logger, IPortApplication portApplication)
        {
            _logger = logger;
            this.portApplication = portApplication;
        }

        [HttpGet("{port}")]
        public ActionResult<Device> Get([FromRoute] string port)
        {
            IPortInfo info = portApplication.Get(port);
            if(info == null)
            {
                return NotFound();
            } 
            else
            {
                return Ok(portApplication.Get(port).Map());
            }
        }

        [HttpGet]
        public async Task<ActionResult<Device>> GetList()
        {
            IPortInfo[] ports = await portApplication.GetNewPortsAsync();
            IEnumerable<Device> devices = ports.Select(p => p.Map());

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
