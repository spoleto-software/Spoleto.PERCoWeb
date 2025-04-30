using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.PERCoWeb
{
    public class PercoWebAuthenticator : DynamicAuthenticator
    {
        public const string TokenTypeName = "Bearer";

        private readonly PercoWebOptions _percoWebOptions;

        public PercoWebAuthenticator(PercoWebOptions percoWebOptions) : base(TokenTypeName)
        {
            _percoWebOptions = percoWebOptions;
        }

        protected override async Task<string> GetAuthenticationToken(IRestClient client)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "api/system/auth")
                .WithJsonContent(new { login = _percoWebOptions.Login, password = _percoWebOptions.Password })
                .Build();

            var tokenModel = await client.ExecuteAsync<TokenModel>(restRequest).ConfigureAwait(false);

            return tokenModel!.Token;
        }
    }
}
