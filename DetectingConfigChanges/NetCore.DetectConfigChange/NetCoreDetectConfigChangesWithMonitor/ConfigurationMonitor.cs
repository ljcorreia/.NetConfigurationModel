using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ConfigurationMonitor : IConfigurationMonitor
    {
        public bool MonitorEnabled { get; set; } = false;

        public string CurrentState { get; set; } = "Not Monitoring";

        public IHostingEnvironment _env { get; set; }

        public ConfigurationMonitor(IConfiguration config, IHostingEnvironment env)
        {
            _env = env;

            ChangeToken.OnChange<string>(() => config.GetReloadToken(),
                (state) => InvokeChange(state), "Not Monitoring");
        }

        private void InvokeChange(string state)
        {
            if (MonitorEnabled)
            {
                Debug.WriteLine($"State Updated at {DateTime.Now}");
                CurrentState = state;
            }
            else
            {
                Debug.WriteLine($"Changed but state not updated because monitor is not enabled");
            }
        }
    }
}
