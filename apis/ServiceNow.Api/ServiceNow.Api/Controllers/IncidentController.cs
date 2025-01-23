using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceNow.Api.Classes;
using ServiceNow.Api.Services;
using System.Net.Http.Headers;
using System.Text;

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
    [Authorize]
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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateIncident([FromBody] IncidentRequest request)
    {

        // Access the user's email from the authenticated token
        var userEmail = User.Identity?.Name;

        if (string.IsNullOrEmpty(userEmail))
        {
            _logger.LogWarning("Unauthorized access attempt detected.");
            return Unauthorized(new { Message = "User is not authenticated." });
        }

        if (request == null || string.IsNullOrEmpty(request.ShortDescription) )
        {
            return BadRequest(new { error = "Missing required fields: short_description or username" });
        }

        var token = await _serviceNowToken.GetOAuthTokenAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var callerId = await GetCallerId(userEmail, token);

        if (string.IsNullOrEmpty(callerId))
        {
            return NotFound(new { error = "User not found with username: " + userEmail });
        }

        var body = new
        {
            short_description = request.ShortDescription,
            description = request.Description,
            caller_id = callerId,
            category = request.Category ?? "inquiry",
            impact = request.Impact ?? 3,
            urgency = request.Urgency ?? 3
        };

        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_settings.Instance}/api/now/table/incident", content);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return Created("", new { result = "Incident created successfully", responseBody });
        }
        else
        {
            return StatusCode((int)response.StatusCode, new { error = response.ReasonPhrase });
        }
    }

    private async Task<string> GetCallerId(string username, string token)
    {
        //var token = await _serviceNowToken.GetOAuthTokenAsync();
        //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync($"{_settings.Instance}/api/now/table/sys_user?sysparm_query=email={username}");
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceNowUserResponse>(responseBody);
            if (result.result != null && result.result.Count > 0)
            {
                return result.result[0].sys_id;
            }
        }

        return null;
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

    public class IncidentRequest
    {
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string? Category { get; set; }
        public int? Impact { get; set; }
        public int? Urgency { get; set; }
    }

    public class ServiceNowUserResponse
    {
        public List<ServiceNowUser> result { get; set; }
    }

    public class ServiceNowUser
    {
        public string sys_id { get; set; }
        // Add other fields if needed for future use
    }

}
