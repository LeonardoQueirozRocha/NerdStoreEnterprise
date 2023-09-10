using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace NSE.WebApi.Core.Extensions;

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

    public static IHttpClientBuilder AddPollyPolicy(this IHttpClientBuilder builder)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        builder.AddPolicyHandler(RetryWait());
        builder.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        return builder;
    }
}