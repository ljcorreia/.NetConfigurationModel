namespace NetCoreDetectConfigChangesWithMonitor
{
    public interface IConfigurationMonitor
    {
        bool MonitorEnabled { get; set; }

        string CurrentState { get; set; }
    }
}
