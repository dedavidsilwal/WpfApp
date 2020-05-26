
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class MainViewModel
    {
        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel(
            IOptions<AppSettings> options,
            ILogger<MainViewModel> logger)
        {
            Text = options.Value.Text;
            _logger = logger;
        }

        public string Text { get; set; }
    }
}
