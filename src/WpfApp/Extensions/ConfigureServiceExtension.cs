using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using WpfApp.Models;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp.Extensions
{
    public static class ConfigureServiceExtension
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration);


            services.AddTransient<MainViewModel>();


            services.AddTransient<IEventAggregator, EventAggregator>();
            services.AddTransient(typeof(MainView));
        }
    }
}
