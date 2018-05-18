# Known Issues

## The process cannot access the file

System.Configuration.ConfigurationErrorsException: An error occurred loading a configuration file: The
process cannot access the file 'c:\users\lco05\source\repos\NetFramework.DetectConfigChange\NetFramework.DetectConfigChange\bin\Debug\NetFramework.DetectConfigChange.exe.Config' because it is being used by another process. (c:\users\lco05\source\repos\NetFramework.DetectConfigChange\NetFramework.DetectConfigChange\bin\Debug\NetFramework.DetectConfigChange.exe.Config) ---> System.IO.IOException: The process cannot access the file 'c:\users\lco05\source\repos\NetFramework.DetectConfigChange\NetFramework.DetectConfigChange\bin\Debug\NetFramework.DetectConfi
gChange.exe.Config' because it is being used by another process.
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions o
ptions, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access,FileShare share)
   at System.Configuration.Internal.InternalConfigHost.StaticOpenStreamForRead(String streamName)
   at System.Configuration.Internal.InternalConfigHost.System.Configuration.Internal.IInternalConfigHost.OpenStreamForRead(String streamName, Boolean assertPermissions)
   at System.Configuration.Internal.InternalConfigHost.System.Configuration.Internal.IInternalConfigHost.OpenStreamForRead(String streamName)
   at System.Configuration.ClientConfigurationHost.OpenStreamForRead(String streamName)
   at System.Configuration.BaseConfigurationRecord.RefreshFactoryRecord(String configKey)
   --- End of inner exception stack trace ---
   at System.Configuration.ConfigurationSchemaErrors.ThrowIfErrors(Boolean ignoreLocal)
   at System.Configuration.BaseConfigurationRecord.ThrowIfParseErrors(ConfigurationSchemaErrors schemaErrors)
   at System.Configuration.BaseConfigurationRecord.RefreshFactoryRecord(String configKey)
   at System.Configuration.BaseConfigurationRecord.hlClearResultRecursive(String configKey, Boolean forceEvaluatation)
   at System.Configuration.BaseConfigurationRecord.hlClearResultRecursive(String configKey, Boolean forceEvaluatation)
   at System.Configuration.Internal.InternalConfigRoot.ClearResult(BaseConfigurationRecord configRecord, String configKey, Boolean forceEvaluation)
   at System.Configuration.BaseConfigurationRecord.RefreshSection(String configKey)
   at System.Configuration.ClientConfigurationSystem.System.Configuration.Internal.IInternalConfigSystem.RefreshConfig(String sectionName)
   at System.Configuration.ConfigurationManager.RefreshSection(String sectionName)
   at NetFramework.DetectConfigChange.Program.OnChanged(Object sender, FileSystemEventArgs e) in c:\users\lco05\source\repos\NetFramework.DetectConfigChange\NetFramework.DetectConfigChange\Program.cs:line 64
