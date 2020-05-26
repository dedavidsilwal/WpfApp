using Microsoft.Extensions.DependencyInjection;
using Prism.Events;

namespace WpfApp.Extensions
{
    public static class ConfigureServiceExtension
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IEventAggregator, EventAggregator>();
            services.AddTransient(typeof(MainWindow));
        }
    }
}
