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
    public class SteererController : ControllerBase
    {
        private readonly ILogger<SerialPortsController> _logger;
        private readonly IPortApplication portApplication;
        private readonly ISteererApplication steerer;

        public SteererController(ILogger<SerialPortsController> logger, 
        IPortApplication portApplication,
        ISteererApplication steerer)
        {
            _logger = logger;
            this.portApplication = portApplication;
            this.steerer = steerer;
        }

        [HttpPost("Advertisement/{port}")]
        [HttpPost("Advertisement")]
        [Consumes( MediaTypeNames.Application.Json )]
        [ProducesResponseType(typeof(DeviceResponse), (int)HttpStatusCode.OK ) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound ) ]
        public async Task<ActionResult<DeviceResponse>> Advertise(string port)
        {
            string selectedPort = port == null? Request.Cookies[Cookies.CookieRecentPortKey]: port; 
            DeviceResponse info = portApplication.Get(selectedPort);
            if(info == null)
            {
                return NotFound();
            }

            await steerer.AdvertiseAsync(selectedPort);            
                
            return Ok(info);
        }
    }
}
