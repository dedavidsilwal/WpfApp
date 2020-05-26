
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel(IOptions<AppSettings> options, 
            ILogger<MainViewModel> logger)
        {
            Text = options.Value.Text;
          

            logger.LogError($"Text from settings: '{options.Value.Text}'");

        }

        public string Text { get; set; }
    }
}
