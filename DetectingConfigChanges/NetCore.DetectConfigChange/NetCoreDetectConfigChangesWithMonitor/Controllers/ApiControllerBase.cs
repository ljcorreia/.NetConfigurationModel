using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiControllerBase : ControllerBase
    {
        private IConfigurationMonitor _monitor { get; set; }

        public ApiControllerBase(IConfigurationMonitor monitor)
        {
            _monitor = monitor;
        }

        [Route("start")]
        public IActionResult StartMonitor()
        {
            var message = (_monitor.MonitorEnabled) ? "Monitor was already started" : "Monitor has been started";            
            _monitor.MonitorEnabled = true;

            return new OkObjectResult(new JObject(new JProperty("result", message)));
        }

        [Route("stop")]
        public IActionResult StopMonitor()
        {
            var message = (_monitor.MonitorEnabled) ? "Monitor was already stopped" : "Monitor has been stopped";
            _monitor.MonitorEnabled = false;

            return new OkObjectResult(new JObject(new JProperty("result", message)));
        }
    }
}