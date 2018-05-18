using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFramework.DetectConfigChange
{
    class Program
    {
        //see: http://stackoverflow.com/q/34439625/4189349
        private static FileSystemWatcher _fileSystemWatcher;
        public static readonly List<INotifyConfigurationChanged>  ConfigurationChangedListeners = new List<INotifyConfigurationChanged>();

        static void Main(string[] args)
        {
            var assemblyDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            const NotifyFilters notifyFilters = NotifyFilters.LastWrite;
            _fileSystemWatcher = new FileSystemWatcher()
            {
                Path = assemblyDirectory,
                NotifyFilter = notifyFilters,
                Filter = "*.config"
            };
            _fileSystemWatcher.Changed += OnChanged;
            _fileSystemWatcher.EnableRaisingEvents = true;

            Console.Write($"Enter one or more listener name(s) [Separated by space]: ");
            while (!args.Contains("exit"))
            {
                foreach (var arg in args)
                {
                    AddListener(arg);
                }

                args = new[] {Console.ReadLine()};
            }
        }

        private static void AddListener(string name)
        {
            try
            {
                ConfigurationChangedListeners.Add(new ConfigurationChangedListener(name));
            }
            catch (Exception e)
            {
                Console.WriteLine($"A Listener could not be added, but the exception was logged: {e.Message}");
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                _fileSystemWatcher.EnableRaisingEvents = false;

#if DEBUG
                //TODO: check reason for error if line below is commented out: see known-errors.md
                //Debug.WriteLine($"Can read file?: {Helper.CanReadFile(e.FullPath)}");
#endif

                ConfigurationManager.RefreshSection("appSettings");
                foreach (var listener in ConfigurationChangedListeners)
                {
                    listener.NotifyConfigurationChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
            finally
            {
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }
    }
}
