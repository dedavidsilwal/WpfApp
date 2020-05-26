using System.Net.Http;
using System.Threading.Tasks;

namespace WpfApp.ApiClients
{
    public class AuthenticationClient
    {
        private readonly HttpClient _client;

        public AuthenticationClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<HttpResponseMessage> Authenticate()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
