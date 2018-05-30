using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IConfigurationMonitor
    {
        bool MonitorEnabled { get; set; }

        string CurrentState { get; set; }
    }
}
