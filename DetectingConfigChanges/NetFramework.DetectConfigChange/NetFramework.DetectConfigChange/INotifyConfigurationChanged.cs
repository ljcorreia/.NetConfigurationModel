using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFramework.DetectConfigChange
{
    public interface INotifyConfigurationChanged
    {
        void NotifyConfigurationChanged();
    }
}
