using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Windows;
using static WpfApp.Extensions.ConfigureServiceExtension;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) => {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureServices((context, services) => {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging(logging => {
                    //var logger = new LoggerConfiguration()
                    //    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                    //    .CreateLogger();

                    var logger = new LoggerConfiguration()
                            .WriteTo.Async(a => a.File("logs/myapp.log", rollingInterval: RollingInterval.Day))
                            // Other logger configuration
                            .CreateLogger();

                    logging.ClearProviders();
                    logging.AddSerilog(logger);

                })
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                Log.CloseAndFlush();
                await _host.StopAsync(TimeSpan.FromSeconds(2));
            }
        }

    }
}
