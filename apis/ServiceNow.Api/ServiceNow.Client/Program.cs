using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using ServiceNow.Client;
using System.Net.Http.Headers;
using System.Text;


// load appsettings.json
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .Build();

// Map AppSettings
var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

// Set settings
string tenantId = appSettings.TenantId;
string apiUrl = appSettings.ApiUrl;
string[] scopes = { appSettings.Scopes }; 
string clientId = appSettings.ClientId;

// Configurar o MSAL
var app = PublicClientApplicationBuilder
    .Create(clientId)
    .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
    .WithRedirectUri("http://localhost")
    .Build();


var result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

await CallApi(apiUrl, result.AccessToken);

// Now, create an incident
await CreateIncident(apiUrl, result.AccessToken);



Console.WriteLine("Press any key to end.");

Console.ReadKey();

static async Task CreateIncident(string apiUrl, string accessToken)
{
    using var httpClient = new HttpClient();

    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    var incidentData = new
    {
        shortdescription = "Internet Issue",
        description = "Users in the West wing are reporting slow network speeds and occasional disconnections.",
        category = "Network",
        impact = 2,
        urgency = 2
    };

    var json = JsonConvert.SerializeObject(incidentData);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Incident created successfully:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    else
    {
        Console.WriteLine($"Failed to create incident. Status Code: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}

//static async Task<string> GetAccessToken(string tenantId, string clientId, string clientSecret, string apiScope)
//{
//    // Create a confidential client application
//    IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
//        .Create(clientId)
//        .WithClientSecret(clientSecret)
//        .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
//        .Build();

//    // Acquire a token for the specified scope
//    var result = await app.AcquireTokenForClient(new[] { apiScope }).ExecuteAsync();
//    Console.WriteLine($"Access Token Acquired: {result.AccessToken.Substring(0, 50)}..."); // Log a portion of the token
//    return result.AccessToken;
//}

static async Task CallApi(string apiUrl, string accessToken)
{
    // Create an HttpClient to make the request
    using var httpClient = new HttpClient();

    // Add the access token to the Authorization header
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    // Send the GET request
    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

    if (response.IsSuccessStatusCode)
    {
        string responseData = await response.Content.ReadAsStringAsync();
        Console.WriteLine("API Response:");
        Console.WriteLine(responseData);
    }
    else
    {
        Console.WriteLine($"API call failed with status code: {response.StatusCode}");
        Console.WriteLine($"Error: {await response.Content.ReadAsStringAsync()}");
    }
}
