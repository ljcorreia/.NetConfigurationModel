# Detect Config Changes With Monitor

This is a .Net Core Web Application project (API) wich demonstrates how the new .Net Core Configuration Model works when detecting and reloading configuration changes.

The default settings file and any other json file is included using .AddJsonFile() and the configuration is built using Configuration builder which is passed in from the Program to the Startup class in the way it is expected with the .Net Core 2.0.

Prior to this version the configuration was built differently with the use of ConfigurationBuilder() and UseConfiguration() through WebHost extension methods as opposed to ConfigureAppConfiguration() - which I could only figure out thanks to [this StackOverflow answer](https://stackoverflow.com/a/46570073/4189349).

In the example below a custom json file 'version-config.json' is included and that file is later mapped to a Strongly Typed object named VersionConfig.cs.

## Previous versions of .Net Core

```csharp
	public static IWebHost BuildWebHost(string[] args)
    {
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("version-config.json", false, true)
			.Build();

		return WebHost.CreateDefaultBuilder(args)
			.UseConfiguration(config)
			.UseStartup<Startup>()
            .Build();
    }
```

## New .Net Core 2.0 or later:

```csharp
	public static IWebHost BuildWebHost(string[] args)
    {
		return WebHost.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((buiderContext, config) => {
				IHostingEnvironment env = buiderContext.HostingEnvironment;

				config.SetBasePath(Directory.GetCurrentDirectory());
				config.AddJsonFile("version-config.json", false, true);
			})
			.UseStartup<Startup>()
            .Build();
    }
```

The configuation is then resolved in the Startup class and controllers with the use of .Net Core built-in Dependency Injection.

In addition to this, the project uses the new IOptionsSnapshot to get the latest changes of a modified configuration.

It also makes use of IChangeToken which makes use of ChangeToken.OnChange() to hook an event if changes occur.

All together, it shows how this scenario can be achieved in the new version of .Net Core 2.0.

Just run this project hitting the Version controller. There is an API Base Controller used to enable or disabled the Monitor.

```
http://localhost:9435/api/version
```

To enable the monitor, just hit the endpoint below (use stop to disable it):

```
http://localhost:9435/api/start
```

After changing the version-config.json with the project running (under IISExpress by default) you will see that the changes you have made to the file can only be seen if the monitor is enabled.

So the version endpoint will only show the latest version if monitor is enabled. Obviously, this is only a demonstration and not how you would necessarily use the monitor.

If you would like to contribute by maintaining this project up to date, just drop me a message.

Enjoy! 