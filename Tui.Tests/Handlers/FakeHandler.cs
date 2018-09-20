using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Tui.Tests.Handlers
{
    public class FakeHttpHandler : HttpClientHandler
    {
        public virtual Task<HttpResponseMessage> GetAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return SendAsync(request, CancellationToken.None);
        }
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new System.NotImplementedException("Meant for mocking purposes.");
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Send(request));
        }
    }
}
