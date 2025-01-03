using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceNow.Api.Classes;
using ServiceNow.Api.Services;
using System.Net.Http.Headers;

namespace ServiceNow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : Controller
{

    private readonly ILogger<IncidentController> _logger;

    private readonly ServiceNowToken _serviceNowToken;
    private readonly ServiceNowSettings _settings;
    private readonly HttpClient _httpClient;

    public IncidentController(ILogger<IncidentController> logger, ServiceNowToken serviceNowToken, IOptions<ServiceNowSettings> settings, HttpClient httpClient)
    {
        _logger = logger;
        _serviceNowToken = serviceNowToken;
        _settings = settings.Value;
        _httpClient = httpClient;
    }

    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<List<Incident>>> Get()
    {

        // Access the user's email from the authenticated token
        var userEmail = User.Identity?.Name;

        if (string.IsNullOrEmpty(userEmail))
        {
            _logger.LogWarning("Unauthorized access attempt detected.");
            return Unauthorized(new { Message = "User is not authenticated." });
        }

        _logger.LogInformation("Request processed for user: {UserEmail}", userEmail);

        var token = await _serviceNowToken.GetOAuthTokenAsync();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.GetAsync($"{_settings.Instance}/api/now/table/incident?sysparm_query=caller_id.email={userEmail}");
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ServiceNowResponse>(responseBody);
        return Ok(result.Result);
    }


    public class ServiceNowResponse
    {
        public List<Incident> Result { get; set; }
    }

    public class Incident
    {
        public string Number { get; set; }
        public string Short_description { get; set; }
        public string State { get; set; }
    }

}
