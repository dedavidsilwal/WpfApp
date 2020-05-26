using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp.Extensions
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILogger _logger;

        public LoggingHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Request: {request}");

            if (request.Content != null)
                _logger.LogDebug(await request.Content.ReadAsStringAsync());

            var response = await base.SendAsync(request, cancellationToken);

            _logger.LogDebug($"Response: {response}");

            if (response.Content != null)
                _logger.LogDebug(await response.Content.ReadAsStringAsync());

            //_logger.LogDebug("Request completed: {route} {method} {code} {headers}", request.RequestUri.Host, request.Method, response.StatusCode, request.Headers);
            return response;
        }
    }
}
