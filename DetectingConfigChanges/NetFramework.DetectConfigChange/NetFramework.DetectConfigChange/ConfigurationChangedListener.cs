using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NetFramework.DetectConfigChange
{
    public class ConfigurationChangedListener : INotifyConfigurationChanged
    {
        public string Name { get; internal set; }

        protected ConfigurationChangedListener() : this("")
        {
        }

        public ConfigurationChangedListener(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("You need to name the listener.");
            }

            Name = name;
        }

        public void NotifyConfigurationChanged()
        {
            const string strKeyName = "StartTime";
            var startTime = ConfigurationManager.AppSettings[strKeyName];

            //var appSettings = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetEntryAssembly().Location).AppSettings;
            //var setting = appSettings.Settings[strKeyName].Value;

            Console.WriteLine($"Configuration {strKeyName} changed: {startTime}");
        }
    }
}
