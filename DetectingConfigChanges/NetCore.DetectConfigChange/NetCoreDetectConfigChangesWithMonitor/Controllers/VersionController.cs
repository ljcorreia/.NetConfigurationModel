using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NetCoreDetectConfigChangesWithMonitor.Controllers
{
    [Produces("application/json")]
    [Route("api/version")]
    public class VersionController : ApiControllerBase
    {
        private IConfiguration _config { get; set; }

        private VersionConfig _versionConfig { get; set; }

        private VersionConfig _versionConfigRefresh { get; set; }

        private IConfigurationMonitor _monitor { get; set; }
    public VersionController(IConfiguration config, IOptionsSnapshot<VersionConfig> versionConfigRefresh, IOptions<VersionConfig> versionConfig, IConfigurationMonitor monitor) : base(monitor)

        {
            _config = config;
            _versionConfig = versionConfig.Value;
            _versionConfigRefresh = versionConfigRefresh.Value;
            _monitor = monitor;
        }

        [Route("config")]
        public IActionResult GetConfig()
        {
            return new JsonResult(_config);
        }

        public IActionResult Get()
        {
            return _monitor.MonitorEnabled ? new JsonResult(_versionConfigRefresh) : new JsonResult(_versionConfig);
        }
    }
}