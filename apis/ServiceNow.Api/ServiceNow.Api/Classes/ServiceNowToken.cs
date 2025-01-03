using Microsoft.Extensions.Options;
using ServiceNow.Api.Classes;
using Newtonsoft.Json.Linq;


namespace ServiceNow.Api.Services;

    public class ServiceNowToken
    {
    private readonly ServiceNowSettings _settings;
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceNowToken(IOptions<ServiceNowSettings> settings, IHttpClientFactory httpClientFactory)
    {
        _settings = settings.Value;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GetOAuthTokenAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.Instance}/oauth_token.do");
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("client_id", _settings.ClientId),
            new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
            new KeyValuePair<string, string>("username", _settings.Username),
            new KeyValuePair<string, string>("password", _settings.Password)
        });
        request.Content = content;

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(responseBody);
        return json["access_token"].ToString();
    }
}

