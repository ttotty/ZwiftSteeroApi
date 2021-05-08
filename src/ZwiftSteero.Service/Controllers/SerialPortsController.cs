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
    public class SerialPortsController : ControllerBase
    {
        private readonly ILogger<SerialPortsController> _logger;
        private readonly IPortApplication portApplication;

        public SerialPortsController(ILogger<SerialPortsController> logger, 
        IPortApplication portApplication)
        {
            _logger = logger;
            this.portApplication = portApplication;
        }

        [HttpGet("{port}")]
        [Consumes( MediaTypeNames.Application.Json )]
        [ProducesResponseType(typeof(DeviceResponse), (int)HttpStatusCode.OK ) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound ) ]
        public ActionResult<DeviceResponse> Get([FromRoute] string port)
        {
            DeviceResponse info = portApplication.Get(port);
            if(info == null)
            {
                return NotFound();
            }
            else
            {
                Response.Cookies.Append(Cookies.CookieRecentPortKey, info.Port);
                return Ok(info);
            }
        }

        [HttpGet]
        [Consumes( MediaTypeNames.Application.Json )]
        [ProducesResponseType(typeof(DeviceResponse), (int)HttpStatusCode.OK ) ]
        [ProducesResponseType((int)HttpStatusCode.Conflict ) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound ) ]
        public async Task<ActionResult<DeviceResponse>> Search()
        {
            DeviceResponse[] devices = await portApplication.GetNewPortsAsync();

            if(devices.Count() == 1)
            {
                Response.Cookies.Append(Cookies.CookieRecentPortKey, devices[0].Port);
                return Ok(devices[0]);
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
