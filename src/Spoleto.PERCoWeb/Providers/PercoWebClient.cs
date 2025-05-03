using Microsoft.Extensions.Http;
using Polly;
using Polly.Extensions.Http;
using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.PERCoWeb
{
    public class PercoWebClient : RestHttpClient
    {
        public PercoWebClient(PercoWebOptions percoWebOptions)
            : this(percoWebOptions, CreateNewClient(percoWebOptions), CreateAuthenticator(percoWebOptions), RestClientOptions.Default, true)
        {
        }

        public PercoWebClient(PercoWebOptions percoWebOptions, HttpClient httpClient, IAuthenticator? authenticator = null, RestClientOptions? options = null, bool disposeHttpClient = false)
            : base(httpClient, authenticator, options, disposeHttpClient)
        {
        }

        private static HttpClient CreateNewClient(PercoWebOptions percoWebOptions)
        {
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var policyHandler = new PolicyHttpMessageHandler(retryPolicy);
#if NET
            policyHandler.InnerHandler = new SocketsHttpHandler
            {
//#if DEBUG
                SslOptions = new()
                {
                    // Allow all certificates
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                }
//#endif
            };
#else
            policyHandler.InnerHandler = new HttpClientHandler
            {
#if DEBUG
                // Allow all certificates
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
#endif
            };
#endif

            var httpClient = new HttpClient(policyHandler, true) { BaseAddress = new Uri(percoWebOptions.ServiceUrl) };

            return httpClient;
        }

        private static IAuthenticator CreateAuthenticator(PercoWebOptions percoWebOptions)
        {
            var authenticator = new PercoWebAuthenticator(percoWebOptions);

            return authenticator;
        }
    }
}
