using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace NSE.WebApi.Core.Extensions
{
    public static class PollyExtension
    {
        public static AsyncRetryPolicy<HttpResponseMessage> RetryWait()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                });

            return retry;
        }
    }
}
