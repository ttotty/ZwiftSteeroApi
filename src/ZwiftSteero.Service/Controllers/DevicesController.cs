using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Service.Extensions;

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
        [Consumes( MediaTypeNames.Application.Json )]
        [ProducesResponseType(typeof(DeviceInfo), (int)HttpStatusCode.OK ) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound ) ]
        public ActionResult<DeviceInfo> Get([FromRoute] string port)
        {
            DeviceInfo info = portApplication.Get(port);
            if(info == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(portApplication.Get(port));
            }
        }

        [HttpGet]
        [Consumes( MediaTypeNames.Application.Json )]
        [ProducesResponseType(typeof(DeviceInfo), (int)HttpStatusCode.OK ) ]
        [ProducesResponseType((int)HttpStatusCode.Conflict ) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound ) ]
        public async Task<ActionResult<DeviceInfo>> Search()
        {
            DeviceInfo[] devices = await portApplication.GetNewPortsAsync();

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
