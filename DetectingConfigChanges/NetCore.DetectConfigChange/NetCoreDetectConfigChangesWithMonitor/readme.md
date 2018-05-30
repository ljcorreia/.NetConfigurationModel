# Detect Config Changes With Monitor

This is a .Net Core Web Application project (API) wich demonstrates how the new .Net Core Configuration Model works when detecting and reloading configuration changes.

The default settings file is included and configuration is built using Conficuration builder which is passed in from the Program to the Startup class in the way it is expected with the .Net Core 2.0.

Prior this version the configuration was built differently with the use of ConfigurationBuilder() and UseConfiguration() WebHost extension method.

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

If you would like to contribute by maintaining ths project up to date, just drop me a message.

Enjoy! 