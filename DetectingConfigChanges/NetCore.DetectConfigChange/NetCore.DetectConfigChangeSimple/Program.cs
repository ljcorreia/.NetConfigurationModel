using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace NetCore.DetectConfigChange
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            PrintConfigValues();
            Console.WriteLine("Press a key...");
            Console.WriteLine("You can now change one of appsettings.json values...");
            Console.ReadKey();
            PrintConfigValues();
            Console.WriteLine("check if the value you've changed is printed correctly.");
            Console.ReadKey();
        }

        private static void PrintConfigValues()
        {
            Console.WriteLine($"option1 = {Configuration["Option1"]}");
            Console.WriteLine($"option2 = {Configuration["option2"]}");
            Console.WriteLine(
                $"suboption1 = {Configuration["subsection:suboption1"]}");
            Console.WriteLine();

            Console.WriteLine("Wizards:");
            Console.Write($"{Configuration["wizards:0:Name"]}, ");
            Console.WriteLine($"age {Configuration["wizards:0:Age"]}");
            Console.Write($"{Configuration["wizards:1:Name"]}, ");
            Console.WriteLine($"age {Configuration["wizards:1:Age"]}");
            Console.WriteLine();
        }
    }
}
